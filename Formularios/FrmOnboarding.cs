using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GuardiaoCincoS.Controles;
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
            MontarLayout();

            dtpDataInicioOnboarding.Value = DateTime.Today;
            CarregarColaboradores();
            CarregarGridOnboardings();

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

        private void MontarLayout()
        {
            ClientSize = new Size(950, 850);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = EstiloVisual.FundoPagina;

            var pnlCabecalho = EstiloVisual.CriarCabecalho("Onboarding de Colaboradores");

            var pnlConteudo = new Panel { Dock = DockStyle.Fill, BackColor = EstiloVisual.FundoPagina, AutoScroll = true, Padding = new Padding(20) };

            // ===== Card 1: lista de onboardings =====
            var cartaoLista = new CartaoSecao
            {
                Titulo = "Onboardings Registrados",
                CorDestaque = EstiloVisual.AzulKyly,
                Dock = DockStyle.Top,
                Height = 240,
                Margin = new Padding(0, 0, 0, 20)
            };
            dgvOnboardings.Dock = DockStyle.Fill;
            dgvOnboardings.Parent = cartaoLista.PainelConteudo;
            EstiloVisual.ConfigurarGrid(dgvOnboardings);

            // ===== Card 2: iniciar novo =====
            var cartaoIniciar = new CartaoSecao
            {
                Titulo = "Iniciar Novo Onboarding",
                CorDestaque = EstiloVisual.AmareloKyly,
                Dock = DockStyle.Top,
                Height = 180,
                Margin = new Padding(0, 0, 0, 20)
            };

            var gradeIniciar = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2 };
            gradeIniciar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gradeIniciar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gradeIniciar.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            gradeIniciar.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            gradeIniciar.Controls.Add(EstiloVisual.CriarCampo("Colaborador", cboColaboradorOnboarding), 0, 0);
            gradeIniciar.Controls.Add(EstiloVisual.CriarCampo("Data de início", dtpDataInicioOnboarding), 1, 0);

            var pnlBotaoIniciar = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Dock = DockStyle.Top,
                Height = 50,
                Margin = new Padding(6, 8, 6, 0)
            };
            EstiloVisual.EstilizarBotao(btnIniciarOnboarding, "Iniciar", EstiloVisual.Verde, Color.White);
            pnlBotaoIniciar.Controls.Add(btnIniciarOnboarding);
            gradeIniciar.Controls.Add(pnlBotaoIniciar, 0, 1);
            gradeIniciar.SetColumnSpan(pnlBotaoIniciar, 2);

            cartaoIniciar.PainelConteudo.Controls.Add(gradeIniciar);

            // ===== Card 3: checklist =====
            var cartaoChecklist = new CartaoSecao
            {
                Titulo = "Checklist do Onboarding Selecionado",
                CorDestaque = EstiloVisual.Verde,
                Dock = DockStyle.Fill
            };
            dgvChecklistOnboarding.Dock = DockStyle.Fill;
            dgvChecklistOnboarding.Parent = cartaoChecklist.PainelConteudo;
            EstiloVisual.ConfigurarGrid(dgvChecklistOnboarding, somenteLeitura: false);

            // ===== Ações finais =====
            var pnlAcoes = new Panel { Dock = DockStyle.Bottom, Height = 60, Padding = new Padding(0, 15, 0, 0) };
            var flpAcoes = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };

            EstiloVisual.EstilizarBotao(btnSalvarProgresso, "Salvar Progresso", EstiloVisual.AzulKyly, Color.White);
            EstiloVisual.EstilizarBotao(btnConcluirOnboarding, "Concluir", EstiloVisual.Verde, Color.White);
            EstiloVisual.EstilizarBotao(btnFechar, "Fechar", Color.FromArgb(210, 214, 220), EstiloVisual.TextoTitulo);

            flpAcoes.Controls.Add(btnSalvarProgresso);
            flpAcoes.Controls.Add(btnConcluirOnboarding);
            flpAcoes.Controls.Add(btnFechar);
            pnlAcoes.Controls.Add(flpAcoes);

            // Ordem de adição = inverso da ordem visual desejada (Lista -> Iniciar ->
            // Checklist, de cima pra baixo). pnlAcoes (Bottom) e cartaoChecklist (Fill)
            // não competem por ordem entre si -- só os dois Dock=Top competem.
            pnlConteudo.Controls.Add(pnlAcoes);
            pnlConteudo.Controls.Add(cartaoChecklist);
            pnlConteudo.Controls.Add(cartaoIniciar);
            pnlConteudo.Controls.Add(cartaoLista);

            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
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

            if (dgvOnboardings.Columns["Id"] != null) dgvOnboardings.Columns["Id"]!.Visible = false;
            if (dgvOnboardings.Columns["IdColaborador"] != null) dgvOnboardings.Columns["IdColaborador"]!.Visible = false;
            if (dgvOnboardings.Columns["Observacoes"] != null) dgvOnboardings.Columns["Observacoes"]!.Visible = false;

            if (dgvOnboardings.Columns["NomeColaborador"] != null) dgvOnboardings.Columns["NomeColaborador"]!.HeaderText = "Colaborador";
            if (dgvOnboardings.Columns["Status"] != null) dgvOnboardings.Columns["Status"]!.HeaderText = "Status";
            if (dgvOnboardings.Columns["DataInicio"] != null)
            {
                dgvOnboardings.Columns["DataInicio"]!.HeaderText = "Data de Início";
                dgvOnboardings.Columns["DataInicio"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvOnboardings.Columns["DataConclusao"] != null)
            {
                dgvOnboardings.Columns["DataConclusao"]!.HeaderText = "Concluído em";
                dgvOnboardings.Columns["DataConclusao"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            foreach (DataGridViewRow linha in dgvOnboardings.Rows)
            {
                var onboarding = (Onboarding)linha.DataBoundItem!;
                if (onboarding.Status == "Concluido")
                {
                    linha.DefaultCellStyle.ForeColor = EstiloVisual.TextoSecundario;
                }
            }

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
            dgvChecklistOnboarding.Columns["Descricao"]!.FillWeight = 55f;
            dgvChecklistOnboarding.Columns["Concluido"]!.FillWeight = 15f;
            dgvChecklistOnboarding.Columns["DataConclusaoItem"]!.ReadOnly = true;
            dgvChecklistOnboarding.Columns["DataConclusaoItem"]!.FillWeight = 30f;
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
            this.Close();
        }
    }
}