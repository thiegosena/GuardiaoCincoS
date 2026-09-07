using System;
using System.Drawing;
using System.Windows.Forms;
using GuardiaoCincoS.Controles;
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
            MontarLayout();

            cboTipoRonda.Items.Clear();
            cboTipoRonda.Items.Add("Inicio do Turno");
            cboTipoRonda.Items.Add("Fim do Turno");
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

        private void MontarLayout()
        {
            ClientSize = new Size(900, 900);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = EstiloVisual.FundoPagina;

            var pnlCabecalho = EstiloVisual.CriarCabecalho("Rondas Internas");

            var pnlConteudo = new Panel { Dock = DockStyle.Fill, BackColor = EstiloVisual.FundoPagina, AutoScroll = true, Padding = new Padding(20) };

            var cartaoGrid = new CartaoSecao
            {
                Titulo = "Rondas Registradas",
                CorDestaque = EstiloVisual.AzulKyly,
                Dock = DockStyle.Top,
                Height = 300,
                Margin = new Padding(0, 0, 0, 20)
            };

            dgvRondas.Dock = DockStyle.Fill;
            dgvRondas.Parent = cartaoGrid.PainelConteudo;
            EstiloVisual.ConfigurarGrid(dgvRondas);

            chkSomentePendentes.Dock = DockStyle.Top;
            chkSomentePendentes.Height = 18;
            chkSomentePendentes.Font = EstiloVisual.FonteTexto;
            chkSomentePendentes.Parent = cartaoGrid.PainelConteudo;

            var cartaoAgendar = new CartaoSecao
            {
                Titulo = "Agendar Nova Ronda",
                CorDestaque = EstiloVisual.AmareloKyly,
                Dock = DockStyle.Top,
                Height = 260,
                Margin = new Padding(0, 0, 0, 20)
            };

            var gradeAgendar = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 2,
                Padding = new Padding(4)
            };
            gradeAgendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gradeAgendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            for (int i = 0; i < gradeAgendar.RowCount; i++)
                gradeAgendar.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            gradeAgendar.Controls.Add(EstiloVisual.CriarCampo("Data", dtpDataRonda), 0, 0);
            gradeAgendar.Controls.Add(EstiloVisual.CriarCampo("Tipo", cboTipoRonda), 1, 0);

            var campoColaborador = EstiloVisual.CriarCampo("Colaborador disponível", cboColaboradorRonda);
            gradeAgendar.Controls.Add(campoColaborador, 0, 1);
            gradeAgendar.SetColumnSpan(campoColaborador, 2);

            var pnlBotaoAgendar = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Dock = DockStyle.Top,
                Height = 50,
                Margin = new Padding(6, 8, 6, 0)
            };
            EstiloVisual.EstilizarBotao(btnAgendarRonda, "Agendar", EstiloVisual.Verde, Color.White);
            pnlBotaoAgendar.Controls.Add(btnAgendarRonda);

            // Agora os dois têm Dock=Top: o botão é adicionado ANTES da grade, então --
            // mesma regra de sempre -- fica mais longe do topo, ou seja, abaixo dela.
            cartaoAgendar.PainelConteudo.Controls.Add(pnlBotaoAgendar);
            cartaoAgendar.PainelConteudo.Controls.Add(gradeAgendar);

            var cartaoConcluir = new CartaoSecao
            {
                Titulo = "Concluir Ronda Selecionada",
                CorDestaque = EstiloVisual.Verde,
                Dock = DockStyle.Top,
                Height = 220
            };

            var gradeConcluir = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(4)
            };
            gradeConcluir.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            gradeConcluir.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            gradeConcluir.Controls.Add(EstiloVisual.CriarCampoMultilinha("Observações da conclusão", txtObservacoesConclusao, 60), 0, 0);

            var pnlBotaoConcluir = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true, Margin = new Padding(6, 8, 6, 0) };
            EstiloVisual.EstilizarBotao(btnConcluirRonda, "Concluir", EstiloVisual.AzulKyly, Color.White);
            pnlBotaoConcluir.Controls.Add(btnConcluirRonda);
            gradeConcluir.Controls.Add(pnlBotaoConcluir, 0, 1);

            cartaoConcluir.PainelConteudo.Controls.Add(gradeConcluir);

            pnlConteudo.Controls.Add(cartaoConcluir);
            pnlConteudo.Controls.Add(cartaoAgendar);
            pnlConteudo.Controls.Add(cartaoGrid);

            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
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

            if (dgvRondas.Columns["Id"] != null) dgvRondas.Columns["Id"]!.Visible = false;
            if (dgvRondas.Columns["IdColaboradorResponsavel"] != null) dgvRondas.Columns["IdColaboradorResponsavel"]!.Visible = false;

            if (dgvRondas.Columns["Tipo"] != null) dgvRondas.Columns["Tipo"]!.HeaderText = "Tipo";
            if (dgvRondas.Columns["NomeColaboradorResponsavel"] != null) dgvRondas.Columns["NomeColaboradorResponsavel"]!.HeaderText = "Responsável";
            if (dgvRondas.Columns["Status"] != null) dgvRondas.Columns["Status"]!.HeaderText = "Status";
            if (dgvRondas.Columns["Observacoes"] != null) dgvRondas.Columns["Observacoes"]!.HeaderText = "Observações";

            if (dgvRondas.Columns["Data"] != null)
            {
                dgvRondas.Columns["Data"]!.HeaderText = "Data";
                dgvRondas.Columns["Data"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvRondas.Columns["DataHoraConclusao"] != null)
            {
                dgvRondas.Columns["DataHoraConclusao"]!.HeaderText = "Concluída em";
                dgvRondas.Columns["DataHoraConclusao"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            foreach (DataGridViewRow linha in dgvRondas.Rows)
            {
                var ronda = (Ronda)linha.DataBoundItem!;

                if (ronda.Status == "Concluida")
                {
                    linha.DefaultCellStyle.ForeColor = EstiloVisual.TextoSecundario;
                }
                else
                {
                    int diasRestantes = (ronda.Data.Date - DateTime.Today).Days;
                    linha.DefaultCellStyle.ForeColor = EstiloVisual.CorPorUrgencia(diasRestantes);
                }
            }
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