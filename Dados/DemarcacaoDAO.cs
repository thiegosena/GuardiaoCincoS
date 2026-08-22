using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class DemarcacaoDAO
    {
        public static List<Demarcacao> Listar(bool apenasPendentes = false)
        {
            var lista = new List<Demarcacao>();
            string sql = @"SELECT d.Id, d.Local, d.Descricao, d.DataIdentificacao, d.DataPrevista,
                                  d.IdColaboradorResponsavel, c.Nome AS NomeResponsavel,
                                  d.Status, d.DataConclusao, d.ObservacoesConclusao
                           FROM Demarcacoes d
                           INNER JOIN Colaboradores c ON c.Id = d.IdColaboradorResponsavel";
            if (apenasPendentes) sql += " WHERE d.Status = 'Pendente'";
            sql += " ORDER BY d.DataPrevista ASC, d.Id DESC";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Demarcacao
                        {
                            Id = leitor.LerInteiro("Id"),
                            Local = leitor.LerTexto("Local"),
                            Descricao = leitor.LerTexto("Descricao"),
                            DataIdentificacao = leitor.LerData("DataIdentificacao"),
                            DataPrevista = leitor.LerData("DataPrevista"),
                            IdColaboradorResponsavel = leitor.LerInteiro("IdColaboradorResponsavel"),
                            NomeResponsavel = leitor.LerTexto("NomeResponsavel"),
                            Status = leitor.LerTexto("Status"),
                            DataConclusao = leitor.LerDataOpcional("DataConclusao"),
                            ObservacoesConclusao = leitor.LerTexto("ObservacoesConclusao")
                        });
                    }
                }
            }
            return lista;
        }

        public static void Inserir(Demarcacao d, int idUsuarioRegistro)
        {
            string sql = @"INSERT INTO Demarcacoes
                    (Local, Descricao, DataIdentificacao, DataPrevista, IdColaboradorResponsavel, Status, IdUsuarioRegistro)
                    VALUES (@local, @descricao, @dataIdent, @dataPrevista, @idResponsavel, 'Pendente', @idUsuario)";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@local", d.Local);
                    comando.Parameters.AddWithValue("@descricao", d.Descricao.ValorOuNulo());
                    comando.Parameters.AddWithValue("@dataIdent", d.DataIdentificacao.Date);
                    comando.Parameters.AddWithValue("@dataPrevista", d.DataPrevista.Date);
                    comando.Parameters.AddWithValue("@idResponsavel", d.IdColaboradorResponsavel);
                    comando.Parameters.AddWithValue("@idUsuario", idUsuarioRegistro);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Concluir(int id, string observacoesConclusao)
        {
            string sql = @"UPDATE Demarcacoes
                           SET Status = 'Concluida', DataConclusao = datetime('now','localtime'), ObservacoesConclusao = @obs
                           WHERE Id = @id";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@obs", observacoesConclusao.ValorOuNulo());
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}