using System;
using Microsoft.Data.SqlClient;

namespace GuardiaoCincoS.Dados
{
    // Métodos de leitura segura do SqlDataReader, evitando warnings de nullable
    public static class LeitorExtensions
    {
        public static string LerTexto(this SqlDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.IsDBNull(indice) ? string.Empty : leitor.GetString(indice);
        }

        public static int LerInteiro(this SqlDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.GetInt32(indice);
        }

        public static int? LerInteiroOpcional(this SqlDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.IsDBNull(indice) ? (int?)null : leitor.GetInt32(indice);
        }

        public static bool LerBooleano(this SqlDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.GetBoolean(indice);
        }

        public static DateTime LerData(this SqlDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.GetDateTime(indice);
        }

        public static DateTime? LerDataOpcional(this SqlDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.IsDBNull(indice) ? (DateTime?)null : leitor.GetDateTime(indice);
        }
    }

    // Métodos de escrita segura para o SqlCommand, evitando warnings de nullable
    public static class EscritaExtensions
    {
        public static object ValorOuNulo(this string? valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? DBNull.Value : valor;
        }

        public static object ValorOuNulo(this int? valor)
        {
            return valor.HasValue ? valor.Value : DBNull.Value;
        }
    }
}