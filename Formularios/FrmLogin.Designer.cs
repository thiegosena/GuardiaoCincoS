namespace GuardiaoCincoS
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            label1 = new Label();
            imageList1 = new ImageList(components);
            label2 = new Label();
            txtUsuario = new TextBox();
            txtSenha = new TextBox();
            btnEntrar = new Button();
            pictureBox1 = new PictureBox();
            llNovoCadastro = new LinkLabel();
            llEsqueceuSenha = new LinkLabel();
            chkLembrarUsuario = new CheckBox();
            label5 = new Label();
            btnFechar = new Button();
            lblVersao = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.ImageKey = "User2.png";
            label1.ImageList = imageList1;
            label1.Location = new Point(12, 141);
            label1.Name = "label1";
            label1.Size = new Size(78, 19);
            label1.TabIndex = 0;
            label1.Text = "Usuário";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "User2.png");
            imageList1.Images.SetKeyName(1, "Key.png");
            imageList1.Images.SetKeyName(2, "Close.png");
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10F);
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.ImageKey = "Key.png";
            label2.ImageList = imageList1;
            label2.Location = new Point(12, 204);
            label2.Name = "label2";
            label2.Size = new Size(71, 23);
            label2.TabIndex = 1;
            label2.Text = "Senha";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(96, 141);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(161, 23);
            txtUsuario.TabIndex = 2;
            txtUsuario.KeyDown += txtUsuario_KeyDown;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(96, 204);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(161, 23);
            txtSenha.TabIndex = 3;
            txtSenha.UseSystemPasswordChar = true;
            txtSenha.KeyDown += txtSenha_KeyDown;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(112, 280);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(131, 36);
            btnEntrar.TabIndex = 4;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(124, 47);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(87, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // llNovoCadastro
            // 
            llNovoCadastro.AutoSize = true;
            llNovoCadastro.Location = new Point(12, 369);
            llNovoCadastro.Name = "llNovoCadastro";
            llNovoCadastro.Size = new Size(86, 15);
            llNovoCadastro.TabIndex = 6;
            llNovoCadastro.TabStop = true;
            llNovoCadastro.Text = "Novo Cadastro";
            llNovoCadastro.LinkClicked += llNovoCadastro_LinkClicked;
            // 
            // llEsqueceuSenha
            // 
            llEsqueceuSenha.AutoSize = true;
            llEsqueceuSenha.Location = new Point(221, 369);
            llEsqueceuSenha.Name = "llEsqueceuSenha";
            llEsqueceuSenha.Size = new Size(106, 15);
            llEsqueceuSenha.TabIndex = 7;
            llEsqueceuSenha.TabStop = true;
            llEsqueceuSenha.Text = "Esqueceu a Senha?";
            llEsqueceuSenha.LinkClicked += llEsqueceuSenha_LinkClicked;
            // 
            // chkLembrarUsuario
            // 
            chkLembrarUsuario.AutoSize = true;
            chkLembrarUsuario.Location = new Point(112, 233);
            chkLembrarUsuario.Name = "chkLembrarUsuario";
            chkLembrarUsuario.Size = new Size(113, 19);
            chkLembrarUsuario.TabIndex = 8;
            chkLembrarUsuario.Text = "Lembrar Usuário";
            chkLembrarUsuario.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label5.Location = new Point(79, -2);
            label5.Name = "label5";
            label5.Size = new Size(189, 41);
            label5.TabIndex = 13;
            label5.Text = "Guardião 5S";
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Transparent;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.ForeColor = Color.Transparent;
            btnFechar.ImageKey = "Close.png";
            btnFechar.ImageList = imageList1;
            btnFechar.Location = new Point(311, 2);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(26, 25);
            btnFechar.TabIndex = 14;
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // lblVersao
            // 
            lblVersao.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblVersao.AutoSize = true;
            lblVersao.Font = new Font("Segoe UI", 8F);
            lblVersao.ForeColor = Color.FromArgb(150, 150, 150);
            lblVersao.Location = new Point(143, 370);
            lblVersao.Name = "lblVersao";
            lblVersao.Size = new Size(38, 13);
            lblVersao.TabIndex = 15;
            lblVersao.Text = "label3";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(339, 392);
            Controls.Add(lblVersao);
            Controls.Add(btnFechar);
            Controls.Add(label5);
            Controls.Add(chkLembrarUsuario);
            Controls.Add(llEsqueceuSenha);
            Controls.Add(llNovoCadastro);
            Controls.Add(pictureBox1);
            Controls.Add(btnEntrar);
            Controls.Add(txtSenha);
            Controls.Add(txtUsuario);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsuario;
        private TextBox txtSenha;
        private Button btnEntrar;
        private PictureBox pictureBox1;
        private LinkLabel llNovoCadastro;
        private LinkLabel llEsqueceuSenha;
        private CheckBox chkLembrarUsuario;
        private ImageList imageList1;
        private Label label5;
        private Button btnFechar;
        private Label lblVersao;
    }
}
