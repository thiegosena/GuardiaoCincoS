using System;
using System.Windows.Forms;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmDemarcacoes : Form
    {
        private int _idDemarcacaoSelecionada = 0;

        public FrmDemarcacoes()
        {
            InitializeComponent();
        }

        private void FrmDemarcacoes_Load(object sender, EventArgs e)
        {
            dtpDataIdentificacao.Value = DateTime.Today;
            dtpDataPrevista.Value = DateTime.Today.AddDays(7);

            CarregarResponsaveis();
            CarregarGrid();

            if (Sessao.NomePerfil == "Colaborador")
            {
                txtLocal.Enabled = false;
                txtDescricao.Enabled = false;
                dtpDataIdentificacao.Enabled = false;
                dtpDataPrevista.Enabled = false;
                cboResponsavel.Enabled = false;
                btnRegistrarDemarcacao.Enabled = false;
                txtObservacoesConclusao.Enabled = false;
                btnConcluirDemarcacao.Enabled = false;
            }
        }

        private void CarregarResponsaveis()
        {
            cboResponsavel.DataSource = ColaboradorDAO.Listar();
            cboResponsavel.DisplayMember = "Nome";
            cboResponsavel.ValueMember = "Id";
        }

        private void CarregarGrid()
        {
            dgvDemarcacoes.DataSource = null;
            dgvDemarcacoes.DataSource = DemarcacaoDAO.Listar(chkSomentePendentes.Checked);
            _idDemarcacaoSelecionada = 0;
        }

        private void chkSomentePendentes_CheckedChanged(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void dgvDemarcacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _idDemarcacaoSelecionada = Convert.ToInt32(dgvDemarcacoes.Rows[e.RowIndex].Cells["Id"].Value);
        }

        private void btnRegistrarDemarcacao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocal.Text))
            {
                MessageBox.Show("Informe o local da demarcação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboResponsavel.SelectedValue == null)
            {
                MessageBox.Show("Selecione o responsável pela demarcação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpDataPrevista.Value.Date < dtpDataIdentificacao.Value.Date)
            {
                MessageBox.Show("O prazo não pode ser antes da data de identificação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var demarcacao = new Demarcacao
            {
                Local = txtLocal.Text.Trim(),
                Descricao = txtDescricao.Text.Trim(),
                DataIdentificacao = dtpDataIdentificacao.Value.Date,
                DataPrevista = dtpDataPrevista.Value.Date,
                IdColaboradorResponsavel = Convert.ToInt32(cboResponsavel.SelectedValue)
            };

            DemarcacaoDAO.Inserir(demarcacao, Sessao.IdUsuario);

            txtLocal.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            dtpDataIdentificacao.Value = DateTime.Today;
            dtpDataPrevista.Value = DateTime.Today.AddDays(7);

            CarregarGrid();
            MessageBox.Show("Demarcação registrada como pendente!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConcluirDemarcacao_Click(object sender, EventArgs e)
        {
            if (_idDemarcacaoSelecionada == 0)
            {
                MessageBox.Show("Selecione uma demarcação na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DemarcacaoDAO.Concluir(_idDemarcacaoSelecionada, txtObservacoesConclusao.Text.Trim());
            txtObservacoesConclusao.Text = string.Empty;
            CarregarGrid();
            MessageBox.Show("Demarcação concluída!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}