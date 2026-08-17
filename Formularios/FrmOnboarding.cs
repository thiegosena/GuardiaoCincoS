using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmOnboarding : Form
    {
        private static readonly string[] ChecklistPadrao =
        {
            "Apresentação da empresa e cultura organizacional",
            "Apresentação do Espaço Kylegal",
            "Treinamento de Segurança do Trabalho",
            "Apresentação do Programa 5S (Sistema Guardião)",
            "Tour pelo setor de trabalho",
            "Apresentação da equipe e liderança",
            "Entrega de EPIs e uniformes",
            "Acesso aos materiais de estudo"
        };

        private int _idOnboardingSelecionado = 0;

        public FrmOnboarding()
        {
            InitializeComponent();
        }

        private void FrmOnboarding_Load(object sender, EventArgs e)
        {
            dtpDataInicioOnboarding.Value = DateTime.Today;
            CarregarColaboradores();
            CarregarGridOnboardings();
            dgvChecklistOnboarding.Columns.Clear();

            if (Sessao.NomePerfil == "Colaborador")
            {
                cboColaboradorOnboarding.Enabled = false;
                dtpDataInicioOnboarding.Enabled = false;
                btnIniciarOnboarding.Enabled = false;
                dgvChecklistOnboarding.Enabled = false;
                btnSalvarProgresso.Enabled = false;
                btnConcluirOnboarding.Enabled = false;
            }
        }

        private void CarregarColaboradores()
        {
            cboColaboradorOnboarding.DataSource = ColaboradorDAO.Listar();
            cboColaboradorOnboarding.DisplayMember = "Nome";
            cboColaboradorOnboarding.ValueMember = "Id";
        }

        private void CarregarGridOnboardings()
        {
            dgvOnboardings.DataSource = null;
            dgvOnboardings.DataSource = OnboardingDAO.Listar();

            if (dgvOnboardings.Columns["Observacoes"] != null)
                dgvOnboardings.Columns["Observacoes"]!.Visible = false;

            _idOnboardingSelecionado = 0;
            dgvChecklistOnboarding.Columns.Clear();
        }

        private void ConfigurarColunasChecklist()
        {
            dgvChecklistOnboarding.Columns.Clear();
            dgvChecklistOnboarding.Columns.Add("Id", "Id");
            dgvChecklistOnboarding.Columns.Add("Descricao", "Item");

            var colunaConcluido = new DataGridViewCheckBoxColumn();
            colunaConcluido.Name = "Concluido";
            colunaConcluido.HeaderText = "Concluído";
            dgvChecklistOnboarding.Columns.Add(colunaConcluido);

            dgvChecklistOnboarding.Columns.Add("DataConclusaoItem", "Data conclusão");

            dgvChecklistOnboarding.Columns["Id"]!.Visible = false;
            dgvChecklistOnboarding.Columns["Descricao"]!.ReadOnly = true;
            dgvChecklistOnboarding.Columns["Descricao"]!.Width = 320;
            dgvChecklistOnboarding.Columns["DataConclusaoItem"]!.ReadOnly = true;
        }

        private void CarregarChecklistDoOnboarding(int idOnboarding)
        {
            ConfigurarColunasChecklist();

            var itens = ItemOnboardingDAO.ListarPorOnboarding(idOnboarding);
            foreach (var item in itens)
            {
                int indice = dgvChecklistOnboarding.Rows.Add();
                dgvChecklistOnboarding.Rows[indice].Cells["Id"].Value = item.Id;
                dgvChecklistOnboarding.Rows[indice].Cells["Descricao"].Value = item.Descricao;
                dgvChecklistOnboarding.Rows[indice].Cells["Concluido"].Value = item.Concluido;
                dgvChecklistOnboarding.Rows[indice].Cells["DataConclusaoItem"].Value =
                    item.DataConclusaoItem.HasValue ? item.DataConclusaoItem.Value.ToString("dd/MM/yyyy") : "";
            }
        }

        private void dgvOnboardings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _idOnboardingSelecionado = Convert.ToInt32(dgvOnboardings.Rows[e.RowIndex].Cells["Id"].Value);
            CarregarChecklistDoOnboarding(_idOnboardingSelecionado);
        }

        private void btnIniciarOnboarding_Click(object sender, EventArgs e)
        {
            if (cboColaboradorOnboarding.SelectedValue == null)
            {
                MessageBox.Show("Selecione o colaborador para iniciar o onboarding.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cabecalho = new Onboarding
            {
                IdColaborador = Convert.ToInt32(cboColaboradorOnboarding.SelectedValue),
                DataInicio = dtpDataInicioOnboarding.Value.Date
            };

            OnboardingDAO.Iniciar(cabecalho, new List<string>(ChecklistPadrao), Sessao.IdUsuario);

            CarregarGridOnboardings();
            MessageBox.Show("Onboarding iniciado com o checklist padrão!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalvarProgresso_Click(object sender, EventArgs e)
        {
            if (_idOnboardingSelecionado == 0)
            {
                MessageBox.Show("Selecione um onboarding na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Força o grid a "confirmar" a última marcação de checkbox antes de ler os valores
            dgvChecklistOnboarding.EndEdit();

            foreach (DataGridViewRow linha in dgvChecklistOnboarding.Rows)
            {
                int idItem = Convert.ToInt32(linha.Cells["Id"].Value);
                bool concluido = Convert.ToBoolean(linha.Cells["Concluido"].Value);
                ItemOnboardingDAO.AtualizarConclusao(idItem, concluido);
            }

            CarregarChecklistDoOnboarding(_idOnboardingSelecionado);
            MessageBox.Show("Progresso salvo!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConcluirOnboarding_Click(object sender, EventArgs e)
        {
            if (_idOnboardingSelecionado == 0)
            {
                MessageBox.Show("Selecione um onboarding na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pendentes = OnboardingDAO.ContarItensPendentes(_idOnboardingSelecionado);
            if (pendentes > 0)
            {
                var confirmacao = MessageBox.Show(
                    $"Ainda há {pendentes} item(ns) não concluído(s) no checklist. Deseja concluir o onboarding mesmo assim?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacao == DialogResult.No) return;
            }

            OnboardingDAO.Concluir(_idOnboardingSelecionado);
            CarregarGridOnboardings();
            MessageBox.Show("Onboarding concluído!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fechando o formulário de Onboarding.", "Fechar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}