using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Controles
{
    public partial class CartaoSecao : UserControl
    {
        private Color _corDestaque = EstiloVisual.AzulKyly;
        private readonly Label _lblTitulo;
        private readonly Panel _painelConteudo;

        public CartaoSecao()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            BackColor = EstiloVisual.FundoPagina;
            Padding = new Padding(22, 12, 16, 16);

            _lblTitulo = new Label
            {
                Dock = DockStyle.Top,
                Height = 34,
                Font = EstiloVisual.FonteSecao,
                ForeColor = EstiloVisual.AzulMarinho,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.White
            };

            _painelConteudo = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

          
            Controls.Add(_painelConteudo);
            Controls.Add(_lblTitulo);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color CorDestaque
        {
            get => _corDestaque;
            set { _corDestaque = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Titulo
        {
            get => _lblTitulo.Text;
            set => _lblTitulo.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Panel PainelConteudo => _painelConteudo;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var area = new Rectangle(0, 0, Width - 1, Height - 1);
            const int raio = 14;

            using (var caminho = CriarCaminhoArredondado(area, raio))
            {
                using (var pincelFundo = new SolidBrush(Color.White))
                    e.Graphics.FillPath(pincelFundo, caminho);

                using (var canetaBorda = new Pen(Color.FromArgb(230, 230, 230)))
                    e.Graphics.DrawPath(canetaBorda, caminho);
            }

            var barraDestaque = new Rectangle(0, 8, 6, Height - 16);
            using (var pincelDestaque = new SolidBrush(_corDestaque))
                e.Graphics.FillRectangle(pincelDestaque, barraDestaque);

            base.OnPaint(e);
        }

        private GraphicsPath CriarCaminhoArredondado(Rectangle area, int raio)
        {
            var caminho = new GraphicsPath();
            int diametro = raio * 2;

            caminho.AddArc(area.X, area.Y, diametro, diametro, 180, 90);
            caminho.AddArc(area.Right - diametro, area.Y, diametro, diametro, 270, 90);
            caminho.AddArc(area.Right - diametro, area.Bottom - diametro, diametro, diametro, 0, 90);
            caminho.AddArc(area.X, area.Bottom - diametro, diametro, diametro, 90, 90);
            caminho.CloseFigure();

            return caminho;
        }
    }
}