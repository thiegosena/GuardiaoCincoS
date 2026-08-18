using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class EventoCalendarioDAO
    {
        public static List<EventoCalendario> Listar(bool apenasFuturos, bool incluirCancelados)
        {
            var lista = new List<EventoCalendario>();
            string sql = @"SELECT e.Id, e.Titulo, e.Tipo, e.DataInicio, e.DataFim, e.Local, e.Descricao,
                                  e.IdColaboradorResponsavel, c.Nome AS NomeResponsavel, e.Status
                           FROM EventosCalendario e
                           LEFT JOIN Colaboradores c ON c.Id = e.IdColaboradorResponsavel
                           WHERE 1 = 1";

            if (!incluirCancelados) sql += " AND e.Status <> 'Cancelado'";
            if (apenasFuturos) sql += " AND e.DataFim >= CAST(GETDATE() AS DATE)";
            sql += " ORDER BY e.DataInicio ASC, e.Id ASC";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(MapearLeitor(leitor));
                    }
                }
            }
            return lista;
        }

        public static List<EventoCalendario> ListarPorData(DateTime data, bool incluirCancelados)
        {
            var lista = new List<EventoCalendario>();
            string sql = @"SELECT e.Id, e.Titulo, e.Tipo, e.DataInicio, e.DataFim, e.Local, e.Descricao,
                                  e.IdColaboradorResponsavel, c.Nome AS NomeResponsavel, e.Status
                           FROM EventosCalendario e
                           LEFT JOIN Colaboradores c ON c.Id = e.IdColaboradorResponsavel
                           WHERE @data BETWEEN e.DataInicio AND e.DataFim";

            if (!incluirCancelados) sql += " AND e.Status <> 'Cancelado'";
            sql += " ORDER BY e.DataInicio ASC, e.Id ASC";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@data", data.Date);
                    using (var leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            lista.Add(MapearLeitor(leitor));
                        }
                    }
                }
            }
            return lista;
        }

        public static List<DateTime> ListarDatasComEventos()
        {
            var datas = new List<DateTime>();
            string sql = "SELECT DataInicio, DataFim FROM EventosCalendario WHERE Status <> 'Cancelado'";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        DateTime inicio = leitor.LerData("DataInicio");
                        DateTime fim = leitor.LerData("DataFim");
                        for (DateTime dia = inicio; dia <= fim; dia = dia.AddDays(1))
                        {
                            datas.Add(dia);
                        }
                    }
                }
            }
            return datas;
        }

        private static EventoCalendario MapearLeitor(SqlDataReader leitor)
        {
            return new EventoCalendario
            {
                Id = leitor.LerInteiro("Id"),
                Titulo = leitor.LerTexto("Titulo"),
                Tipo = leitor.LerTexto("Tipo"),
                DataInicio = leitor.LerData("DataInicio"),
                DataFim = leitor.LerData("DataFim"),
                Local = leitor.LerTexto("Local"),
                Descricao = leitor.LerTexto("Descricao"),
                IdColaboradorResponsavel = leitor.LerInteiroOpcional("IdColaboradorResponsavel"),
                NomeResponsavel = leitor.LerTexto("NomeResponsavel"),
                Status = leitor.LerTexto("Status")
            };
        }

        public static void Inserir(EventoCalendario ev, int idUsuarioRegistro)
        {
            string sql = @"INSERT INTO EventosCalendario
                    (Titulo, Tipo, DataInicio, DataFim, Local, Descricao, IdColaboradorResponsavel, Status, IdUsuarioRegistro)
                    VALUES (@titulo, @tipo, @dataInicio, @dataFim, @local, @descricao, @idResponsavel, 'Agendado', @idUsuario)";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@titulo", ev.Titulo);
                    comando.Parameters.AddWithValue("@tipo", ev.Tipo);
                    comando.Parameters.AddWithValue("@dataInicio", ev.DataInicio.Date);
                    comando.Parameters.AddWithValue("@dataFim", ev.DataFim.Date);
                    comando.Parameters.AddWithValue("@local", ev.Local.ValorOuNulo());
                    comando.Parameters.AddWithValue("@descricao", ev.Descricao.ValorOuNulo());
                    comando.Parameters.AddWithValue("@idResponsavel", ev.IdColaboradorResponsavel.ValorOuNulo());
                    comando.Parameters.AddWithValue("@idUsuario", idUsuarioRegistro);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Atualizar(EventoCalendario ev)
        {
            string sql = @"UPDATE EventosCalendario
                           SET Titulo = @titulo, Tipo = @tipo, DataInicio = @dataInicio, DataFim = @dataFim,
                               Local = @local, Descricao = @descricao, IdColaboradorResponsavel = @idResponsavel
                           WHERE Id = @id";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@titulo", ev.Titulo);
                    comando.Parameters.AddWithValue("@tipo", ev.Tipo);
                    comando.Parameters.AddWithValue("@dataInicio", ev.DataInicio.Date);
                    comando.Parameters.AddWithValue("@dataFim", ev.DataFim.Date);
                    comando.Parameters.AddWithValue("@local", ev.Local.ValorOuNulo());
                    comando.Parameters.AddWithValue("@descricao", ev.Descricao.ValorOuNulo());
                    comando.Parameters.AddWithValue("@idResponsavel", ev.IdColaboradorResponsavel.ValorOuNulo());
                    comando.Parameters.AddWithValue("@id", ev.Id);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Cancelar(int id)
        {
            string sql = "UPDATE EventosCalendario SET Status = 'Cancelado' WHERE Id = @id";
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

        public static void Reativar(int id)
        {
            string sql = "UPDATE EventosCalendario SET Status = 'Agendado' WHERE Id = @id";
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