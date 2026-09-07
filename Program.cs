using System;
using System.Windows.Forms;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Formularios;

namespace GuardiaoCincoS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Cria o arquivo do banco (se ainda não existir) antes de mostrar qualquer tela.
            ConexaoBanco.GarantirBancoCriado();

            bool continuarExecutando = true;

            while (continuarExecutando)
            {
                DialogResult resultadoLogin;

                // A cortina preta só existe durante a tela de Login -- o "using"
                // garante que ela desaparece sozinha assim que o login fecha,
                // seja com sucesso ou não.
                using (var overlay = new FrmOverlayEscuro())
                {
                    overlay.Show();

                    using (var frmLogin = new FrmLogin())
                    {
                        resultadoLogin = frmLogin.ShowDialog(overlay);
                    }
                }

                if (resultadoLogin != DialogResult.OK)
                {
                    continuarExecutando = false;
                    continue;
                }

                using (var frmPrincipal = new FrmPrincipal())
                {
                    frmPrincipal.ShowDialog();
                    continuarExecutando = frmPrincipal.SolicitarNovoLogin;
                }
            }
        }
    }
}