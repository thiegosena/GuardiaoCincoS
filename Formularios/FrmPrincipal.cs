using System;
using System.Drawing;
using System.Windows.Forms;
using GuardiaoCincoS.Controles;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmPrincipal : Form
    {
        private CtrlDashboard? _ctrlDashboard;
        private FlowLayoutPanel? _flpMenu;
        private BotaoMenuLateral? _botaoCadastros;
        private Panel? _pnlSubCadastros;
        private bool _cadastrosExpandido;

        private Panel? pnlConteudo;
        private Panel? pnlSidebar;
        private PictureBox? _picLogo;
        
        public bool SolicitarNovoLogin { get; private set; } = false;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            MontarLayoutBase();
            MontarSidebar();

            _ctrlDashboard = new CtrlDashboard { Dock = DockStyle.Fill };
            pnlConteudo!.Controls.Add(_ctrlDashboard);
            _ctrlDashboard.CarregarDados();
        }

        private void MontarLayoutBase()
        {
            pnlConteudo = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = EstiloVisual.FundoPagina
            };
            Controls.Add(pnlConteudo);

            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 240,
                BackColor = EstiloVisual.AzulMarinho
            };
            Controls.Add(pnlSidebar);
        }

        private void MontarSidebar()
        {
            // --- Cabeçalho com a logo ---
            var pnlMarca = new Panel { Dock = DockStyle.Top, Height = 76, BackColor = EstiloVisual.AzulMarinho };

            _picLogo = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(16, 18),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Image = Image.FromFile(@"D:\Pictures\Arquetipos\Guerreiro.jpg")
            };

            var lblMarca = new Label
            {
                Text = "GUARDIÃO 5S",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                Location = new Point(64, 0),
                Size = new Size(164, 76),
                TextAlign = ContentAlignment.MiddleLeft
            };

            pnlMarca.Controls.Add(lblMarca);
            pnlMarca.Controls.Add(_picLogo);

            // --- Área rolável com os itens de menu ---
            _flpMenu = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = EstiloVisual.AzulMarinho,
                Padding = new Padding(0, 12, 0, 12)
            };

            var botaoInicio = AdicionarItemMenu("Início", indentado: false, aoClicar: AbrirDashboard);
            botaoInicio.Selecionado = true;

            if (Sessao.NomePerfil != "Colaborador")
            {
                _botaoCadastros = AdicionarItemMenu("Cadastros", indentado: false, aoClicar: AlternarSubmenuCadastros, temSeta: true);

                _pnlSubCadastros = new Panel
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Width = 240,
                    Visible = false
                };
                var flpSub = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Width = 240
                };
                flpSub.Controls.Add(CriarBotao("Colaboradores", indentado: true, aoClicar: () => AbrirFormulario(new FrmColaboradores())));
                flpSub.Controls.Add(CriarBotao("Escala 5S Semanal", indentado: true, aoClicar: () => AbrirFormulario(new FrmEscala5SSemanal())));

                if (Sessao.NomePerfil == "Administrador")
                {
                    flpSub.Controls.Add(CriarBotao("Usuários", indentado: true, aoClicar: () => AbrirFormularioSemAtualizarDashboard(new FrmUsuarios())));
                }

                _pnlSubCadastros.Controls.Add(flpSub);
                _flpMenu.Controls.Add(_pnlSubCadastros);
            }

            AdicionarItemMenu("Rondas", indentado: false, aoClicar: () => AbrirFormulario(new FrmRondas()));
            AdicionarItemMenu("Auditorias", indentado: false, aoClicar: () => AbrirFormulario(new FrmAuditorias()));
            AdicionarItemMenu("Demarcações", indentado: false, aoClicar: () => AbrirFormulario(new FrmDemarcacoes()));
            AdicionarItemMenu("Onboarding", indentado: false, aoClicar: () => AbrirFormulario(new FrmOnboarding()));
            AdicionarItemMenu("Materiais", indentado: false, aoClicar: () => AbrirFormularioSemAtualizarDashboard(new FrmMateriais()));
            AdicionarItemMenu("Calendário de Eventos", indentado: false, aoClicar: () => AbrirFormulario(new FrmCalendarioEventos()));

            // --- Rodapé: usuário logado + Deslogar/Sair lado a lado ---
            var pnlRodape = new Panel { Dock = DockStyle.Bottom, Height = 100, BackColor = Color.FromArgb(20, 32, 58) };

            var lblNomeUsuarioRodape = new Label
            {
                Text = Sessao.NomeCompleto,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Location = new Point(20, 12),
                Size = new Size(200, 18)
            };
            var lblPerfilRodape = new Label
            {
                Text = Sessao.NomePerfil,
                ForeColor = Color.FromArgb(180, 190, 210),
                Font = new Font("Segoe UI", 8.5F),
                Location = new Point(20, 32),
                Size = new Size(200, 16)
            };

            var btnDeslogar = new Button
            {
                Text = "Deslogar",
                Location = new Point(20, 56),
                Size = new Size(96, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = EstiloVisual.AzulKyly,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
            };
            btnDeslogar.FlatAppearance.BorderSize = 0;
            btnDeslogar.Click += BtnDeslogar_Click;

            var btnSair = new Button
            {
                Text = "Sair",
                Location = new Point(124, 56),
                Size = new Size(96, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = EstiloVisual.Vermelho,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
            };
            btnSair.FlatAppearance.BorderSize = 0;
            btnSair.Click += BtnSair_Click;

            pnlRodape.Controls.Add(btnDeslogar);
            pnlRodape.Controls.Add(btnSair);
            pnlRodape.Controls.Add(lblPerfilRodape);
            pnlRodape.Controls.Add(lblNomeUsuarioRodape);

            pnlSidebar!.Controls.Add(_flpMenu);
            pnlSidebar.Controls.Add(pnlRodape);
            pnlSidebar.Controls.Add(pnlMarca);
        }

        private BotaoMenuLateral AdicionarItemMenu(string texto, bool indentado, Action aoClicar, bool temSeta = false)
        {
            var botao = CriarBotao(texto, indentado, aoClicar, temSeta);
            _flpMenu!.Controls.Add(botao);
            return botao;
        }

        private BotaoMenuLateral CriarBotao(string texto, bool indentado, Action aoClicar, bool temSeta = false)
        {
            var botao = new BotaoMenuLateral
            {
                Texto = texto,
                Indentado = indentado,
                TemSeta = temSeta,
                Width = 240,
                Height = indentado ? 38 : 44
            };
            botao.Clicado += (s, e) => aoClicar();
            return botao;
        }

        private void AlternarSubmenuCadastros()
        {
            if (_pnlSubCadastros == null || _botaoCadastros == null) return;

            _cadastrosExpandido = !_cadastrosExpandido;
            _pnlSubCadastros.Visible = _cadastrosExpandido;
            _botaoCadastros.SetaAberta = _cadastrosExpandido;
        }

        private void AbrirDashboard()
        {
            _ctrlDashboard?.CarregarDados();
        }

        private void AbrirFormulario(Form formulario)
        {
            formulario.ShowDialog();
            _ctrlDashboard?.CarregarDados();
        }

        private void AbrirFormularioSemAtualizarDashboard(Form formulario)
        {
            formulario.ShowDialog();
        }

        private void BtnDeslogar_Click(object? sender, EventArgs e)
        {
            var confirmacao = MessageBox.Show(
                "Deseja realmente deslogar e voltar para a tela de login?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                SolicitarNovoLogin = true;
                Sessao.Encerrar();
                Close();
            }
        }

        private void BtnSair_Click(object? sender, EventArgs e)
        {
            var confirmacao = MessageBox.Show(
                "Deseja realmente sair do sistema?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                SolicitarNovoLogin = false;
                Sessao.Encerrar();
                Close();
            }
        }
    }
}