using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class PendenciaDAO
    {
        public static List<ItemPendencia> ListarConsolidado()
        {
            var lista = new List<ItemPendencia>();
            lista.AddRange(ListarDemarcacoesPendentes());
            lista.AddRange(ListarPlacasPendentes());
            lista.AddRange(ListarItensCorrecaoPendentes());

            return lista.OrderBy(p => p.Prazo).ToList();
        }

        private static List<ItemPendencia> ListarDemarcacoesPendentes()
        {
            var lista = new List<ItemPendencia>();
            string sql = "SELECT Local, Descricao, DataPrevista FROM Demarcacoes WHERE Status = 'Pendente'";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new ItemPendencia
                        {
                            Origem = "Demarcação",
                            LocalOuSetor = leitor.LerTexto("Local"),
                            Descricao = leitor.LerTexto("Descricao"),
                            Prazo = leitor.LerData("DataPrevista")
                        });
                    }
                }
            }
            return lista;
        }

        private static List<ItemPendencia> ListarPlacasPendentes()
        {
            var lista = new List<ItemPendencia>();
            string sql = "SELECT LocalPlaca, DataVencimento FROM PlacasProvisoriasAuditoria WHERE Status = 'Pendente'";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new ItemPendencia
                        {
                            Origem = "Placa Provisória",
                            LocalOuSetor = leitor.LerTexto("LocalPlaca"),
                            Descricao = "Substituir placa provisória",
                            Prazo = leitor.LerData("DataVencimento")
                        });
                    }
                }
            }
            return lista;
        }

        private static List<ItemPendencia> ListarItensCorrecaoPendentes()
        {
            var lista = new List<ItemPendencia>();
            string sql = @"SELECT ic.Descricao, ic.DataLimite, a.Setor
                           FROM ItensCorrecaoAuditoria ic
                           INNER JOIN Auditorias a ON a.Id = ic.IdAuditoria
                           WHERE ic.Status = 'Pendente'";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new ItemPendencia
                        {
                            Origem = "Item de Correção",
                            LocalOuSetor = leitor.LerTexto("Setor"),
                            Descricao = leitor.LerTexto("Descricao"),
                            Prazo = leitor.LerData("DataLimite")
                        });
                    }
                }
            }
            return lista;
        }
    }
}