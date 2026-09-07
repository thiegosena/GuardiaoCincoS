using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class ColaboradorDAO
    {
        public static List<Colaborador> Listar(bool apenasAtivos = true)
        {
            var lista = new List<Colaborador>();
            string sql = "SELECT Id, Nome, Setor, Turno, Ativo FROM Colaboradores";
            if (apenasAtivos) sql += " WHERE Ativo = 1";
            sql += " ORDER BY Nome";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
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
            return lista;
        }

        public static void Inserir(Colaborador c)
        {
            string sql = "INSERT INTO Colaboradores (Nome, Setor, Turno, Ativo) VALUES (@nome, @setor, @turno, 1)";
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", c.Nome);
                    comando.Parameters.AddWithValue("@setor", c.Setor.ValorOuNulo());
                    comando.Parameters.AddWithValue("@turno", c.Turno.ValorOuNulo());
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Atualizar(Colaborador c)
        {
            string sql = "UPDATE Colaboradores SET Nome = @nome, Setor = @setor, Turno = @turno WHERE Id = @id";
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", c.Nome);
                    comando.Parameters.AddWithValue("@setor", c.Setor.ValorOuNulo());
                    comando.Parameters.AddWithValue("@turno", c.Turno.ValorOuNulo());
                    comando.Parameters.AddWithValue("@id", c.Id);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Inativar(int id)
        {
            string sql = "UPDATE Colaboradores SET Ativo = 0 WHERE Id = @id";
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
            string sql = "UPDATE Colaboradores SET Ativo = 1 WHERE Id = @id";
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