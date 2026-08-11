using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class RondaDAO
    {
        public static List<Ronda> Listar(bool apenasPendentes = false)
        {
            var lista = new List<Ronda>();
            string sql = @"SELECT r.Id, r.Data, r.Tipo, r.IdColaboradorResponsavel, c.Nome AS NomeColaborador,
                                  r.Status, r.Observacoes, r.DataHoraConclusao
                           FROM Rondas r
                           INNER JOIN Colaboradores c ON c.Id = r.IdColaboradorResponsavel";
            if (apenasPendentes) sql += " WHERE r.Status = 'Pendente'";
            sql += " ORDER BY r.Data DESC, r.Id DESC";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Ronda
                        {
                            Id = leitor.LerInteiro("Id"),
                            Data = leitor.LerData("Data"),
                            Tipo = leitor.LerTexto("Tipo"),
                            IdColaboradorResponsavel = leitor.LerInteiro("IdColaboradorResponsavel"),
                            NomeColaboradorResponsavel = leitor.LerTexto("NomeColaborador"),
                            Status = leitor.LerTexto("Status"),
                            Observacoes = leitor.LerTexto("Observacoes"),
                            DataHoraConclusao = leitor.LerDataOpcional("DataHoraConclusao")
                        });
                    }
                }
            }
            return lista;
        }

        public static void Inserir(Ronda r, int idUsuarioRegistro)
        {
            string sql = @"INSERT INTO Rondas (Data, Tipo, IdColaboradorResponsavel, Status, IdUsuarioRegistro)
                           VALUES (@data, @tipo, @idColaborador, 'Pendente', @idUsuario)";
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@data", r.Data.Date);
                    comando.Parameters.AddWithValue("@tipo", r.Tipo);
                    comando.Parameters.AddWithValue("@idColaborador", r.IdColaboradorResponsavel);
                    comando.Parameters.AddWithValue("@idUsuario", idUsuarioRegistro);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Concluir(int id, string observacoes)
        {
            string sql = @"UPDATE Rondas SET Status = 'Concluida', Observacoes = @obs, DataHoraConclusao = GETDATE()
                           WHERE Id = @id";
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@obs", observacoes.ValorOuNulo());
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}