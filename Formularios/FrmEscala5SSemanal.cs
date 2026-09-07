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
    public partial class FrmEscala5SSemanal : Form
    {
        private List<Colaborador> _todosColaboradores = new List<Colaborador>();
        private Label _lblContagemSelecionados = new Label();

        public FrmEscala5SSemanal()
        {
            InitializeComponent();
        }

        private void FrmEscala5SSemanal_Load(object sender, EventArgs e)
        {
            MontarLayout();

            dtpInicioSemana.Value = UtilData.ObterSegundaFeira(DateTime.Today);
            CarregarSemana();
        }

        private void MontarLayout()
        {
            ClientSize = new Size(700, 650);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = EstiloVisual.FundoPagina;

            var pnlCabecalho = EstiloVisual.CriarCabecalho("Escala 5S Semanal");

            var pnlConteudo = new Panel { Dock = DockStyle.Fill, BackColor = EstiloVisual.FundoPagina, Padding = new Padding(20) };

            // ===== Card 1: período =====
            var cartaoPeriodo = new CartaoSecao
            {
                Titulo = "Período da Escala",
                CorDestaque = EstiloVisual.AzulKyly,
                Dock = DockStyle.Top,
                Height = 140,
                Margin = new Padding(0, 0, 0, 20)
            };

            var linhaPeriodo = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 3, RowCount = 1 };
            linhaPeriodo.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            linhaPeriodo.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            linhaPeriodo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            var campoInicio = EstiloVisual.CriarCampo("Início da semana", dtpInicioSemana);
            campoInicio.Width = 220;
            linhaPeriodo.Controls.Add(campoInicio, 0, 0);

            lblFimSemana.AutoSize = true;
            lblFimSemana.Font = new Font("Segoe UI", 10F);
            lblFimSemana.ForeColor = EstiloVisual.TextoSecundario;
            lblFimSemana.Margin = new Padding(16, 34, 16, 0);
            linhaPeriodo.Controls.Add(lblFimSemana, 1, 0);

            var pnlBotaoCarregar = new FlowLayoutPanel { AutoSize = true, Margin = new Padding(0, 28, 0, 0) };
            EstiloVisual.EstilizarBotao(btnCarregarSemana, "Carregar", EstiloVisual.AzulKyly, Color.White);
            pnlBotaoCarregar.Controls.Add(btnCarregarSemana);
            linhaPeriodo.Controls.Add(pnlBotaoCarregar, 2, 0);

            cartaoPeriodo.PainelConteudo.Controls.Add(linhaPeriodo);

            // ===== Card 2: lista de colaboradores =====
            var cartaoLista = new CartaoSecao
            {
                Titulo = "Colaboradores da Semana",
                CorDestaque = EstiloVisual.Verde,
                Dock = DockStyle.Fill
            };

            clbColaboradores.Dock = DockStyle.Fill;
            clbColaboradores.BorderStyle = BorderStyle.None;
            clbColaboradores.BackColor = Color.White;
            clbColaboradores.Font = EstiloVisual.FonteTexto;
            clbColaboradores.CheckOnClick = true;
            clbColaboradores.ItemCheck += ClbColaboradores_ItemCheck;
            cartaoLista.PainelConteudo.Controls.Add(clbColaboradores);

            var pnlRodapeLista = new TableLayoutPanel { Dock = DockStyle.Bottom, Height = 66, ColumnCount = 2 };
            pnlRodapeLista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlRodapeLista.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            _lblContagemSelecionados = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = EstiloVisual.FonteTexto,
                ForeColor = EstiloVisual.TextoSecundario
            };
            pnlRodapeLista.Controls.Add(_lblContagemSelecionados, 0, 0);

            var flpBotaoSalvar = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
            EstiloVisual.EstilizarBotao(btnSalvarEscala, "Salvar Escala", EstiloVisual.Verde, Color.White);
            flpBotaoSalvar.Controls.Add(btnSalvarEscala);
            pnlRodapeLista.Controls.Add(flpBotaoSalvar, 1, 0);

            cartaoLista.PainelConteudo.Controls.Add(pnlRodapeLista);

            // Ordem de adição = inverso da ordem visual desejada (Período em cima, Lista embaixo).
            pnlConteudo.Controls.Add(cartaoLista);
            pnlConteudo.Controls.Add(cartaoPeriodo);

            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
        }

        private void CarregarSemana()
        {
            DateTime inicio = dtpInicioSemana.Value.Date;
            DateTime fim = inicio.AddDays(6);
            lblFimSemana.Text = $"até {fim:dd/MM/yyyy}";

            _todosColaboradores = ColaboradorDAO.Listar();
            var idsNaEscala = EscalaDAO.ListarDisponiveisParaRonda(inicio).Select(c => c.Id).ToHashSet();

            clbColaboradores.Items.Clear();
            foreach (var colaborador in _todosColaboradores)
            {
                clbColaboradores.Items.Add(colaborador.Nome, idsNaEscala.Contains(colaborador.Id));
            }

            AtualizarContagemSelecionados();
        }

        // O ItemCheck dispara ANTES do estado do item ser efetivamente atualizado --
        // por isso o BeginInvoke, que empurra a atualização da contagem pra rodar
        // logo depois, já com o novo estado aplicado.
        private void ClbColaboradores_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new Action(AtualizarContagemSelecionados));
        }

        private void AtualizarContagemSelecionados()
        {
            int selecionados = clbColaboradores.CheckedItems.Count;
            _lblContagemSelecionados.Text = $"{selecionados} de {clbColaboradores.Items.Count} colaborador(es) selecionado(s)";
        }

        private void btnCarregarSemana_Click(object sender, EventArgs e) => CarregarSemana();

        private void btnSalvarEscala_Click(object sender, EventArgs e)
        {
            DateTime inicio = dtpInicioSemana.Value.Date;
            DateTime fim = inicio.AddDays(6);

            var idsSelecionados = new List<int>();
            for (int i = 0; i < clbColaboradores.Items.Count; i++)
            {
                if (clbColaboradores.GetItemChecked(i))
                    idsSelecionados.Add(_todosColaboradores[i].Id);
            }

            EscalaDAO.SalvarEscala(inicio, fim, idsSelecionados);
            MessageBox.Show("Escala 5S da semana salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}