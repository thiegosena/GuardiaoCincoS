using System.Net.Http;
using AutoUpdaterDotNET;
using GuardiaoCincoS.Formularios;

namespace GuardiaoCincoS.Servicos
{
    public static class AtualizacaoService
    {        
        private const string UrlArquivoAtualizacao =
            "https://raw.githubusercontent.com/thiegosena/guardiao-5s-updates/main/AutoUpdater.xml";

        public static void VerificarAtualizacoes()
        {
            AutoUpdater.RunUpdateAsAdmin = true;
            AutoUpdater.CheckForUpdateEvent += AoChecarAtualizacao;
            AutoUpdater.Start(UrlArquivoAtualizacao);
        }

        private static void AoChecarAtualizacao(UpdateInfoEventArgs args)
        {
            // Sem internet, GitHub fora do ar, XML mal formatado, etc. -- a checagem
            // de atualização nunca deve impedir o login. Falha em silêncio.
            if (args == null || args.Error != null)
                return;

            if (!args.IsUpdateAvailable)
                return;

            string changelog = BaixarTexto(args.ChangelogURL);

            var tela = new FormAtualizacaoDisponivel(
                args.InstalledVersion.ToString(),
                args.CurrentVersion,
                changelog);

            tela.ShowDialog();

            if (tela.AtualizarAgora)
            {
                AutoUpdater.DownloadUpdate(args);
            }
        }

        private static string BaixarTexto(string url)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    return cliente.GetStringAsync(url).GetAwaiter().GetResult();
                }
            }
            catch
            {
                return "(não foi possível carregar as notas desta versão)";
            }
        }
    }
}