using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class ItemCorrecaoDAO
    {
        public static List<ItemCorrecao> ListarPorAuditoria(int idAuditoria)
        {
            var lista = new List<ItemCorrecao>();
            string sql = "SELECT Id, IdAuditoria, Descricao, DataLimite, Status FROM ItensCorrecaoAuditoria WHERE IdAuditoria = @id";

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
                            lista.Add(new ItemCorrecao
                            {
                                Id = leitor.LerInteiro("Id"),
                                IdAuditoria = leitor.LerInteiro("IdAuditoria"),
                                Descricao = leitor.LerTexto("Descricao"),
                                DataLimite = leitor.LerData("DataLimite"),
                                Status = leitor.LerTexto("Status")
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static void Concluir(int id)
        {
            string sql = "UPDATE ItensCorrecaoAuditoria SET Status = 'Concluida' WHERE Id = @id";
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}