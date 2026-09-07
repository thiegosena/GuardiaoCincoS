using System;
using System.IO;

namespace GuardiaoCincoS.Servicos
{
    public static class PreferenciasLogin
    {
        // Mesma pasta "Dados" ao lado do .exe que já usamos pro banco --
        // mantém tudo junto e portátil (pendrive, nuvem, etc.).
        private static readonly string _caminhoArquivo = Path.Combine(
            AppContext.BaseDirectory, "Dados", "preferencias_login.txt");

        public static void Salvar(string nomeUsuario, bool lembrar)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_caminhoArquivo)!);

            if (lembrar)
            {
                File.WriteAllText(_caminhoArquivo, nomeUsuario);
            }
            else if (File.Exists(_caminhoArquivo))
            {
                File.Delete(_caminhoArquivo);
            }
        }

        public static string? Carregar()
        {
            return File.Exists(_caminhoArquivo) ? File.ReadAllText(_caminhoArquivo).Trim() : null;
        }
    }
}