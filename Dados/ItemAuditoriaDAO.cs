using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class ItemAuditoriaDAO
    {
        public static List<ItemAuditoria> ListarPorAuditoria(int idAuditoria)
        {
            var lista = new List<ItemAuditoria>();
            string sql = "SELECT Id, IdAuditoria, Senso, Nota, Observacao FROM ItensAuditoria WHERE IdAuditoria = @id";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", idAuditoria);
                    using (var leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            lista.Add(new ItemAuditoria
                            {
                                Id = leitor.LerInteiro("Id"),
                                IdAuditoria = leitor.LerInteiro("IdAuditoria"),
                                Senso = leitor.LerTexto("Senso"),
                                Nota = leitor.LerInteiro("Nota"),
                                Observacao = leitor.LerTexto("Observacao")
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}