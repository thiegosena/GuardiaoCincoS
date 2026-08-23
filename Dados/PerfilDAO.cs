using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Dados
{
    public static class PerfilDAO
    {
        public static List<Perfil> Listar()
        {
            var lista = new List<Perfil>();
            string sql = "SELECT Id, NomePerfil, Descricao FROM Perfis ORDER BY Id";

            using (var conexao = ConexaoBanco.ObterConexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Perfil
                        {
                            Id = leitor.LerInteiro("Id"),
                            NomePerfil = leitor.LerTexto("NomePerfil"),
                            Descricao = leitor.LerTexto("Descricao")
                        });
                    }
                }
            }
            return lista;
        }
    }
}