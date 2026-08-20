using System.Drawing;

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
    }
}