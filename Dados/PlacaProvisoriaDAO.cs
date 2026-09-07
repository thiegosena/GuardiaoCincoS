using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class PlacaProvisoriaDAO
    {
        public static List<PlacaProvisoria> ListarPorAuditoria(int idAuditoria)
        {
            var lista = new List<PlacaProvisoria>();
            string sql = "SELECT Id, IdAuditoria, LocalPlaca, DataVencimento, Status FROM PlacasProvisoriasAuditoria WHERE IdAuditoria = @id";

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
                            lista.Add(new PlacaProvisoria
                            {
                                Id = leitor.LerInteiro("Id"),
                                IdAuditoria = leitor.LerInteiro("IdAuditoria"),
                                LocalPlaca = leitor.LerTexto("LocalPlaca"),
                                DataVencimento = leitor.LerData("DataVencimento"),
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
            string sql = "UPDATE PlacasProvisoriasAuditoria SET Status = 'Concluida' WHERE Id = @id";
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