using System.Drawing;
using System.Windows.Forms;

namespace GuardiaoCincoS.Formularios
{
    // Janela preta semi-transparente, cobrindo a tela inteira, mostrada atrás
    // do FrmLogin -- dá a sensação de "modal escurecido" e evita cliques
    // acidentais nas outras janelas do próprio Guardião 5S enquanto o login
    // está aberto. Não tem controles nem lógica nenhuma, só existe pra ficar
    // de pano de fundo.
    public class FrmOverlayEscuro : Form
    {
        public FrmOverlayEscuro()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            Bounds = Screen.PrimaryScreen!.Bounds;
            BackColor = Color.Black;
            Opacity = 0.85; // "leve" transparência -- ajuste esse número se quiser mais ou menos escuro
            ShowInTaskbar = false;
        }
    }
}