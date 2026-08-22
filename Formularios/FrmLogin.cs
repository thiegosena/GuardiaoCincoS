using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Servicos;
using GuardiaoCincoS.Formularios;
using Microsoft.Data.Sqlite;


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
                    using (var comando = new SqliteCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);
                        using (var leitor = comando.ExecuteReader())
                        {
                            if (leitor.Read())
                            {
                                string salt = leitor.LerTexto("Salt");
                                byte[] hashArmazenado = (byte[])leitor["SenhaHash"]!;
                                byte[] hashDigitado = SegurancaSenha.CalcularHash(senha, salt);

                                if (CompararBytes(hashArmazenado, hashDigitado))
                                {
                                    Sessao.IdUsuario = leitor.LerInteiro("Id");
                                    Sessao.NomeCompleto = leitor.LerTexto("NomeCompleto");
                                    Sessao.IdPerfil = leitor.LerInteiro("IdPerfil");
                                    Sessao.NomePerfil = leitor.LerTexto("NomePerfil");

                                    DialogResult = DialogResult.OK;
                                    Close();
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



        private bool CompararBytes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Close();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnEntrar.PerformClick();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtSenha.Focus();
            }
        }
    }

}


