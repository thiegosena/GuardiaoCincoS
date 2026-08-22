using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Controles
{
    public partial class CtrlDashboard : UserControl
    {
        private CartaoSecao? _cartaoEscala5S;
        private Label? _lblValorEscala5S;

        private CartaoSecao? _cartaoRondas;
        private Label? _lblValorRondas;

        private CartaoSecao? _cartaoOnboarding;
        private Label? _lblValorOnboarding;

        private DataGridView? dgvProximosEventos;

        public CtrlDashboard()
        {
            InitializeComponent();
            MontarPainelDireito();
            AplicarEstiloInicial();
        }

        private void MontarPainelDireito()
        {
            var painelDireito = splitCorpo.Panel2;
            painelDireito.BackColor = EstiloVisual.FundoPagina;
            painelDireito.AutoScroll = true;

            const int alturaEspacador = 16;

            // ===== Próximo Onboarding =====
            _cartaoOnboarding = new CartaoSecao
            {
                Titulo = "Próximo Onboarding",
                CorDestaque = EstiloVisual.Verde,
                Dock = DockStyle.Top,
                Height = 130
            };
            _lblValorOnboarding = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft,
                Font = EstiloVisual.FonteTexto,
                ForeColor = EstiloVisual.TextoTitulo,
                BackColor = Color.White
            };
            _cartaoOnboarding.PainelConteudo.Controls.Add(_lblValorOnboarding);

            // ===== Rondas =====
            _cartaoRondas = new CartaoSecao
            {
                Titulo = "Rondas",
                CorDestaque = EstiloVisual.AmareloKyly,
                Dock = DockStyle.Top,
                Height = 190
            };
            _lblValorRondas = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft,
                Font = EstiloVisual.FonteTexto,
                ForeColor = EstiloVisual.TextoTitulo,
                BackColor = Color.White
            };
            _cartaoRondas.PainelConteudo.Controls.Add(_lblValorRondas);

            // ===== Escala 5S Semanal =====
            _cartaoEscala5S = new CartaoSecao
            {
                Titulo = "Escala 5S Semanal",
                CorDestaque = EstiloVisual.AzulKyly,
                Dock = DockStyle.Top,
                Height = 170
            };
            _lblValorEscala5S = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft,
                Font = EstiloVisual.FonteTexto,
                ForeColor = EstiloVisual.TextoTitulo,
                BackColor = Color.White
            };
            _cartaoEscala5S.PainelConteudo.Controls.Add(_lblValorEscala5S);

            // ===== Próximos Eventos =====
            var cartaoEventos = new CartaoSecao
            {
                Titulo = "Próximos Eventos",
                CorDestaque = EstiloVisual.AzulMarinho,
                Dock = DockStyle.Fill
            };
            dgvProximosEventos = new DataGridView { Dock = DockStyle.Fill };
            cartaoEventos.PainelConteudo.Controls.Add(dgvProximosEventos);


            var espacador1 = new Panel { Dock = DockStyle.Top, Height = alturaEspacador, BackColor = EstiloVisual.FundoPagina };
            var espacador2 = new Panel { Dock = DockStyle.Top, Height = alturaEspacador, BackColor = EstiloVisual.FundoPagina };
            var espacador3 = new Panel { Dock = DockStyle.Top, Height = alturaEspacador, BackColor = EstiloVisual.FundoPagina };


            painelDireito.Controls.Add(cartaoEventos);
            painelDireito.Controls.Add(espacador3);
            painelDireito.Controls.Add(_cartaoOnboarding);
            painelDireito.Controls.Add(espacador2);
            painelDireito.Controls.Add(_cartaoRondas);
            painelDireito.Controls.Add(espacador1);
            painelDireito.Controls.Add(_cartaoEscala5S);
        }

        private void AplicarEstiloInicial()
        {
            BackColor = EstiloVisual.FundoPagina;

            lblSaudacao.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSaudacao.ForeColor = Color.White;

            lblDataHora.Font = EstiloVisual.FonteTexto;
            lblDataHora.ForeColor = Color.FromArgb(200, 210, 225);

            btnAtualizarDashboard.FlatStyle = FlatStyle.Flat;
            btnAtualizarDashboard.FlatAppearance.BorderSize = 0;
            btnAtualizarDashboard.BackColor = Color.White;
            btnAtualizarDashboard.ForeColor = EstiloVisual.AzulMarinho;
            btnAtualizarDashboard.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            btnExportarPdf.FlatStyle = FlatStyle.Flat;
            btnExportarPdf.FlatAppearance.BorderSize = 0;
            btnExportarPdf.BackColor = Color.White;
            btnExportarPdf.ForeColor = EstiloVisual.AzulMarinho;
            btnExportarPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            btnWhatsApp.FlatStyle = FlatStyle.Flat;
            btnWhatsApp.FlatAppearance.BorderSize = 0;
            btnWhatsApp.BackColor = EstiloVisual.Verde;
            btnWhatsApp.ForeColor = Color.White;
            btnWhatsApp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            lblTituloPendencias.Font = EstiloVisual.FonteSecao;
            lblTituloPendencias.ForeColor = EstiloVisual.AzulMarinho;

            ConfigurarGrid(dgvPendencias);
            ConfigurarGrid(dgvProximosEventos!);
        }

        private void ConfigurarGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = EstiloVisual.FundoPagina;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = EstiloVisual.TextoTitulo;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 235, 250);
            grid.DefaultCellStyle.SelectionForeColor = EstiloVisual.TextoTitulo;
            grid.DefaultCellStyle.Font = EstiloVisual.FonteTexto;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowTemplate.Height = 28;
        }

        public void CarregarDados()
        {
            lblSaudacao.Text = $"Bem-vindo, {Sessao.NomeCompleto}!";
            AtualizarRelogio();

            CarregarCards();
            CarregarEscala5S();
            CarregarRondas();
            CarregarProximoOnboarding();
            CarregarPendencias();
            CarregarProximosEventos();
        }

        private void AtualizarRelogio()
        {
            lblDataHora.Text = DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy - HH:mm:ss",
                new CultureInfo("pt-BR"));
        }

        private void tmrRelogio_Tick(object sender, EventArgs e)
        {
            AtualizarRelogio();
        }

        private void CarregarCards()
        {
            flpCards.Controls.Clear();

            var pendencias = PendenciaDAO.ListarConsolidado();
            int atrasadas = pendencias.FindAll(p => p.DiasRestantes < 0).Count;

            int demarcacoesPendentes = DemarcacaoDAO.Listar(apenasPendentes: true).Count;
            int rondasPendentes = RondaDAO.Listar(apenasPendentes: true).Count;
            int onboardingsEmAndamento = OnboardingDAO.ContarEmAndamento();

            flpCards.Controls.Add(CriarCard(rondasPendentes.ToString(), "Rondas Pendentes", EstiloVisual.AzulKyly));
            flpCards.Controls.Add(CriarCard(demarcacoesPendentes.ToString(), "Demarcações Pendentes", EstiloVisual.AmareloKyly));
            flpCards.Controls.Add(CriarCard(atrasadas.ToString(), "Pendências Atrasadas", EstiloVisual.Vermelho));
            flpCards.Controls.Add(CriarCard(onboardingsEmAndamento.ToString(), "Onboardings em Andamento", EstiloVisual.Verde));
        }

        private CardIndicador CriarCard(string numero, string titulo, Color corDestaque)
        {
            return new CardIndicador
            {
                Numero = numero,
                Titulo = titulo,
                CorDestaque = corDestaque,
                Width = 210,
                Height = 110,
                Margin = new Padding(0, 0, 16, 16)
            };
        }

        private void CarregarEscala5S()
        {
            DateTime inicioSemana = UtilData.ObterSegundaFeira(DateTime.Today);
            DateTime fimSemana = inicioSemana.AddDays(6);

            var colaboradoresNaEscala = EscalaDAO.ListarDisponiveisParaRonda(inicioSemana);

            string nomes = colaboradoresNaEscala.Count == 0
                ? "Nenhum colaborador escalado nesta semana."
                : string.Join(", ", colaboradoresNaEscala.Select(c => c.Nome));

            _lblValorEscala5S!.Text = $"Semana de {inicioSemana:dd/MM} a {fimSemana:dd/MM}\n\n{nomes}";
        }

        private void CarregarRondas()
        {
            var ultima = RondaDAO.ObterUltimaConcluida();
            var proxima = RondaDAO.ObterProximaPendente();

            string textoUltima = ultima == null
                ? "Nenhuma ronda concluída ainda."
                : $"{ultima.Tipo} - {ultima.NomeColaboradorResponsavel}, em {ultima.DataHoraConclusao:dd/MM/yyyy HH:mm}";

            string textoProxima = proxima == null
                ? "Nenhuma ronda pendente no momento."
                : $"{proxima.Tipo} - {proxima.NomeColaboradorResponsavel}, prevista para {proxima.Data:dd/MM/yyyy}";

            _lblValorRondas!.Text = $"Última ronda concluída:\n{textoUltima}\n\nPróxima ronda pendente:\n{textoProxima}";
        }

        private void CarregarProximoOnboarding()
        {
            var proximo = OnboardingDAO.ObterProximoAgendado();

            _lblValorOnboarding!.Text = proximo == null
                ? "Nenhum onboarding agendado."
                : $"{proximo.NomeColaborador}\nAgendado para {proximo.DataInicio:dd/MM/yyyy}";
        }

        private void CarregarPendencias()
        {
            var pendencias = PendenciaDAO.ListarConsolidado();

            dgvPendencias.DataSource = null;
            dgvPendencias.DataSource = pendencias;

            if (dgvPendencias.Columns["Origem"] != null) dgvPendencias.Columns["Origem"]!.HeaderText = "Tipo";
            if (dgvPendencias.Columns["LocalOuSetor"] != null) dgvPendencias.Columns["LocalOuSetor"]!.HeaderText = "Local/Setor";
            if (dgvPendencias.Columns["Descricao"] != null) dgvPendencias.Columns["Descricao"]!.HeaderText = "Descrição";
            if (dgvPendencias.Columns["SituacaoTexto"] != null) dgvPendencias.Columns["SituacaoTexto"]!.HeaderText = "Situação";
            if (dgvPendencias.Columns["DiasRestantes"] != null) dgvPendencias.Columns["DiasRestantes"]!.Visible = false;
            if (dgvPendencias.Columns["Prazo"] != null)
            {
                dgvPendencias.Columns["Prazo"]!.HeaderText = "Prazo";
                dgvPendencias.Columns["Prazo"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            foreach (DataGridViewRow linha in dgvPendencias.Rows)
            {
                var item = (ItemPendencia)linha.DataBoundItem!;
                linha.DefaultCellStyle.ForeColor = EstiloVisual.CorPorUrgencia(item.DiasRestantes);
            }
        }

        private void CarregarProximosEventos()
        {
            var eventos = EventoCalendarioDAO.ListarProximos(14);

            dgvProximosEventos!.DataSource = null;
            dgvProximosEventos.DataSource = eventos;

            if (dgvProximosEventos.Columns["Id"] != null) dgvProximosEventos.Columns["Id"]!.Visible = false;
            if (dgvProximosEventos.Columns["IdColaboradorResponsavel"] != null) dgvProximosEventos.Columns["IdColaboradorResponsavel"]!.Visible = false;
            if (dgvProximosEventos.Columns["Descricao"] != null) dgvProximosEventos.Columns["Descricao"]!.Visible = false;
            if (dgvProximosEventos.Columns["Status"] != null) dgvProximosEventos.Columns["Status"]!.Visible = false;
            if (dgvProximosEventos.Columns["Local"] != null) dgvProximosEventos.Columns["Local"]!.Visible = false;
            if (dgvProximosEventos.Columns["NomeResponsavel"] != null) dgvProximosEventos.Columns["NomeResponsavel"]!.Visible = false;
            if (dgvProximosEventos.Columns["Titulo"] != null) dgvProximosEventos.Columns["Titulo"]!.HeaderText = "Evento";
            if (dgvProximosEventos.Columns["Tipo"] != null) dgvProximosEventos.Columns["Tipo"]!.HeaderText = "Tipo";
            if (dgvProximosEventos.Columns["DataInicio"] != null)
            {
                dgvProximosEventos.Columns["DataInicio"]!.HeaderText = "Início";
                dgvProximosEventos.Columns["DataInicio"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvProximosEventos.Columns["DataFim"] != null)
            {
                dgvProximosEventos.Columns["DataFim"]!.HeaderText = "Fim";
                dgvProximosEventos.Columns["DataFim"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void btnAtualizarDashboard_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                var pendencias = PendenciaDAO.ListarConsolidado();
                string caminhoArquivo = RelatorioPdfService.GerarRelatorioPendencias(pendencias);

                try
                {
                    RelatorioPdfService.AbrirArquivo(caminhoArquivo);
                }
                catch
                {
                    MessageBox.Show(
                        $"PDF gerado com sucesso em:\n{caminhoArquivo}\n\n(Não foi possível abrir automaticamente — abra o arquivo manualmente.)",
                        "PDF Gerado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível gerar o PDF: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWhatsApp_Click(object sender, EventArgs e)
        {
            try
            {
                var pendencias = PendenciaDAO.ListarConsolidado();
                WhatsAppService.EnviarResumoPendencias(pendencias);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o WhatsApp: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}