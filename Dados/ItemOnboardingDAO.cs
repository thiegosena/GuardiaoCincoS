using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class ItemOnboardingDAO
    {
        public static List<ItemOnboarding> ListarPorOnboarding(int idOnboarding)
        {
            var lista = new List<ItemOnboarding>();
            string sql = @"SELECT Id, IdOnboarding, Descricao, Concluido, DataConclusaoItem
                           FROM ItensOnboarding
                           WHERE IdOnboarding = @id
                           ORDER BY Id";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", idOnboarding);
                    using (var leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            lista.Add(new ItemOnboarding
                            {
                                Id = leitor.LerInteiro("Id"),
                                IdOnboarding = leitor.LerInteiro("IdOnboarding"),
                                Descricao = leitor.LerTexto("Descricao"),
                                Concluido = leitor.LerBooleano("Concluido"),
                                DataConclusaoItem = leitor.LerDataOpcional("DataConclusaoItem")
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static void AtualizarConclusao(int idItem, bool concluido)
        {
            string sql = @"UPDATE ItensOnboarding
                           SET Concluido = @concluido,
                               DataConclusaoItem = CASE WHEN @concluido = 1 THEN datetime('now','localtime') ELSE NULL END
                           WHERE Id = @id";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@concluido", concluido);
                    comando.Parameters.AddWithValue("@id", idItem);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}