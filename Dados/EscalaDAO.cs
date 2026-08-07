using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class EscalaDAO
    {
        public static List<Colaborador> ListarColaboradoresNaEscala(DateTime inicioSemana)
        {
            var lista = new List<Colaborador>();
            string sql = @"SELECT c.Id, c.Nome
                           FROM Colaboradores c
                           INNER JOIN Escala5SSemanal e ON e.IdColaborador = c.Id
                           WHERE e.DataInicioSemana = @inicio AND e.Ativo = 1";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@inicio", inicioSemana.Date);
                    using (var leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            lista.Add(new Colaborador
                            {
                                Id = (int)leitor["Id"],
                                Nome = leitor["Nome"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static void SalvarEscala(DateTime inicioSemana, DateTime fimSemana, List<int> idsColaboradoresSelecionados)
        {
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();

                string sqlDelete = "DELETE FROM Escala5SSemanal WHERE DataInicioSemana = @inicio";
                using (var comandoDelete = new SqlCommand(sqlDelete, conexao))
                {
                    comandoDelete.Parameters.AddWithValue("@inicio", inicioSemana.Date);
                    comandoDelete.ExecuteNonQuery();
                }

                string sqlInsert = "INSERT INTO Escala5SSemanal (IdColaborador, DataInicioSemana, DataFimSemana, Ativo) VALUES (@id, @inicio, @fim, 1)";
                foreach (var idColaborador in idsColaboradoresSelecionados)
                {
                    using (var comandoInsert = new SqlCommand(sqlInsert, conexao))
                    {
                        comandoInsert.Parameters.AddWithValue("@id", idColaborador);
                        comandoInsert.Parameters.AddWithValue("@inicio", inicioSemana.Date);
                        comandoInsert.Parameters.AddWithValue("@fim", fimSemana.Date);
                        comandoInsert.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}