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
            menuStrip1 = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            mnuCadastrosColaboradores = new ToolStripMenuItem();
            mnuCadastrosEscala5S = new ToolStripMenuItem();
            sistemaToolStripMenuItem = new ToolStripMenuItem();
            mnuSistemaSair = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatusUsuario = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem, sistemaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
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
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipal";
            Text = "Tela Principal";
            Load += FrmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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
    }
}