using GuardiaoCincoS.Controles;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;
using GuardiaoCincoS.Servicos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmColaboradores : Form
    {
        private enum ModoTela
        {
            Novo,
            Visualizacao,
            Edicao
        }

        private ModoTela _modoAtual = ModoTela.Novo;
        private int _idSelecionado = 0;
        private bool _ativoSelecionado = true;
        private List<Colaborador> _colaboradoresListaAtual = new List<Colaborador>();

        public FrmColaboradores()
        {
            InitializeComponent();
        }

        private void FrmColaboradores_Load(object sender, EventArgs e)
        {
            MontarLayout();
            CarregarGrid();
            AplicarModo(ModoTela.Novo);
        }

        private void MontarLayout()
        {
            ClientSize = new Size(900, 700);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = EstiloVisual.FundoPagina;

            var pnlCabecalho = EstiloVisual.CriarCabecalho("Cadastro de Colaboradores");

            var pnlConteudo = new Panel { Dock = DockStyle.Fill, BackColor = EstiloVisual.FundoPagina, AutoScroll = true, Padding = new Padding(20) };

            var cartaoGrid = new CartaoSecao
            {
                Titulo = "Colaboradores Cadastrados",
                CorDestaque = EstiloVisual.AzulKyly,
                Dock = DockStyle.Top,
                Height = 300,
                Margin = new Padding(0, 0, 0, 20)
            };

            dgvColaboradores.Dock = DockStyle.Fill;
            dgvColaboradores.Parent = cartaoGrid.PainelConteudo;
            EstiloVisual.ConfigurarGrid(dgvColaboradores);

            chkMostrarInativos.Dock = DockStyle.Top;
            chkMostrarInativos.Height = 18;
            chkMostrarInativos.Font = EstiloVisual.FonteTexto;
            chkMostrarInativos.Parent = cartaoGrid.PainelConteudo;

            var cartaoFormulario = new CartaoSecao
            {
                Titulo = "Dados do Colaborador",
                CorDestaque = EstiloVisual.AmareloKyly,
                Dock = DockStyle.Top,
                Height = 260
            };

            var grade = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(4)
            };
            grade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            for (int i = 0; i < grade.RowCount; i++)
                grade.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var campoNome = EstiloVisual.CriarCampo("Nome completo", txtNome);
            grade.Controls.Add(campoNome, 0, 0);
            grade.SetColumnSpan(campoNome, 2);

            grade.Controls.Add(EstiloVisual.CriarCampo("Setor", txtSetor), 0, 1);
            grade.Controls.Add(EstiloVisual.CriarCampo("Turno", cboTurno), 1, 1);

            var pnlBotoes = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true, Margin = new Padding(6, 12, 6, 0) };

            EstiloVisual.EstilizarBotao(btnNovo, "Novo", EstiloVisual.AzulKyly, Color.White);
            EstiloVisual.EstilizarBotao(btnEditar, "Editar", EstiloVisual.AmareloKyly, EstiloVisual.TextoTitulo);
            EstiloVisual.EstilizarBotao(btnCancelarEdicao, "Cancelar Edição", Color.FromArgb(210, 214, 220), EstiloVisual.TextoTitulo);
            EstiloVisual.EstilizarBotao(btnSalvar, "Salvar", EstiloVisual.Verde, Color.White);
            EstiloVisual.EstilizarBotao(btnInativar, "Inativar", EstiloVisual.Vermelho, Color.White);
            EstiloVisual.EstilizarBotao(btnReativar, "Reativar", EstiloVisual.Verde, Color.White);

            pnlBotoes.Controls.Add(btnNovo);
            pnlBotoes.Controls.Add(btnEditar);
            pnlBotoes.Controls.Add(btnCancelarEdicao);
            pnlBotoes.Controls.Add(btnSalvar);
            pnlBotoes.Controls.Add(btnInativar);
            pnlBotoes.Controls.Add(btnReativar);

            grade.Controls.Add(pnlBotoes, 0, 2);
            grade.SetColumnSpan(pnlBotoes, 2);

            cartaoFormulario.PainelConteudo.Controls.Add(grade);

            pnlConteudo.Controls.Add(cartaoFormulario);
            pnlConteudo.Controls.Add(cartaoGrid);

            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
        }

        private void CarregarGrid()
        {
            _colaboradoresListaAtual = ColaboradorDAO.Listar(apenasAtivos: !chkMostrarInativos.Checked);

            dgvColaboradores.DataSource = null;
            dgvColaboradores.DataSource = _colaboradoresListaAtual;

            if (dgvColaboradores.Columns["Id"] != null) dgvColaboradores.Columns["Id"]!.Visible = false;
            if (dgvColaboradores.Columns["Nome"] != null) dgvColaboradores.Columns["Nome"]!.HeaderText = "Nome";
            if (dgvColaboradores.Columns["Setor"] != null) dgvColaboradores.Columns["Setor"]!.HeaderText = "Setor";
            if (dgvColaboradores.Columns["Turno"] != null) dgvColaboradores.Columns["Turno"]!.HeaderText = "Turno";
            if (dgvColaboradores.Columns["Ativo"] != null) dgvColaboradores.Columns["Ativo"]!.HeaderText = "Ativo";

            foreach (DataGridViewRow linha in dgvColaboradores.Rows)
            {
                var colaborador = (Colaborador)linha.DataBoundItem!;
                if (!colaborador.Ativo)
                {
                    linha.DefaultCellStyle.ForeColor = EstiloVisual.TextoSecundario;
                }
            }
        }

        private void chkMostrarInativos_CheckedChanged(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void AplicarModo(ModoTela modo)
        {
            _modoAtual = modo;

            switch (modo)
            {
                case ModoTela.Novo:
                    LimparCampos();
                    HabilitarCamposCadastro(true);
                    btnSalvar.Text = "Salvar";
                    btnSalvar.Enabled = true;
                    btnEditar.Enabled = false;
                    btnCancelarEdicao.Enabled = false;
                    btnNovo.Enabled = false;
                    btnInativar.Enabled = false;
                    btnReativar.Enabled = false;
                    dgvColaboradores.Enabled = true;
                    break;

                case ModoTela.Visualizacao:
                    HabilitarCamposCadastro(false);
                    btnSalvar.Text = "Salvar";
                    btnSalvar.Enabled = false;
                    btnEditar.Enabled = true;
                    btnCancelarEdicao.Enabled = false;
                    btnNovo.Enabled = true;
                    btnInativar.Enabled = _ativoSelecionado;
                    btnReativar.Enabled = !_ativoSelecionado;
                    dgvColaboradores.Enabled = true;
                    break;

                case ModoTela.Edicao:
                    HabilitarCamposCadastro(true);
                    btnSalvar.Text = "Atualizar";
                    btnSalvar.Enabled = true;
                    btnEditar.Enabled = false;
                    btnCancelarEdicao.Enabled = true;
                    btnNovo.Enabled = false;
                    btnInativar.Enabled = false;
                    btnReativar.Enabled = false;
                    dgvColaboradores.Enabled = false;
                    break;
            }
        }

        private void HabilitarCamposCadastro(bool habilitado)
        {
            txtNome.Enabled = habilitado;
            txtSetor.Enabled = habilitado;
            cboTurno.Enabled = habilitado;
        }

        private void LimparCampos()
        {
            _idSelecionado = 0;
            _ativoSelecionado = true;
            txtNome.Text = "";
            txtSetor.Text = "";
            cboTurno.SelectedIndex = -1;
            txtNome.Focus();
        }

        private void PreencherCampos(Colaborador colaborador)
        {
            _idSelecionado = colaborador.Id;
            _ativoSelecionado = colaborador.Ativo;
            txtNome.Text = colaborador.Nome;
            txtSetor.Text = colaborador.Setor;
            cboTurno.Text = colaborador.Turno;
        }

        private void dgvColaboradores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var colaborador = (Colaborador)dgvColaboradores.Rows[e.RowIndex].DataBoundItem!;
            PreencherCampos(colaborador);
            AplicarModo(ModoTela.Visualizacao);
        }

        private void btnNovo_Click(object sender, EventArgs e) => AplicarModo(ModoTela.Novo);

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Selecione um colaborador na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AplicarModo(ModoTela.Edicao);
        }

        private void btnCancelarEdicao_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                AplicarModo(ModoTela.Novo);
                return;
            }

            var colaboradorOriginal = _colaboradoresListaAtual.FirstOrDefault(c => c.Id == _idSelecionado);
            if (colaboradorOriginal != null) PreencherCampos(colaboradorOriginal);
            AplicarModo(ModoTela.Visualizacao);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do colaborador.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var colaborador = new Colaborador
            {
                Id = _idSelecionado,
                Nome = txtNome.Text.Trim(),
                Setor = txtSetor.Text.Trim(),
                Turno = cboTurno.Text.Trim()
            };

            if (_modoAtual == ModoTela.Edicao)
            {
                ColaboradorDAO.Atualizar(colaborador);
                MessageBox.Show("Colaborador atualizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ColaboradorDAO.Inserir(colaborador);
                MessageBox.Show("Colaborador cadastrado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CarregarGrid();
            AplicarModo(ModoTela.Novo);
        }

        private void btnInativar_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Selecione um colaborador na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacao = MessageBox.Show(
                "Inativar este colaborador? Ele sai das listas, mas o histórico é mantido.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                ColaboradorDAO.Inativar(_idSelecionado);
                CarregarGrid();
                AplicarModo(ModoTela.Novo);
            }
        }

        private void btnReativar_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Selecione um colaborador na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ColaboradorDAO.Reativar(_idSelecionado);
            CarregarGrid();
            AplicarModo(ModoTela.Novo);
            MessageBox.Show("Colaborador reativado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}