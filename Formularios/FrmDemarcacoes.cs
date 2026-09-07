using System;
using System.Drawing;
using System.Windows.Forms;
using GuardiaoCincoS.Controles;
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
            MontarLayout();

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

        private void MontarLayout()
        {
            ClientSize = new Size(900, 1000);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = EstiloVisual.FundoPagina;

            var pnlCabecalho = EstiloVisual.CriarCabecalho("Controle de Demarcações");

            var pnlConteudo = new Panel { Dock = DockStyle.Fill, BackColor = EstiloVisual.FundoPagina, AutoScroll = true, Padding = new Padding(20) };

            var cartaoGrid = new CartaoSecao
            {
                Titulo = "Demarcações Registradas",
                CorDestaque = EstiloVisual.AzulKyly,
                Dock = DockStyle.Top,
                Height = 300,
                Margin = new Padding(0, 0, 0, 20)
            };

            dgvDemarcacoes.Dock = DockStyle.Fill;
            dgvDemarcacoes.Parent = cartaoGrid.PainelConteudo;
            EstiloVisual.ConfigurarGrid(dgvDemarcacoes);

            chkSomentePendentes.Dock = DockStyle.Top;
            chkSomentePendentes.Height = 18;
            chkSomentePendentes.Font = EstiloVisual.FonteTexto;
            chkSomentePendentes.Parent = cartaoGrid.PainelConteudo;

            var cartaoRegistrar = new CartaoSecao
            {
                Titulo = "Registrar Nova Demarcação",
                CorDestaque = EstiloVisual.AmareloKyly,
                Dock = DockStyle.Top,
                Height = 340,
                Margin = new Padding(0, 0, 0, 20)
            };

            var gradeRegistrar = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(4)
            };
            gradeRegistrar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gradeRegistrar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            for (int i = 0; i < gradeRegistrar.RowCount; i++)
                gradeRegistrar.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Linha 0: Responsável e Local lado a lado, logo abaixo do título do card.
            gradeRegistrar.Controls.Add(EstiloVisual.CriarCampo("Responsável", cboResponsavel), 0, 0);
            gradeRegistrar.Controls.Add(EstiloVisual.CriarCampo("Local", txtLocal), 1, 0);

            var campoDescricao = EstiloVisual.CriarCampoMultilinha("O que precisa ser demarcado", txtDescricao, 60);
            gradeRegistrar.Controls.Add(campoDescricao, 0, 1);
            gradeRegistrar.SetColumnSpan(campoDescricao, 2);

            gradeRegistrar.Controls.Add(EstiloVisual.CriarCampo("Data de identificação", dtpDataIdentificacao), 0, 2);
            gradeRegistrar.Controls.Add(EstiloVisual.CriarCampo("Prazo para concluir", dtpDataPrevista), 1, 2);

            var pnlBotaoRegistrar = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Dock = DockStyle.Top,
                Height = 50,
                Margin = new Padding(6, 8, 6, 0)
            };
            EstiloVisual.EstilizarBotao(btnRegistrarDemarcacao, "Registrar", EstiloVisual.Verde, Color.White);
            pnlBotaoRegistrar.Controls.Add(btnRegistrarDemarcacao);

            cartaoRegistrar.PainelConteudo.Controls.Add(pnlBotaoRegistrar);
            cartaoRegistrar.PainelConteudo.Controls.Add(gradeRegistrar);

            var cartaoConcluir = new CartaoSecao
            {
                Titulo = "Concluir Demarcação Selecionada",
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
            EstiloVisual.EstilizarBotao(btnConcluirDemarcacao, "Concluir", EstiloVisual.AzulKyly, Color.White);
            pnlBotaoConcluir.Controls.Add(btnConcluirDemarcacao);
            gradeConcluir.Controls.Add(pnlBotaoConcluir, 0, 1);

            cartaoConcluir.PainelConteudo.Controls.Add(gradeConcluir);

            // Ordem de adição = inverso da ordem visual desejada (grid -> registrar -> concluir).
            pnlConteudo.Controls.Add(cartaoConcluir);
            pnlConteudo.Controls.Add(cartaoRegistrar);
            pnlConteudo.Controls.Add(cartaoGrid);

            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
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

            if (dgvDemarcacoes.Columns["Id"] != null) dgvDemarcacoes.Columns["Id"]!.Visible = false;
            if (dgvDemarcacoes.Columns["IdColaboradorResponsavel"] != null) dgvDemarcacoes.Columns["IdColaboradorResponsavel"]!.Visible = false;

            if (dgvDemarcacoes.Columns["Local"] != null) dgvDemarcacoes.Columns["Local"]!.HeaderText = "Local";
            if (dgvDemarcacoes.Columns["Descricao"] != null) dgvDemarcacoes.Columns["Descricao"]!.HeaderText = "O que precisa ser demarcado";
            if (dgvDemarcacoes.Columns["NomeResponsavel"] != null) dgvDemarcacoes.Columns["NomeResponsavel"]!.HeaderText = "Responsável";
            if (dgvDemarcacoes.Columns["Status"] != null) dgvDemarcacoes.Columns["Status"]!.HeaderText = "Status";
            if (dgvDemarcacoes.Columns["ObservacoesConclusao"] != null) dgvDemarcacoes.Columns["ObservacoesConclusao"]!.HeaderText = "Observações";

            if (dgvDemarcacoes.Columns["DataIdentificacao"] != null)
            {
                dgvDemarcacoes.Columns["DataIdentificacao"]!.HeaderText = "Identificado em";
                dgvDemarcacoes.Columns["DataIdentificacao"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvDemarcacoes.Columns["DataPrevista"] != null)
            {
                dgvDemarcacoes.Columns["DataPrevista"]!.HeaderText = "Prazo";
                dgvDemarcacoes.Columns["DataPrevista"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvDemarcacoes.Columns["DataConclusao"] != null)
            {
                dgvDemarcacoes.Columns["DataConclusao"]!.HeaderText = "Concluído em";
                dgvDemarcacoes.Columns["DataConclusao"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            foreach (DataGridViewRow linha in dgvDemarcacoes.Rows)
            {
                var demarcacao = (Demarcacao)linha.DataBoundItem!;

                if (demarcacao.Status == "Concluida")
                {
                    linha.DefaultCellStyle.ForeColor = EstiloVisual.TextoSecundario;
                }
                else
                {
                    int diasRestantes = (demarcacao.DataPrevista.Date - DateTime.Today).Days;
                    linha.DefaultCellStyle.ForeColor = EstiloVisual.CorPorUrgencia(diasRestantes);
                }
            }
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