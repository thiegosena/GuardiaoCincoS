using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class OnboardingDAO
    {
        public static List<Onboarding> Listar()
        {
            var lista = new List<Onboarding>();
            string sql = @"SELECT o.Id, o.IdColaborador, c.Nome AS NomeColaborador, o.DataInicio,
                                  o.Status, o.DataConclusao, o.Observacoes
                           FROM Onboarding o
                           INNER JOIN Colaboradores c ON c.Id = o.IdColaborador
                           ORDER BY o.DataInicio DESC, o.Id DESC";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Onboarding
                        {
                            Id = leitor.LerInteiro("Id"),
                            IdColaborador = leitor.LerInteiro("IdColaborador"),
                            NomeColaborador = leitor.LerTexto("NomeColaborador"),
                            DataInicio = leitor.LerData("DataInicio"),
                            Status = leitor.LerTexto("Status"),
                            DataConclusao = leitor.LerDataOpcional("DataConclusao"),
                            Observacoes = leitor.LerTexto("Observacoes")
                        });
                    }
                }
            }
            return lista;
        }

        public static void Iniciar(Onboarding cabecalho, List<string> itensPadrao, int idUsuarioRegistro)
        {
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        string sqlCabecalho = @"INSERT INTO Onboarding (IdColaborador, DataInicio, Status, IdUsuarioRegistro)
                                                 OUTPUT INSERTED.Id
                                                 VALUES (@idColaborador, @dataInicio, 'Em Andamento', @idUsuario)";

                        int idOnboardingGerado;
                        using (var comando = new SqlCommand(sqlCabecalho, conexao, transacao))
                        {
                            comando.Parameters.AddWithValue("@idColaborador", cabecalho.IdColaborador);
                            comando.Parameters.AddWithValue("@dataInicio", cabecalho.DataInicio.Date);
                            comando.Parameters.AddWithValue("@idUsuario", idUsuarioRegistro);
                            idOnboardingGerado = (int)comando.ExecuteScalar()!;
                        }

                        string sqlItem = @"INSERT INTO ItensOnboarding (IdOnboarding, Descricao, Concluido)
                                            VALUES (@idOnboarding, @descricao, 0)";
                        foreach (var descricao in itensPadrao)
                        {
                            using (var comando = new SqlCommand(sqlItem, conexao, transacao))
                            {
                                comando.Parameters.AddWithValue("@idOnboarding", idOnboardingGerado);
                                comando.Parameters.AddWithValue("@descricao", descricao);
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

        public static int ContarItensPendentes(int idOnboarding)
        {
            string sql = "SELECT COUNT(*) FROM ItensOnboarding WHERE IdOnboarding = @id AND Concluido = 0";
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", idOnboarding);
                    return (int)comando.ExecuteScalar()!;
                }
            }
        }

        public static int ContarEmAndamento()
        {
            string sql = "SELECT COUNT(*) FROM Onboarding WHERE Status = 'Em Andamento'";
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    return (int)comando.ExecuteScalar()!;
                }
            }
        }

        public static Onboarding? ObterProximoAgendado()
        {
            string sql = @"SELECT TOP 1 o.Id, o.IdColaborador, c.Nome AS NomeColaborador, o.DataInicio,
                          o.Status, o.DataConclusao, o.Observacoes
                   FROM Onboarding o
                   INNER JOIN Colaboradores c ON c.Id = o.IdColaborador
                   WHERE o.Status = 'Em Andamento' AND o.DataInicio >= CAST(GETDATE() AS DATE)
                   ORDER BY o.DataInicio ASC, o.Id ASC";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return new Onboarding
                        {
                            Id = leitor.LerInteiro("Id"),
                            IdColaborador = leitor.LerInteiro("IdColaborador"),
                            NomeColaborador = leitor.LerTexto("NomeColaborador"),
                            DataInicio = leitor.LerData("DataInicio"),
                            Status = leitor.LerTexto("Status"),
                            DataConclusao = leitor.LerDataOpcional("DataConclusao"),
                            Observacoes = leitor.LerTexto("Observacoes")
                        };
                    }
                }
            }
            return null;
        }

        public static void Concluir(int id)
        {
            string sql = "UPDATE Onboarding SET Status = 'Concluido', DataConclusao = GETDATE() WHERE Id = @id";
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