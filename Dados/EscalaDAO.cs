using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class EscalaDAO
    {
        public static List<Colaborador> ListarDisponiveisParaRonda(DateTime data)
        {
            DateTime inicioSemana = GuardiaoCincoS.Servicos.UtilData.ObterSegundaFeira(data);
            var lista = new List<Colaborador>();
            string sql = @"SELECT c.Id, c.Nome, c.Setor, c.Turno, c.Ativo
                   FROM Colaboradores c
                   WHERE c.Ativo = 1
                     AND c.Id NOT IN (
                         SELECT IdColaborador FROM Escala5SSemanal
                         WHERE DataInicioSemana = @inicio AND Ativo = 1
                     )
                   ORDER BY c.Nome";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@inicio", inicioSemana);
                    using (var leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            lista.Add(new Colaborador
                            {
                                Id = leitor.LerInteiro("Id"),
                                Nome = leitor.LerTexto("Nome"),
                                Setor = leitor.LerTexto("Setor"),
                                Turno = leitor.LerTexto("Turno"),
                                Ativo = leitor.LerBooleano("Ativo")
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