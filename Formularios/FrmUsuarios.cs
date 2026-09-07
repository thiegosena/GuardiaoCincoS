using System;
using System.Drawing;
using System.Windows.Forms;
using GuardiaoCincoS.Controles;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmUsuarios : Form
    {
        private enum ModoTela
        {
            Novo,
            Visualizacao,
            Edicao
        }

        private ModoTela _modoAtual = ModoTela.Novo;
        private Usuario? _usuarioSelecionado = null;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            if (Sessao.NomePerfil != "Administrador")
            {
                MessageBox.Show("Apenas o Administrador pode gerenciar usuários.", "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BeginInvoke(new Action(Close));
                return;
            }

            MontarLayout();
            CarregarPerfis();
            CarregarGrid();
            AplicarModo(ModoTela.Novo);
        }

        // Monta o visual inteiro por código, reaproveitando os controles que já
        // existem no Designer (reparentando-os) -- assim toda a lógica de clique
        // já ligada a eles continua funcionando sem alteração nenhuma.
        private void MontarLayout()
        {
            ClientSize = new Size(900, 900);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = EstiloVisual.FundoPagina;

            var pnlCabecalho = EstiloVisual.CriarCabecalho("Cadastro de Usuários");

            var pnlConteudo = new Panel { Dock = DockStyle.Fill, BackColor = EstiloVisual.FundoPagina, AutoScroll = true, Padding = new Padding(20) };

            // ===== Card do grid =====
            var cartaoGrid = new CartaoSecao
            {
                Titulo = "Usuários Cadastrados",
                CorDestaque = EstiloVisual.AzulKyly,
                Dock = DockStyle.Top,
                Height = 300,
                Margin = new Padding(0, 0, 0, 20)
            };

            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Parent = cartaoGrid.PainelConteudo;
            EstiloVisual.ConfigurarGrid(dgvUsuarios);

            chkMostrarInativos.Dock = DockStyle.Top;
            chkMostrarInativos.Height = 18;
            chkMostrarInativos.Font = EstiloVisual.FonteTexto;
            chkMostrarInativos.Parent = cartaoGrid.PainelConteudo;

            

            // ===== Card do formulário =====
            var cartaoFormulario = new CartaoSecao
            {
                Titulo = "Dados do Usuário",
                CorDestaque = EstiloVisual.AmareloKyly,
                Dock = DockStyle.Top,
                Height = 480
            };

            var grade = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 6,
                Padding = new Padding(4)
            };
            grade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            for (int i = 0; i < grade.RowCount; i++)
                grade.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var campoNome = EstiloVisual.CriarCampo("Nome completo", txtNomeCompleto);
            grade.Controls.Add(campoNome, 0, 0);
            grade.SetColumnSpan(campoNome, 2);

            grade.Controls.Add(EstiloVisual.CriarCampo("Nome de usuário (login)", txtNomeUsuario), 0, 1);
            grade.Controls.Add(EstiloVisual.CriarCampo("E-mail", txtEmail), 1, 1);

            grade.Controls.Add(EstiloVisual.CriarCampo("Telefone", txtTelefone), 0, 2);
            grade.Controls.Add(EstiloVisual.CriarCampo("Nível de acesso", cboPerfil), 1, 2);

            grade.Controls.Add(EstiloVisual.CriarCampo("Senha", txtSenha), 0, 3);
            grade.Controls.Add(EstiloVisual.CriarCampo("Confirmar senha", txtConfirmarSenha), 1, 3);

            var lblDica = new Label
            {
                Text = "Deixe os campos de senha em branco durante a edição para manter a senha atual.",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
                ForeColor = EstiloVisual.TextoSecundario,
                AutoSize = true,
                Margin = new Padding(6, 4, 6, 12)
            };
            grade.Controls.Add(lblDica, 0, 4);
            grade.SetColumnSpan(lblDica, 2);

            var pnlBotoes = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true, Margin = new Padding(6, 8, 6, 0) };

            EstiloVisual.EstilizarBotao(btnNovoUsuario, "Novo", EstiloVisual.AzulKyly, Color.White);
            EstiloVisual.EstilizarBotao(btnEditarUsuario, "Editar", EstiloVisual.AmareloKyly, EstiloVisual.TextoTitulo);
            EstiloVisual.EstilizarBotao(btnCancelarEdicaoUsuario, "Cancelar Edição", Color.FromArgb(210, 214, 220), EstiloVisual.TextoTitulo);
            EstiloVisual.EstilizarBotao(btnSalvarUsuario, "Salvar", EstiloVisual.Verde, Color.White);
            EstiloVisual.EstilizarBotao(btnInativarUsuario, "Inativar", EstiloVisual.Vermelho, Color.White);
            EstiloVisual.EstilizarBotao(btnReativarUsuario, "Reativar", EstiloVisual.Verde, Color.White);

            pnlBotoes.Controls.Add(btnNovoUsuario);
            pnlBotoes.Controls.Add(btnEditarUsuario);
            pnlBotoes.Controls.Add(btnCancelarEdicaoUsuario);
            pnlBotoes.Controls.Add(btnSalvarUsuario);
            pnlBotoes.Controls.Add(btnInativarUsuario);
            pnlBotoes.Controls.Add(btnReativarUsuario);

            grade.Controls.Add(pnlBotoes, 0, 5);
            grade.SetColumnSpan(pnlBotoes, 2);

            cartaoFormulario.PainelConteudo.Controls.Add(grade);

            // Ordem de adição = inverso da ordem visual desejada (grid em cima,
            // formulário embaixo), mesma regra de Dock=Top que já usamos no Dashboard.
            pnlConteudo.Controls.Add(cartaoFormulario);
            pnlConteudo.Controls.Add(cartaoGrid);

            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
        }

        

        private void CarregarPerfis()
        {
            cboPerfil.DataSource = PerfilDAO.Listar();
            cboPerfil.DisplayMember = "NomePerfil";
            cboPerfil.ValueMember = "Id";
        }

        private void CarregarGrid()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = UsuarioDAO.Listar(!chkMostrarInativos.Checked);
            ConfigurarColunasGrid();
        }

        private void ConfigurarColunasGrid()
        {
            if (dgvUsuarios.Columns["Id"] != null) dgvUsuarios.Columns["Id"]!.Visible = false;
            if (dgvUsuarios.Columns["IdPerfil"] != null) dgvUsuarios.Columns["IdPerfil"]!.Visible = false;
            if (dgvUsuarios.Columns["NomeCompleto"] != null) dgvUsuarios.Columns["NomeCompleto"]!.HeaderText = "Nome completo";
            if (dgvUsuarios.Columns["NomeUsuario"] != null) dgvUsuarios.Columns["NomeUsuario"]!.HeaderText = "Usuário (login)";
            if (dgvUsuarios.Columns["NomePerfil"] != null) dgvUsuarios.Columns["NomePerfil"]!.HeaderText = "Nível de acesso";
            if (dgvUsuarios.Columns["DataCriacao"] != null) dgvUsuarios.Columns["DataCriacao"]!.HeaderText = "Criado em";

            foreach (DataGridViewRow linha in dgvUsuarios.Rows)
            {
                var usuario = (Usuario)linha.DataBoundItem!;
                if (!usuario.Ativo)
                {
                    linha.DefaultCellStyle.ForeColor = EstiloVisual.TextoSecundario;
                }
            }
        }

        private void chkMostrarInativos_CheckedChanged(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void AplicarModo(ModoTela modo)
        {
            _modoAtual = modo;

            switch (modo)
            {
                case ModoTela.Novo:
                    LimparCampos();
                    HabilitarCamposCadastro(true);
                    btnSalvarUsuario.Text = "Salvar";
                    btnSalvarUsuario.Enabled = true;
                    btnEditarUsuario.Enabled = false;
                    btnCancelarEdicaoUsuario.Enabled = false;
                    btnNovoUsuario.Enabled = false;
                    btnInativarUsuario.Enabled = false;
                    btnReativarUsuario.Enabled = false;
                    dgvUsuarios.Enabled = true;
                    break;

                case ModoTela.Visualizacao:
                    HabilitarCamposCadastro(false);
                    btnSalvarUsuario.Text = "Salvar";
                    btnSalvarUsuario.Enabled = false;
                    btnEditarUsuario.Enabled = true;
                    btnCancelarEdicaoUsuario.Enabled = false;
                    btnNovoUsuario.Enabled = true;
                    btnInativarUsuario.Enabled = _usuarioSelecionado != null && _usuarioSelecionado.Ativo;
                    btnReativarUsuario.Enabled = _usuarioSelecionado != null && !_usuarioSelecionado.Ativo;
                    dgvUsuarios.Enabled = true;
                    break;

                case ModoTela.Edicao:
                    HabilitarCamposCadastro(true);
                    btnSalvarUsuario.Text = "Atualizar";
                    btnSalvarUsuario.Enabled = true;
                    btnEditarUsuario.Enabled = false;
                    btnCancelarEdicaoUsuario.Enabled = true;
                    btnNovoUsuario.Enabled = false;
                    btnInativarUsuario.Enabled = false;
                    btnReativarUsuario.Enabled = false;
                    dgvUsuarios.Enabled = false;
                    break;
            }
        }

        private void HabilitarCamposCadastro(bool habilitado)
        {
            txtNomeCompleto.Enabled = habilitado;
            txtNomeUsuario.Enabled = habilitado;
            txtEmail.Enabled = habilitado;
            txtTelefone.Enabled = habilitado;
            cboPerfil.Enabled = habilitado;
            txtSenha.Enabled = habilitado;
            txtConfirmarSenha.Enabled = habilitado;
        }

        private void LimparCampos()
        {
            _usuarioSelecionado = null;
            txtNomeCompleto.Text = string.Empty;
            txtNomeUsuario.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            if (cboPerfil.Items.Count > 0) cboPerfil.SelectedIndex = cboPerfil.Items.Count - 1;
            txtSenha.Text = string.Empty;
            txtConfirmarSenha.Text = string.Empty;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var usuario = (Usuario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem!;

            _usuarioSelecionado = usuario;
            txtNomeCompleto.Text = usuario.NomeCompleto;
            txtNomeUsuario.Text = usuario.NomeUsuario;
            txtEmail.Text = usuario.Email;
            txtTelefone.Text = usuario.Telefone;
            cboPerfil.SelectedValue = usuario.IdPerfil;
            txtSenha.Text = string.Empty;
            txtConfirmarSenha.Text = string.Empty;

            AplicarModo(ModoTela.Visualizacao);
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e) => AplicarModo(ModoTela.Novo);

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (_usuarioSelecionado == null)
            {
                MessageBox.Show("Selecione um usuário na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AplicarModo(ModoTela.Edicao);
        }

        private void btnCancelarEdicaoUsuario_Click(object sender, EventArgs e)
        {
            AplicarModo(ModoTela.Novo);
        }

        private void btnSalvarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeCompleto.Text))
            {
                MessageBox.Show("Informe o nome completo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNomeUsuario.Text))
            {
                MessageBox.Show("Informe o nome de usuário (login).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboPerfil.SelectedValue == null)
            {
                MessageBox.Show("Selecione o nível de acesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomeUsuarioDigitado = txtNomeUsuario.Text.Trim();
            string emailDigitado = txtEmail.Text.Trim();

            if (!string.IsNullOrWhiteSpace(emailDigitado) && (!emailDigitado.Contains('@') || !emailDigitado.Contains('.')))
            {
                MessageBox.Show("Informe um e-mail válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNomeCompleto.Text.Trim().Length > 150)
            {
                MessageBox.Show("O nome completo pode ter no máximo 150 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nomeUsuarioDigitado.Length > 50)
            {
                MessageBox.Show("O nome de usuário pode ter no máximo 50 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (emailDigitado.Length > 150)
            {
                MessageBox.Show("O e-mail pode ter no máximo 150 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTelefone.Text.Trim().Length > 20)
            {
                MessageBox.Show("O telefone pode ter no máximo 20 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idParaChecagem = _usuarioSelecionado?.Id ?? 0;
            if (UsuarioDAO.ExisteNomeUsuario(nomeUsuarioDigitado, idParaChecagem))
            {
                MessageBox.Show("Já existe um usuário com esse nome de login. Escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool alterandoSenha = _modoAtual == ModoTela.Novo
                || !string.IsNullOrEmpty(txtSenha.Text)
                || !string.IsNullOrEmpty(txtConfirmarSenha.Text);

            if (alterandoSenha)
            {
                if (txtSenha.Text != txtConfirmarSenha.Text)
                {
                    MessageBox.Show("As senhas digitadas não coincidem.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!SegurancaSenha.ValidarForcaSenha(txtSenha.Text, out string mensagemErroSenha))
                {
                    MessageBox.Show(mensagemErroSenha, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var usuario = new Usuario
            {
                Id = idParaChecagem,
                NomeCompleto = txtNomeCompleto.Text.Trim(),
                NomeUsuario = nomeUsuarioDigitado,
                Email = emailDigitado,
                Telefone = txtTelefone.Text.Trim(),
                IdPerfil = Convert.ToInt32(cboPerfil.SelectedValue)
            };

            if (_modoAtual == ModoTela.Edicao)
            {
                UsuarioDAO.Atualizar(usuario);
                if (alterandoSenha)
                {
                    UsuarioDAO.AtualizarSenha(usuario.Id, txtSenha.Text);
                }
                MessageBox.Show("Usuário atualizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                UsuarioDAO.Inserir(usuario, txtSenha.Text);
                MessageBox.Show("Usuário cadastrado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CarregarGrid();
            AplicarModo(ModoTela.Novo);
        }

        private void btnInativarUsuario_Click(object sender, EventArgs e)
        {
            if (_usuarioSelecionado == null)
            {
                MessageBox.Show("Selecione um usuário na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_usuarioSelecionado.Id == Sessao.IdUsuario)
            {
                MessageBox.Show("Você não pode inativar o seu próprio usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacao = MessageBox.Show(
                $"Inativar o usuário '{_usuarioSelecionado.NomeCompleto}'? Ele não conseguirá mais fazer login, mas o histórico dele é mantido.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                UsuarioDAO.Inativar(_usuarioSelecionado.Id);
                CarregarGrid();
                AplicarModo(ModoTela.Novo);
            }
        }

        private void btnReativarUsuario_Click(object sender, EventArgs e)
        {
            if (_usuarioSelecionado == null)
            {
                MessageBox.Show("Selecione um usuário na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioDAO.Reativar(_usuarioSelecionado.Id);
            CarregarGrid();
            AplicarModo(ModoTela.Novo);
            MessageBox.Show("Usuário reativado! Ele já pode fazer login novamente.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}