using System;
using System.Security.Cryptography;
using System.Text;

namespace GuardiaoCincoS.Servicos
{
    public static class SegurancaSenha
    {
        public static string GerarSalt()
        {
            byte[] bytesAleatorios = RandomNumberGenerator.GetBytes(32);
            return Convert.ToBase64String(bytesAleatorios);
        }

        public static byte[] CalcularHash(string senha, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.Unicode.GetBytes(senha + salt));
            }
        }

        public static bool ValidarForcaSenha(string senha, out string mensagemErro)
        {
            mensagemErro = string.Empty;

            if (string.IsNullOrEmpty(senha) || senha.Length < 6)
            {
                mensagemErro = "A senha deve ter pelo menos 6 caracteres.";
                return false;
            }

            bool temLetra = false;
            bool temNumero = false;
            foreach (char c in senha)
            {
                if (char.IsLetter(c)) temLetra = true;
                if (char.IsDigit(c)) temNumero = true;
            }

            if (!temLetra || !temNumero)
            {
                mensagemErro = "A senha deve conter pelo menos uma letra e um número.";
                return false;
            }

            return true;
        }
    }
}