namespace GuardiaoCincoS.Formularios
{
    partial class FrmUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarios));
            dgvUsuarios = new DataGridView();
            chkMostrarInativos = new CheckBox();
            txtNomeCompleto = new TextBox();
            txtNomeUsuario = new TextBox();
            txtEmail = new TextBox();
            txtTelefone = new TextBox();
            cboPerfil = new ComboBox();
            txtSenha = new TextBox();
            txtConfirmarSenha = new TextBox();
            btnNovoUsuario = new Button();
            btnEditarUsuario = new Button();
            btnCancelarEdicaoUsuario = new Button();
            btnSalvarUsuario = new Button();
            btnInativarUsuario = new Button();
            btnReativarUsuario = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(0, 0);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Size = new Size(800, 192);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // chkMostrarInativos
            // 
            chkMostrarInativos.AutoSize = true;
            chkMostrarInativos.Location = new Point(12, 198);
            chkMostrarInativos.Name = "chkMostrarInativos";
            chkMostrarInativos.Size = new Size(158, 19);
            chkMostrarInativos.TabIndex = 1;
            chkMostrarInativos.Text = "Mostrar usuários inativos";
            chkMostrarInativos.UseVisualStyleBackColor = true;
            chkMostrarInativos.CheckedChanged += chkMostrarInativos_CheckedChanged;
            // 
            // txtNomeCompleto
            // 
            txtNomeCompleto.Location = new Point(12, 247);
            txtNomeCompleto.MaxLength = 150;
            txtNomeCompleto.Name = "txtNomeCompleto";
            txtNomeCompleto.Size = new Size(236, 23);
            txtNomeCompleto.TabIndex = 3;
            // 
            // txtNomeUsuario
            // 
            txtNomeUsuario.Location = new Point(297, 302);
            txtNomeUsuario.MaxLength = 50;
            txtNomeUsuario.Name = "txtNomeUsuario";
            txtNomeUsuario.Size = new Size(186, 23);
            txtNomeUsuario.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(534, 247);
            txtEmail.MaxLength = 150;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(254, 23);
            txtEmail.TabIndex = 7;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(297, 246);
            txtTelefone.MaxLength = 20;
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(186, 23);
            txtTelefone.TabIndex = 9;
            // 
            // cboPerfil
            // 
            cboPerfil.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPerfil.FormattingEnabled = true;
            cboPerfil.Location = new Point(12, 303);
            cboPerfil.Name = "cboPerfil";
            cboPerfil.Size = new Size(236, 23);
            cboPerfil.TabIndex = 11;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(297, 360);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(186, 23);
            txtSenha.TabIndex = 13;
            txtSenha.UseSystemPasswordChar = true;
            // 
            // txtConfirmarSenha
            // 
            txtConfirmarSenha.Location = new Point(297, 418);
            txtConfirmarSenha.Name = "txtConfirmarSenha";
            txtConfirmarSenha.Size = new Size(186, 23);
            txtConfirmarSenha.TabIndex = 15;
            txtConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // btnNovoUsuario
            // 
            btnNovoUsuario.Font = new Font("Segoe UI", 9F);
            btnNovoUsuario.Location = new Point(12, 520);
            btnNovoUsuario.Name = "btnNovoUsuario";
            btnNovoUsuario.Size = new Size(103, 32);
            btnNovoUsuario.TabIndex = 17;
            btnNovoUsuario.Text = "Novo Usuário";
            btnNovoUsuario.UseVisualStyleBackColor = true;
            btnNovoUsuario.Click += btnNovoUsuario_Click;
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.Font = new Font("Segoe UI", 9F);
            btnEditarUsuario.Location = new Point(145, 520);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(103, 32);
            btnEditarUsuario.TabIndex = 18;
            btnEditarUsuario.Text = "Editar Usuário";
            btnEditarUsuario.UseVisualStyleBackColor = true;
            btnEditarUsuario.Click += btnEditarUsuario_Click;
            // 
            // btnCancelarEdicaoUsuario
            // 
            btnCancelarEdicaoUsuario.Font = new Font("Segoe UI", 9F);
            btnCancelarEdicaoUsuario.Location = new Point(279, 520);
            btnCancelarEdicaoUsuario.Name = "btnCancelarEdicaoUsuario";
            btnCancelarEdicaoUsuario.Size = new Size(103, 32);
            btnCancelarEdicaoUsuario.TabIndex = 19;
            btnCancelarEdicaoUsuario.Text = "Cancelar Edição";
            btnCancelarEdicaoUsuario.UseVisualStyleBackColor = true;
            btnCancelarEdicaoUsuario.Click += btnCancelarEdicaoUsuario_Click;
            // 
            // btnSalvarUsuario
            // 
            btnSalvarUsuario.Font = new Font("Segoe UI", 9F);
            btnSalvarUsuario.Location = new Point(414, 520);
            btnSalvarUsuario.Name = "btnSalvarUsuario";
            btnSalvarUsuario.Size = new Size(108, 32);
            btnSalvarUsuario.TabIndex = 20;
            btnSalvarUsuario.Text = "Cadastrar Usuário";
            btnSalvarUsuario.UseVisualStyleBackColor = true;
            btnSalvarUsuario.Click += btnSalvarUsuario_Click;
            // 
            // btnInativarUsuario
            // 
            btnInativarUsuario.Font = new Font("Segoe UI", 9F);
            btnInativarUsuario.Location = new Point(547, 520);
            btnInativarUsuario.Name = "btnInativarUsuario";
            btnInativarUsuario.Size = new Size(103, 32);
            btnInativarUsuario.TabIndex = 21;
            btnInativarUsuario.Text = "Inativar Usuário";
            btnInativarUsuario.UseVisualStyleBackColor = true;
            btnInativarUsuario.Click += btnInativarUsuario_Click;
            // 
            // btnReativarUsuario
            // 
            btnReativarUsuario.Font = new Font("Segoe UI", 9F);
            btnReativarUsuario.Location = new Point(681, 520);
            btnReativarUsuario.Name = "btnReativarUsuario";
            btnReativarUsuario.Size = new Size(103, 32);
            btnReativarUsuario.TabIndex = 22;
            btnReativarUsuario.Text = "Reativar Usuário";
            btnReativarUsuario.UseVisualStyleBackColor = true;
            btnReativarUsuario.Click += btnReativarUsuario_Click;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(884, 861);
            Controls.Add(btnReativarUsuario);
            Controls.Add(btnInativarUsuario);
            Controls.Add(btnSalvarUsuario);
            Controls.Add(btnCancelarEdicaoUsuario);
            Controls.Add(btnEditarUsuario);
            Controls.Add(btnNovoUsuario);
            Controls.Add(txtConfirmarSenha);
            Controls.Add(txtSenha);
            Controls.Add(cboPerfil);
            Controls.Add(txtTelefone);
            Controls.Add(txtEmail);
            Controls.Add(txtNomeUsuario);
            Controls.Add(txtNomeCompleto);
            Controls.Add(chkMostrarInativos);
            Controls.Add(dgvUsuarios);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Usuários";
            Load += FrmUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsuarios;
        private CheckBox chkMostrarInativos;
        private TextBox txtNomeCompleto;
        private TextBox txtNomeUsuario;
        private TextBox txtEmail;
        private TextBox txtTelefone;
        private ComboBox cboPerfil;
        private TextBox txtSenha;
        private TextBox txtConfirmarSenha;
        private Button btnNovoUsuario;
        private Button btnEditarUsuario;
        private Button btnCancelarEdicaoUsuario;
        private Button btnSalvarUsuario;
        private Button btnInativarUsuario;
        private Button btnReativarUsuario;
    }
}