using System;
using System.Data.Common;

namespace GuardiaoCincoS.Dados
{
    // Usa DbDataReader (a classe-base comum de qualquer provedor ADO.NET) em vez de
    // um tipo específico do SQL Server -- assim os mesmos métodos funcionam sem
    // alteração tanto com o antigo SqlDataReader quanto com o SqliteDataReader agora.
    public static class LeitorExtensions
    {
        public static string LerTexto(this DbDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.IsDBNull(indice) ? string.Empty : leitor.GetString(indice);
        }

        public static int LerInteiro(this DbDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.GetInt32(indice);
        }

        public static int? LerInteiroOpcional(this DbDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.IsDBNull(indice) ? (int?)null : leitor.GetInt32(indice);
        }

        public static bool LerBooleano(this DbDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.GetBoolean(indice);
        }

        public static DateTime LerData(this DbDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.GetDateTime(indice);
        }

        public static DateTime? LerDataOpcional(this DbDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.IsDBNull(indice) ? (DateTime?)null : leitor.GetDateTime(indice);
        }
    }

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