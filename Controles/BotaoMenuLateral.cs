using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Controles
{
    public partial class BotaoMenuLateral : UserControl
    {
        private bool _selecionado;
        private bool _mouseEmCima;
        private string _texto = string.Empty;
        private bool _indentado;
        private bool _temSeta;
        private bool _setaAberta;

        public event EventHandler? Clicado;

        public BotaoMenuLateral()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                      ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Height = 44;
            Cursor = Cursors.Hand;
            BackColor = EstiloVisual.AzulMarinho;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Texto
        {
            get => _texto;
            set { _texto = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Indentado
        {
            get => _indentado;
            set { _indentado = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool TemSeta
        {
            get => _temSeta;
            set { _temSeta = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SetaAberta
        {
            get => _setaAberta;
            set { _setaAberta = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Selecionado
        {
            get => _selecionado;
            set { _selecionado = value; Invalidate(); }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _mouseEmCima = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _mouseEmCima = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnClick(EventArgs e)
        {
            Clicado?.Invoke(this, EventArgs.Empty);
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color corFundo = _selecionado
                ? EstiloVisual.AzulKyly
                : (_mouseEmCima ? Color.FromArgb(38, 56, 94) : EstiloVisual.AzulMarinho);

            using (var pincelFundo = new SolidBrush(corFundo))
                e.Graphics.FillRectangle(pincelFundo, ClientRectangle);

            if (_selecionado)
            {
                using (var pincelDestaque = new SolidBrush(EstiloVisual.AmareloKyly))
                    e.Graphics.FillRectangle(pincelDestaque, new Rectangle(0, 0, 4, Height));
            }

            int posX = _indentado ? 48 : 20;
            int larguraDisponivel = Width - posX - 24;

            using (var fonteTexto = new Font("Segoe UI", _indentado ? 9.5F : 10F, _indentado ? FontStyle.Regular : FontStyle.Bold))
            using (var pincelTexto = new SolidBrush(Color.White))
            {
                var formato = new StringFormat { LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(_texto, fonteTexto, pincelTexto, new RectangleF(posX, 0, larguraDisponivel, Height), formato);
            }

            if (_temSeta)
            {
                string seta = _setaAberta ? "▾" : "▸";
                using (var fonteSeta = new Font("Segoe UI", 10F, FontStyle.Bold))
                using (var pincelSeta = new SolidBrush(Color.White))
                {
                    var formatoSeta = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Far };
                    e.Graphics.DrawString(seta, fonteSeta, pincelSeta, new RectangleF(0, 0, Width - 16, Height), formatoSeta);
                }
            }

            base.OnPaint(e);
        }
    }
}