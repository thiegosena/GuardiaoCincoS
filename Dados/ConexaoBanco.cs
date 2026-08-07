using System;
using Microsoft.Data.SqlClient;

namespace GuardiaoCincoS.Dados
{
    public static class ConexaoBanco
    {
        // Troque "localhost" pelo nome do seu servidor SQL, se necessário
        private static readonly string _connectionString =
            "Server=localhost\\SQLEXPRESS;Database=GuardiaoCincoS;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection ObterConexao()
        {
            return new SqlConnection(_connectionString);
        }

        public static bool TestarConexao(out string mensagemErro)
        {
            mensagemErro = string.Empty;
            try
            {
                using (var conexao = ObterConexao())
                {
                    conexao.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensagemErro = ex.Message;
                return false;
            }
        }
    }
}