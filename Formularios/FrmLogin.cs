using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using GuardiaoCincoS.Dados;

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
                    string sql = "SELECT Id, NomeCompleto, SenhaHash, Salt, IdPerfil FROM Usuarios WHERE NomeUsuario = @usuario AND Ativo = 1";
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
                                    MessageBox.Show($"Bem-vindo, {leitor["NomeCompleto"]}!", "Login realizado");
                                    // Próxima fase: abrir a tela principal (Dashboard) aqui
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


