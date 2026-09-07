using System.Drawing;
using System.Windows.Forms;

namespace GuardiaoCincoS.Servicos
{
    public static class EstiloVisual
    {
        public static readonly Color AzulMarinho = Color.FromArgb(27, 42, 74);
        public static readonly Color AzulKyly = Color.FromArgb(46, 90, 172);
        public static readonly Color AmareloKyly = Color.FromArgb(255, 193, 7);
        public static readonly Color FundoPagina = Color.FromArgb(244, 246, 249);
        public static readonly Color TextoTitulo = Color.FromArgb(33, 37, 41);
        public static readonly Color TextoSecundario = Color.FromArgb(108, 117, 125);
        public static readonly Color Verde = Color.FromArgb(40, 167, 69);
        public static readonly Color Laranja = Color.FromArgb(253, 126, 20);
        public static readonly Color Vermelho = Color.FromArgb(220, 53, 69);

        public static readonly Font FonteNumeroCard = new Font("Segoe UI", 26F, FontStyle.Bold);
        public static readonly Font FonteLabelCard = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Font FonteSecao = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font FonteTexto = new Font("Segoe UI", 9.5F, FontStyle.Regular);

        public static Color CorPorUrgencia(int diasRestantes)
        {
            if (diasRestantes < 0) return Vermelho;
            if (diasRestantes <= 3) return Laranja;
            return Verde;
        }

        public static void ConfigurarGrid(DataGridView grid, bool somenteLeitura = true)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.ReadOnly = somenteLeitura;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = FundoPagina;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextoTitulo;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 235, 250);
            grid.DefaultCellStyle.SelectionForeColor = TextoTitulo;
            grid.DefaultCellStyle.Font = FonteTexto;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowTemplate.Height = 28;
        }

        // Faixa azul marinho com título branco -- topo de todo formulário do "molde novo".
        public static Panel CriarCabecalho(string titulo)
        {
            var painel = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = AzulMarinho };
            var label = new Label
            {
                Text = titulo,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(24, 0, 0, 0)
            };
            painel.Controls.Add(label);
            return painel;
        }

        // Envolve um controle já existente (TextBox, ComboBox, DateTimePicker...) com
        // um rótulo pequeno em negrito acima -- o padrão de campo do "molde novo".
        public static Panel CriarCampo(string rotulo, Control campo)
        {
            var painel = new Panel { Dock = DockStyle.Fill, Margin = new Padding(6), Height = 60 };

            var label = new Label
            {
                Text = rotulo,
                Dock = DockStyle.Top,
                Height = 20,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = TextoSecundario
            };

            campo.Dock = DockStyle.Top;
            campo.Font = new Font("Segoe UI", 10F);
            if (campo is TextBox caixaTexto) caixaTexto.BorderStyle = BorderStyle.FixedSingle;

            painel.Controls.Add(campo);
            painel.Controls.Add(label);

            return painel;
        }

        // Igual ao CriarCampo, mas para campos multilinha (observações), onde você
        // escolhe a altura do campo de texto em pixels.
        public static Panel CriarCampoMultilinha(string rotulo, Control campo, int alturaCampo)
        {
            campo.Height = alturaCampo;
            var painel = new Panel { Dock = DockStyle.Fill, Margin = new Padding(6), Height = alturaCampo + 26 };

            var label = new Label
            {
                Text = rotulo,
                Dock = DockStyle.Top,
                Height = 20,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = TextoSecundario
            };

            campo.Dock = DockStyle.Top;
            campo.Font = new Font("Segoe UI", 10F);

            painel.Controls.Add(campo);
            painel.Controls.Add(label);

            return painel;
        }

        // Título de subseção em negrito azul marinho, para separar blocos dentro
        // de um card (ex: "Checklist 5S", "Placas Provisórias").
        public static Label CriarTituloSubsecao(string texto)
        {
            return new Label
            {
                Text = texto,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = AzulMarinho,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(6, 10, 6, 4)
            };
        }

        public static void EstilizarBotao(Button botao, string texto, Color corFundo, Color corTexto)
        {
            botao.Text = texto;
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 0;
            botao.BackColor = corFundo;
            botao.ForeColor = corTexto;
            botao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            botao.Size = new Size(120, 34);
            botao.Margin = new Padding(0, 0, 10, 0);
        }
    }
}