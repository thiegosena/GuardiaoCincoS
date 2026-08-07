using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Servicos;
using GuardiaoCincoS.Formularios;
using Microsoft.Data.SqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GuardiaoCincoS
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
    
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha usuário e senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conexao = ConexaoBanco.ObterConexao())
                {
                    conexao.Open();
                    string sql = @"SELECT u.Id, u.NomeCompleto, u.SenhaHash, u.Salt, u.IdPerfil, p.NomePerfil
               FROM Usuarios u
               INNER JOIN Perfis p ON p.Id = u.IdPerfil
               WHERE u.NomeUsuario = @usuario AND u.Ativo = 1";
                    using (var comando = new SqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);
                        using (var leitor = comando.ExecuteReader())
                        {
                            if (leitor.Read())
                            {
                                string salt = leitor["Salt"].ToString();
                                byte[] hashArmazenado = (byte[])leitor["SenhaHash"];
                                byte[] hashDigitado = CalcularHash(senha, salt);

                                if (CompararBytes(hashArmazenado, hashDigitado))
                                {
                                    Sessao.IdUsuario = (int)leitor["Id"];
                                    Sessao.NomeCompleto = leitor["NomeCompleto"].ToString();
                                    Sessao.IdPerfil = (int)leitor["IdPerfil"];
                                    Sessao.NomePerfil = leitor["NomePerfil"].ToString();

                                    this.Hide();
                                    var frmPrincipal = new FrmPrincipal();
                                    frmPrincipal.ShowDialog();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Usuário ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuário ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar no banco: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] CalcularHash(string senha, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.Unicode.GetBytes(senha + salt)); // era Encoding.UTF8
            }
        }

        private bool CompararBytes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
    }

}


