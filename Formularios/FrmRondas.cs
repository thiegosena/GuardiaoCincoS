using System;
using System.Windows.Forms;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmRondas : Form
    {
        private int _idRondaSelecionada = 0;

        public FrmRondas()
        {
            InitializeComponent();
        }

        private void FrmRondas_Load(object sender, EventArgs e)
        {
            cboTipoRonda.Items.Clear();
            cboTipoRonda.Items.Add("Inicio Turno");
            cboTipoRonda.Items.Add("Fim Turno");
            cboTipoRonda.SelectedIndex = 0;

            dtpDataRonda.Value = DateTime.Today;
            CarregarColaboradoresDisponiveis();
            CarregarGrid();

            if (Sessao.NomePerfil == "Colaborador")
            {
                dtpDataRonda.Enabled = false;
                cboTipoRonda.Enabled = false;
                cboColaboradorRonda.Enabled = false;
                btnAgendarRonda.Enabled = false;
                btnConcluirRonda.Enabled = false;
                txtObservacoesConclusao.Enabled = false;
            }
        }

        private void CarregarColaboradoresDisponiveis()
        {
            var disponiveis = EscalaDAO.ListarDisponiveisParaRonda(dtpDataRonda.Value.Date);
            cboColaboradorRonda.DataSource = disponiveis;
            cboColaboradorRonda.DisplayMember = "Nome";
            cboColaboradorRonda.ValueMember = "Id";
        }

        private void CarregarGrid()
        {
            dgvRondas.DataSource = null;
            dgvRondas.DataSource = RondaDAO.Listar(chkSomentePendentes.Checked);
            _idRondaSelecionada = 0;
        }

        private void dtpDataRonda_ValueChanged(object sender, EventArgs e)
        {
            CarregarColaboradoresDisponiveis();
        }

        private void chkSomentePendentes_CheckedChanged(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void dgvRondas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _idRondaSelecionada = Convert.ToInt32(dgvRondas.Rows[e.RowIndex].Cells["Id"].Value);
        }

        private void btnAgendarRonda_Click(object sender, EventArgs e)
        {
            if (cboColaboradorRonda.SelectedValue == null)
            {
                MessageBox.Show("Nao ha colaboradores disponiveis para essa data (todos estao na escala 5S semanal, ou nao ha colaboradores cadastrados).", "Atencao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ronda = new Ronda
            {
                Data = dtpDataRonda.Value.Date,
                Tipo = cboTipoRonda.Text,
                IdColaboradorResponsavel = Convert.ToInt32(cboColaboradorRonda.SelectedValue)
            };

            RondaDAO.Inserir(ronda, Sessao.IdUsuario);
            CarregarGrid();
            MessageBox.Show("Ronda agendada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConcluirRonda_Click(object sender, EventArgs e)
        {
            if (_idRondaSelecionada == 0)
            {
                MessageBox.Show("Selecione uma ronda na lista primeiro.", "Atencao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RondaDAO.Concluir(_idRondaSelecionada, txtObservacoesConclusao.Text.Trim());
            txtObservacoesConclusao.Text = "";
            CarregarGrid();
            MessageBox.Show("Ronda concluida!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}