using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GuardiaoCincoS.Servicos;
using System.ComponentModel;

namespace GuardiaoCincoS.Controles
{
    public partial class CardIndicador : UserControl
    {
        private Color _corDestaque = EstiloVisual.AzulKyly;

        public CardIndicador()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            BackColor = EstiloVisual.FundoPagina;
            lblNumero.BackColor = Color.Transparent;
            lblTitulo.BackColor = Color.Transparent;
            lblNumero.Font = EstiloVisual.FonteNumeroCard;
            lblTitulo.Font = EstiloVisual.FonteLabelCard;
            lblNumero.ForeColor = EstiloVisual.TextoTitulo;
            lblTitulo.ForeColor = EstiloVisual.TextoSecundario;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color CorDestaque
        {
            get => _corDestaque;
            set { _corDestaque = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Numero
        {
            get => lblNumero.Text;
            set => lblNumero.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Titulo
        {
            get => lblTitulo.Text;
            set => lblTitulo.Text = value;
        }

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