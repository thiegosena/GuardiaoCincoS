using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class MaterialEstudoDAO
    {
        public static List<MaterialEstudo> Listar(bool apenasAtivos = true)
        {
            var lista = new List<MaterialEstudo>();
            string sql = @"SELECT Id, Titulo, Categoria, Descricao, CaminhoOuLink, DataPublicacao, Ativo
                           FROM MateriaisEstudo";
            if (apenasAtivos) sql += " WHERE Ativo = 1";
            sql += " ORDER BY Categoria, Titulo";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new MaterialEstudo
                        {
                            Id = leitor.LerInteiro("Id"),
                            Titulo = leitor.LerTexto("Titulo"),
                            Categoria = leitor.LerTexto("Categoria"),
                            Descricao = leitor.LerTexto("Descricao"),
                            CaminhoOuLink = leitor.LerTexto("CaminhoOuLink"),
                            DataPublicacao = leitor.LerData("DataPublicacao"),
                            Ativo = leitor.LerBooleano("Ativo")
                        });
                    }
                }
            }
            return lista;
        }

        public static void Inserir(MaterialEstudo m, int idUsuarioRegistro)
        {
            string sql = @"INSERT INTO MateriaisEstudo
                    (Titulo, Categoria, Descricao, CaminhoOuLink, DataPublicacao, Ativo, IdUsuarioRegistro)
                    VALUES (@titulo, @categoria, @descricao, @caminho, @dataPublicacao, 1, @idUsuario)";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@titulo", m.Titulo);
                    comando.Parameters.AddWithValue("@categoria", m.Categoria);
                    comando.Parameters.AddWithValue("@descricao", m.Descricao.ValorOuNulo());
                    comando.Parameters.AddWithValue("@caminho", m.CaminhoOuLink);
                    comando.Parameters.AddWithValue("@dataPublicacao", m.DataPublicacao.Date);
                    comando.Parameters.AddWithValue("@idUsuario", idUsuarioRegistro);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Atualizar(MaterialEstudo m)
        {
            string sql = @"UPDATE MateriaisEstudo
                           SET Titulo = @titulo, Categoria = @categoria, Descricao = @descricao,
                               CaminhoOuLink = @caminho, DataPublicacao = @dataPublicacao
                           WHERE Id = @id";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@titulo", m.Titulo);
                    comando.Parameters.AddWithValue("@categoria", m.Categoria);
                    comando.Parameters.AddWithValue("@descricao", m.Descricao.ValorOuNulo());
                    comando.Parameters.AddWithValue("@caminho", m.CaminhoOuLink);
                    comando.Parameters.AddWithValue("@dataPublicacao", m.DataPublicacao.Date);
                    comando.Parameters.AddWithValue("@id", m.Id);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Inativar(int id)
        {
            string sql = "UPDATE MateriaisEstudo SET Ativo = 0 WHERE Id = @id";
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