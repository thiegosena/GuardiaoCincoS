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
            linklbNovoUsuario = new LinkLabel();
            linklbEsqueceuSenha = new LinkLabel();
            chkLembrarUsuario = new CheckBox();
            label5 = new Label();
            btnFechar = new Button();
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
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(128, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(82, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // linklbNovoUsuario
            // 
            linklbNovoUsuario.AutoSize = true;
            linklbNovoUsuario.Location = new Point(12, 369);
            linklbNovoUsuario.Name = "linklbNovoUsuario";
            linklbNovoUsuario.Size = new Size(86, 15);
            linklbNovoUsuario.TabIndex = 6;
            linklbNovoUsuario.TabStop = true;
            linklbNovoUsuario.Text = "Novo Cadastro";
            // 
            // linklbEsqueceuSenha
            // 
            linklbEsqueceuSenha.AutoSize = true;
            linklbEsqueceuSenha.Location = new Point(221, 369);
            linklbEsqueceuSenha.Name = "linklbEsqueceuSenha";
            linklbEsqueceuSenha.Size = new Size(106, 15);
            linklbEsqueceuSenha.TabIndex = 7;
            linklbEsqueceuSenha.TabStop = true;
            linklbEsqueceuSenha.Text = "Esqueceu a Senha?";
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
            label5.Location = new Point(123, -2);
            label5.Name = "label5";
            label5.Size = new Size(97, 41);
            label5.TabIndex = 13;
            label5.Text = "Login";
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
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(339, 392);
            Controls.Add(btnFechar);
            Controls.Add(label5);
            Controls.Add(chkLembrarUsuario);
            Controls.Add(linklbEsqueceuSenha);
            Controls.Add(linklbNovoUsuario);
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
        private LinkLabel linklbNovoUsuario;
        private LinkLabel linklbEsqueceuSenha;
        private CheckBox chkLembrarUsuario;
        private ImageList imageList1;
        private Label label5;
        private Button btnFechar;
    }
}
