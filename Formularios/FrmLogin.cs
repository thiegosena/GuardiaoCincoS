using System;
using System.Drawing;
using System.Windows.Forms;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Formularios;
using GuardiaoCincoS.Servicos;
using Microsoft.Data.SqlClient;

namespace GuardiaoCincoS
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            // Centraliza em cima do overlay (que cobre a tela inteira) e
            // garante que o login sempre fique por cima de qualquer outra
            // janela do próprio Guardião 5S.
            StartPosition = FormStartPosition.CenterParent;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblVersao.Text = VersaoApp.ObterVersaoTexto();
            AtualizacaoService.VerificarAtualizacoes();

            EstiloVisual.EstilizarBotao(btnEntrar, "Entrar", EstiloVisual.Verde, Color.White);
            btnEntrar.Size = new Size(140, 42);

            string? usuarioLembrado = PreferenciasLogin.Carregar();
            if (!string.IsNullOrEmpty(usuarioLembrado))
            {
                txtUsuario.Text = usuarioLembrado;
                chkLembrarUsuario.Checked = true;
                txtSenha.Focus();
            }
            else
            {
                txtUsuario.Focus();
            }
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
                                string salt = leitor.LerTexto("Salt");
                                byte[] hashArmazenado = (byte[])leitor["SenhaHash"]!;
                                byte[] hashDigitado = SegurancaSenha.CalcularHash(senha, salt);

                                if (CompararBytes(hashArmazenado, hashDigitado))
                                {
                                    Sessao.IdUsuario = leitor.LerInteiro("Id");
                                    Sessao.NomeCompleto = leitor.LerTexto("NomeCompleto");
                                    Sessao.IdPerfil = leitor.LerInteiro("IdPerfil");
                                    Sessao.NomePerfil = leitor.LerTexto("NomePerfil");

                                    PreferenciasLogin.Salvar(usuario, chkLembrarUsuario.Checked);

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

        private void llNovoCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WhatsAppService.AbrirComMensagem("Olá! Gostaria de solicitar um novo cadastro no Sistema Guardião 5S.");
        }

        private void llEsqueceuSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WhatsAppService.AbrirComMensagem("Olá! Esqueci minha senha do Sistema Guardião 5S e preciso de ajuda para redefini-la.");
        }
    }
}