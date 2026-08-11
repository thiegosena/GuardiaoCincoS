namespace GuardiaoCincoS.Formularios
{
    partial class FrmPrincipal
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            menuStrip1 = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            mnuCadastrosColaboradores = new ToolStripMenuItem();
            mnuCadastrosEscala5S = new ToolStripMenuItem();
            sistemaToolStripMenuItem = new ToolStripMenuItem();
            mnuSistemaSair = new ToolStripMenuItem();
            mnuRondas = new ToolStripMenuItem();
            mnuAuditorias = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatusUsuario = new ToolStripStatusLabel();
            panel1 = new Panel();
            btnFechar = new Button();
            imageList1 = new ImageList(components);
            label5 = new Label();
            mnuDemarcacoes = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem, mnuRondas, mnuAuditorias, mnuDemarcacoes, sistemaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 53);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(480, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuCadastrosColaboradores, mnuCadastrosEscala5S });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // mnuCadastrosColaboradores
            // 
            mnuCadastrosColaboradores.Name = "mnuCadastrosColaboradores";
            mnuCadastrosColaboradores.Size = new Size(169, 22);
            mnuCadastrosColaboradores.Text = "Colaboradores";
            mnuCadastrosColaboradores.Click += mnuCadastrosColaboradores_Click;
            // 
            // mnuCadastrosEscala5S
            // 
            mnuCadastrosEscala5S.Name = "mnuCadastrosEscala5S";
            mnuCadastrosEscala5S.Size = new Size(169, 22);
            mnuCadastrosEscala5S.Text = "Escala 5S Semanal";
            mnuCadastrosEscala5S.Click += mnuCadastrosEscala5S_Click;
            // 
            // sistemaToolStripMenuItem
            // 
            sistemaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuSistemaSair });
            sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            sistemaToolStripMenuItem.Size = new Size(60, 20);
            sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // mnuSistemaSair
            // 
            mnuSistemaSair.Name = "mnuSistemaSair";
            mnuSistemaSair.Size = new Size(93, 22);
            mnuSistemaSair.Text = "Sair";
            mnuSistemaSair.Click += mnuSistemaSair_Click;
            // 
            // mnuRondas
            // 
            mnuRondas.Name = "mnuRondas";
            mnuRondas.Size = new Size(58, 20);
            mnuRondas.Text = "Rondas";
            mnuRondas.Click += mnuRondas_Click;
            // 
            // mnuAuditorias
            // 
            mnuAuditorias.Name = "mnuAuditorias";
            mnuAuditorias.Size = new Size(73, 20);
            mnuAuditorias.Text = "Auditorias";
            mnuAuditorias.Click += mnuAuditorias_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatusUsuario });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusUsuario
            // 
            lblStatusUsuario.Name = "lblStatusUsuario";
            lblStatusUsuario.Size = new Size(118, 17);
            lblStatusUsuario.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(btnFechar);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 50);
            panel1.TabIndex = 0;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Black;
            btnFechar.BackgroundImageLayout = ImageLayout.None;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.ForeColor = Color.Transparent;
            btnFechar.ImageKey = "Close.png";
            btnFechar.ImageList = imageList1;
            btnFechar.Location = new Point(771, 3);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(26, 25);
            btnFechar.TabIndex = 15;
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Close.png");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(280, 6);
            label5.Name = "label5";
            label5.Size = new Size(206, 41);
            label5.TabIndex = 14;
            label5.Text = "Tela Principal";
            // 
            // mnuDemarcacoes
            // 
            mnuDemarcacoes.Name = "mnuDemarcacoes";
            mnuDemarcacoes.Size = new Size(90, 20);
            mnuDemarcacoes.Text = "Demarcações";
            mnuDemarcacoes.Click += mnuDemarcacoes_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(menuStrip1);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tela Principal";
            Load += FrmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem mnuCadastrosColaboradores;
        private ToolStripMenuItem mnuCadastrosEscala5S;
        private ToolStripMenuItem sistemaToolStripMenuItem;
        private ToolStripMenuItem mnuSistemaSair;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatusUsuario;
        private ToolStripMenuItem mnuRondas;
        private ToolStripMenuItem mnuAuditorias;
        private Panel panel1;
        private Label label5;
        private Button btnFechar;
        private ImageList imageList1;
        private ToolStripMenuItem mnuDemarcacoes;
    }
}