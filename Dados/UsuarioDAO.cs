using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using GuardiaoCincoS.Modelos;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Dados
{
    public static class UsuarioDAO
    {
        public static List<Usuario> Listar(bool apenasAtivos)
        {
            var lista = new List<Usuario>();
            string sql = @"SELECT u.Id, u.NomeCompleto, u.NomeUsuario, u.Email, u.Telefone,
                                  u.IdPerfil, p.NomePerfil, u.Ativo, u.DataCriacao
                           FROM Usuarios u
                           INNER JOIN Perfis p ON p.Id = u.IdPerfil";
            if (apenasAtivos) sql += " WHERE u.Ativo = 1";
            sql += " ORDER BY u.NomeCompleto";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Usuario
                        {
                            Id = leitor.LerInteiro("Id"),
                            NomeCompleto = leitor.LerTexto("NomeCompleto"),
                            NomeUsuario = leitor.LerTexto("NomeUsuario"),
                            Email = leitor.LerTexto("Email"),
                            Telefone = leitor.LerTexto("Telefone"),
                            IdPerfil = leitor.LerInteiro("IdPerfil"),
                            NomePerfil = leitor.LerTexto("NomePerfil"),
                            Ativo = leitor.LerBooleano("Ativo"),
                            DataCriacao = leitor.LerData("DataCriacao")
                        });
                    }
                }
            }
            return lista;
        }

        public static bool ExisteNomeUsuario(string nomeUsuario, int idExcluir)
        {
            string sql = "SELECT COUNT(*) FROM Usuarios WHERE NomeUsuario = @nome AND Id <> @idExcluir";
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", nomeUsuario);
                    comando.Parameters.AddWithValue("@idExcluir", idExcluir);
                    int quantidade = Convert.ToInt32(comando.ExecuteScalar());
                    return quantidade > 0;
                }
            }
        }

        public static void Inserir(Usuario u, string senha)
        {
            string salt = SegurancaSenha.GerarSalt();
            byte[] hash = SegurancaSenha.CalcularHash(senha, salt);

            string sql = @"INSERT INTO Usuarios
                    (NomeCompleto, NomeUsuario, Email, Telefone, SenhaHash, Salt, IdPerfil, Ativo)
                    VALUES (@nomeCompleto, @nomeUsuario, @email, @telefone, @senhaHash, @salt, @idPerfil, 1)";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nomeCompleto", u.NomeCompleto);
                    comando.Parameters.AddWithValue("@nomeUsuario", u.NomeUsuario);
                    comando.Parameters.AddWithValue("@email", u.Email.ValorOuNulo());
                    comando.Parameters.AddWithValue("@telefone", u.Telefone.ValorOuNulo());
                    comando.Parameters.AddWithValue("@senhaHash", hash);
                    comando.Parameters.AddWithValue("@salt", salt);
                    comando.Parameters.AddWithValue("@idPerfil", u.IdPerfil);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Atualizar(Usuario u)
        {
            string sql = @"UPDATE Usuarios
                           SET NomeCompleto = @nomeCompleto, NomeUsuario = @nomeUsuario,
                               Email = @email, Telefone = @telefone, IdPerfil = @idPerfil
                           WHERE Id = @id";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nomeCompleto", u.NomeCompleto);
                    comando.Parameters.AddWithValue("@nomeUsuario", u.NomeUsuario);
                    comando.Parameters.AddWithValue("@email", u.Email.ValorOuNulo());
                    comando.Parameters.AddWithValue("@telefone", u.Telefone.ValorOuNulo());
                    comando.Parameters.AddWithValue("@idPerfil", u.IdPerfil);
                    comando.Parameters.AddWithValue("@id", u.Id);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void AtualizarSenha(int idUsuario, string novaSenha)
        {
            string salt = SegurancaSenha.GerarSalt();
            byte[] hash = SegurancaSenha.CalcularHash(novaSenha, salt);

            string sql = "UPDATE Usuarios SET SenhaHash = @hash, Salt = @salt WHERE Id = @id";
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@hash", hash);
                    comando.Parameters.AddWithValue("@salt", salt);
                    comando.Parameters.AddWithValue("@id", idUsuario);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Inativar(int id)
        {
            string sql = "UPDATE Usuarios SET Ativo = 0 WHERE Id = @id";
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void Reativar(int id)
        {
            string sql = "UPDATE Usuarios SET Ativo = 1 WHERE Id = @id";
            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqliteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}