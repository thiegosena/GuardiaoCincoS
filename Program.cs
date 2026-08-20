using System;
using System.Windows.Forms;
using GuardiaoCincoS.Formularios;

namespace GuardiaoCincoS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            bool continuarExecutando = true;

            while (continuarExecutando)
            {
                DialogResult resultadoLogin;
                using (var frmLogin = new FrmLogin())
                {
                    resultadoLogin = frmLogin.ShowDialog();
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