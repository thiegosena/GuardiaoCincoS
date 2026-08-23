using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class AuditoriaDAO
    {
        public static List<Auditoria> Listar()
        {
            var lista = new List<Auditoria>();
            string sql = @"SELECT a.Id, a.Data, a.Setor, a.IdColaboradorAuditor, cAuditor.Nome AS NomeAuditor,
                                  a.IdColaboradorAcompanhante, cAcompanhante.Nome AS NomeAcompanhante,
                                  a.PontuacaoTotal, a.ObservacoesGerais, a.DataHoraRegistro
                           FROM Auditorias a
                           INNER JOIN Colaboradores cAuditor ON cAuditor.Id = a.IdColaboradorAuditor
                           LEFT JOIN Colaboradores cAcompanhante ON cAcompanhante.Id = a.IdColaboradorAcompanhante
                           ORDER BY a.Data DESC, a.Id DESC";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Auditoria
                        {
                            Id = leitor.LerInteiro("Id"),
                            Data = leitor.LerData("Data"),
                            Setor = leitor.LerTexto("Setor"),
                            IdColaboradorAuditor = leitor.LerInteiro("IdColaboradorAuditor"),
                            NomeAuditor = leitor.LerTexto("NomeAuditor"),
                            IdColaboradorAcompanhante = leitor.LerInteiroOpcional("IdColaboradorAcompanhante"),
                            NomeAcompanhante = leitor.LerTexto("NomeAcompanhante"),
                            PontuacaoTotal = leitor.GetDecimal(leitor.GetOrdinal("PontuacaoTotal")),
                            ObservacoesGerais = leitor.LerTexto("ObservacoesGerais"),
                            DataHoraRegistro = leitor.LerData("DataHoraRegistro")
                        });
                    }
                }
            }
            return lista;
        }

        public static void Inserir(Auditoria cabecalho, List<ItemAuditoria> itensChecklist,
            List<PlacaProvisoria> placas, List<ItemCorrecao> itensCorrecao, int idUsuarioRegistro)
        {
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        string sqlCabecalho = @"INSERT INTO Auditorias
                                (Data, Setor, IdColaboradorAuditor, IdColaboradorAcompanhante, PontuacaoTotal, ObservacoesGerais, IdUsuarioRegistro)
                                OUTPUT INSERTED.Id
                                VALUES (@data, @setor, @idAuditor, @idAcompanhante, @pontuacao, @obs, @idUsuario)";

                        int idAuditoriaGerada;
                        using (var comando = new SqlCommand(sqlCabecalho, conexao, transacao))
                        {
                            comando.Parameters.AddWithValue("@data", cabecalho.Data.Date);
                            comando.Parameters.AddWithValue("@setor", cabecalho.Setor);
                            comando.Parameters.AddWithValue("@idAuditor", cabecalho.IdColaboradorAuditor);
                            comando.Parameters.AddWithValue("@idAcompanhante", cabecalho.IdColaboradorAcompanhante.ValorOuNulo());
                            comando.Parameters.AddWithValue("@pontuacao", cabecalho.PontuacaoTotal);
                            comando.Parameters.AddWithValue("@obs", cabecalho.ObservacoesGerais.ValorOuNulo());
                            comando.Parameters.AddWithValue("@idUsuario", idUsuarioRegistro);
                            idAuditoriaGerada = (int)comando.ExecuteScalar()!;
                        }

                        string sqlItem = @"INSERT INTO ItensAuditoria (IdAuditoria, Senso, Nota, Observacao)
                                            VALUES (@idAuditoria, @senso, @nota, @observacao)";
                        foreach (var item in itensChecklist)
                        {
                            using (var comando = new SqlCommand(sqlItem, conexao, transacao))
                            {
                                comando.Parameters.AddWithValue("@idAuditoria", idAuditoriaGerada);
                                comando.Parameters.AddWithValue("@senso", item.Senso);
                                comando.Parameters.AddWithValue("@nota", item.Nota);
                                comando.Parameters.AddWithValue("@observacao", item.Observacao.ValorOuNulo());
                                comando.ExecuteNonQuery();
                            }
                        }

                        string sqlPlaca = @"INSERT INTO PlacasProvisoriasAuditoria (IdAuditoria, LocalPlaca, DataVencimento, Status)
                                             VALUES (@idAuditoria, @local, @vencimento, 'Pendente')";
                        foreach (var placa in placas)
                        {
                            using (var comando = new SqlCommand(sqlPlaca, conexao, transacao))
                            {
                                comando.Parameters.AddWithValue("@idAuditoria", idAuditoriaGerada);
                                comando.Parameters.AddWithValue("@local", placa.LocalPlaca);
                                comando.Parameters.AddWithValue("@vencimento", placa.DataVencimento);
                                comando.ExecuteNonQuery();
                            }
                        }

                        string sqlItemCorrecao = @"INSERT INTO ItensCorrecaoAuditoria (IdAuditoria, Descricao, DataLimite, Status)
                                                    VALUES (@idAuditoria, @descricao, @prazo, 'Pendente')";
                        foreach (var itemCorrecao in itensCorrecao)
                        {
                            using (var comando = new SqlCommand(sqlItemCorrecao, conexao, transacao))
                            {
                                comando.Parameters.AddWithValue("@idAuditoria", idAuditoriaGerada);
                                comando.Parameters.AddWithValue("@descricao", itemCorrecao.Descricao);
                                comando.Parameters.AddWithValue("@prazo", itemCorrecao.DataLimite);
                                comando.ExecuteNonQuery();
                            }
                        }

                        transacao.Commit();
                    }
                    catch
                    {
                        transacao.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}