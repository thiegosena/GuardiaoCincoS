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
            label1 = new Label();
            txtNomeCompleto = new TextBox();
            txtNomeUsuario = new TextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            txtTelefone = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cboPerfil = new ComboBox();
            txtSenha = new TextBox();
            label6 = new Label();
            txtConfirmarSenha = new TextBox();
            label7 = new Label();
            label8 = new Label();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 229);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 2;
            label1.Text = "Nome completo";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(297, 284);
            label2.Name = "label2";
            label2.Size = new Size(136, 15);
            label2.TabIndex = 4;
            label2.Text = "Nome de usuário (login)";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(534, 247);
            txtEmail.MaxLength = 150;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(254, 23);
            txtEmail.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(534, 229);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 6;
            label3.Text = "E-mail";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(297, 246);
            txtTelefone.MaxLength = 20;
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(186, 23);
            txtTelefone.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(297, 228);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 8;
            label4.Text = "Telefone";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 285);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 10;
            label5.Text = "Nível de acesso";
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(297, 342);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 12;
            label6.Text = "Senha";
            // 
            // txtConfirmarSenha
            // 
            txtConfirmarSenha.Location = new Point(297, 418);
            txtConfirmarSenha.Name = "txtConfirmarSenha";
            txtConfirmarSenha.Size = new Size(186, 23);
            txtConfirmarSenha.TabIndex = 15;
            txtConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(297, 400);
            label7.Name = "label7";
            label7.Size = new Size(95, 15);
            label7.TabIndex = 14;
            label7.Text = "Confirmar senha";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            label8.Location = new Point(188, 444);
            label8.Name = "label8";
            label8.Size = new Size(442, 15);
            label8.TabIndex = 16;
            label8.Text = "Deixe os campos de senha em branco durante a edição para manter a senha atual.";
            // 
            // btnNovoUsuario
            // 
            btnNovoUsuario.Font = new Font("Segoe UI", 9F);
            btnNovoUsuario.Location = new Point(12, 491);
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
            btnEditarUsuario.Location = new Point(145, 491);
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
            btnCancelarEdicaoUsuario.Location = new Point(279, 491);
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
            btnSalvarUsuario.Location = new Point(414, 491);
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
            btnInativarUsuario.Location = new Point(547, 491);
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
            btnReativarUsuario.Location = new Point(681, 491);
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
            ClientSize = new Size(800, 535);
            Controls.Add(btnReativarUsuario);
            Controls.Add(btnInativarUsuario);
            Controls.Add(btnSalvarUsuario);
            Controls.Add(btnCancelarEdicaoUsuario);
            Controls.Add(btnEditarUsuario);
            Controls.Add(btnNovoUsuario);
            Controls.Add(label8);
            Controls.Add(txtConfirmarSenha);
            Controls.Add(label7);
            Controls.Add(txtSenha);
            Controls.Add(label6);
            Controls.Add(cboPerfil);
            Controls.Add(label5);
            Controls.Add(txtTelefone);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtNomeUsuario);
            Controls.Add(label2);
            Controls.Add(txtNomeCompleto);
            Controls.Add(label1);
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
        private Label label1;
        private TextBox txtNomeCompleto;
        private TextBox txtNomeUsuario;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtTelefone;
        private Label label4;
        private Label label5;
        private ComboBox cboPerfil;
        private TextBox txtSenha;
        private Label label6;
        private TextBox txtConfirmarSenha;
        private Label label7;
        private Label label8;
        private Button btnNovoUsuario;
        private Button btnEditarUsuario;
        private Button btnCancelarEdicaoUsuario;
        private Button btnSalvarUsuario;
        private Button btnInativarUsuario;
        private Button btnReativarUsuario;
    }
}