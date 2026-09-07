using System.Reflection;

namespace GuardiaoCincoS.Servicos
{
    public static class VersaoApp
    {
        public static string ObterVersaoTexto()
        {
            var versao = Assembly.GetExecutingAssembly().GetName().Version;
            return versao == null ? "v?.?.?.?" : $"v{versao.Major}.{versao.Minor}.{versao.Build}.{versao.Revision}";
        }
    }
}