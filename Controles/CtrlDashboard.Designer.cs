namespace GuardiaoCincoS.Controles
{
    partial class CtrlDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlCabecalho = new Panel();
            btnWhatsApp = new Button();
            btnExportarPdf = new Button();
            btnAtualizarDashboard = new Button();
            lblDataHora = new Label();
            lblSaudacao = new Label();
            flpCards = new FlowLayoutPanel();
            splitCorpo = new SplitContainer();
            dgvPendencias = new DataGridView();
            lblTituloPendencias = new Label();
            tmrRelogio = new System.Windows.Forms.Timer(components);
            pnlCabecalho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitCorpo).BeginInit();
            splitCorpo.Panel1.SuspendLayout();
            splitCorpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendencias).BeginInit();
            SuspendLayout();
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.BackColor = Color.FromArgb(27, 42, 74);
            pnlCabecalho.Controls.Add(btnWhatsApp);
            pnlCabecalho.Controls.Add(btnExportarPdf);
            pnlCabecalho.Controls.Add(btnAtualizarDashboard);
            pnlCabecalho.Controls.Add(lblDataHora);
            pnlCabecalho.Controls.Add(lblSaudacao);
            pnlCabecalho.Dock = DockStyle.Top;
            pnlCabecalho.Location = new Point(0, 0);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(1094, 80);
            pnlCabecalho.TabIndex = 0;
            // 
            // btnWhatsApp
            // 
            btnWhatsApp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnWhatsApp.Location = new Point(594, 24);
            btnWhatsApp.Name = "btnWhatsApp";
            btnWhatsApp.Size = new Size(114, 23);
            btnWhatsApp.TabIndex = 4;
            btnWhatsApp.Text = "Enviar WhatsApp";
            btnWhatsApp.UseVisualStyleBackColor = true;
            btnWhatsApp.Click += btnWhatsApp_Click;
            // 
            // btnExportarPdf
            // 
            btnExportarPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportarPdf.Location = new Point(752, 24);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(92, 23);
            btnExportarPdf.TabIndex = 3;
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = true;
            btnExportarPdf.Click += btnExportarPdf_Click;
            // 
            // btnAtualizarDashboard
            // 
            btnAtualizarDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAtualizarDashboard.Location = new Point(900, 24);
            btnAtualizarDashboard.Name = "btnAtualizarDashboard";
            btnAtualizarDashboard.Size = new Size(75, 23);
            btnAtualizarDashboard.TabIndex = 2;
            btnAtualizarDashboard.Text = "Atualizar";
            btnAtualizarDashboard.UseVisualStyleBackColor = true;
            btnAtualizarDashboard.Click += btnAtualizarDashboard_Click;
            // 
            // lblDataHora
            // 
            lblDataHora.AutoSize = true;
            lblDataHora.ForeColor = Color.White;
            lblDataHora.Location = new Point(24, 46);
            lblDataHora.Name = "lblDataHora";
            lblDataHora.Size = new Size(78, 15);
            lblDataHora.TabIndex = 1;
            lblDataHora.Text = "Carregando...";
            // 
            // lblSaudacao
            // 
            lblSaudacao.AutoSize = true;
            lblSaudacao.ForeColor = Color.White;
            lblSaudacao.Location = new Point(24, 14);
            lblSaudacao.Name = "lblSaudacao";
            lblSaudacao.Size = new Size(69, 15);
            lblSaudacao.TabIndex = 0;
            lblSaudacao.Text = "Bem-vindo!";
            // 
            // flpCards
            // 
            flpCards.AutoScroll = true;
            flpCards.BackColor = Color.FromArgb(244, 246, 249);
            flpCards.Dock = DockStyle.Top;
            flpCards.Location = new Point(0, 80);
            flpCards.Name = "flpCards";
            flpCards.Padding = new Padding(12);
            flpCards.Size = new Size(1094, 150);
            flpCards.TabIndex = 1;
            // 
            // splitCorpo
            // 
            splitCorpo.Dock = DockStyle.Fill;
            splitCorpo.Location = new Point(0, 230);
            splitCorpo.Name = "splitCorpo";
            // 
            // splitCorpo.Panel1
            // 
            splitCorpo.Panel1.Controls.Add(dgvPendencias);
            splitCorpo.Panel1.Controls.Add(lblTituloPendencias);
            splitCorpo.Size = new Size(1094, 389);
            splitCorpo.SplitterDistance = 622;
            splitCorpo.TabIndex = 2;
            // 
            // dgvPendencias
            // 
            dgvPendencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendencias.Dock = DockStyle.Fill;
            dgvPendencias.Location = new Point(0, 34);
            dgvPendencias.Name = "dgvPendencias";
            dgvPendencias.Size = new Size(622, 355);
            dgvPendencias.TabIndex = 1;
            // 
            // lblTituloPendencias
            // 
            lblTituloPendencias.Dock = DockStyle.Top;
            lblTituloPendencias.Location = new Point(0, 0);
            lblTituloPendencias.Name = "lblTituloPendencias";
            lblTituloPendencias.Size = new Size(622, 34);
            lblTituloPendencias.TabIndex = 0;
            lblTituloPendencias.Text = "Pendências dos Guardiões";
            lblTituloPendencias.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tmrRelogio
            // 
            tmrRelogio.Enabled = true;
            tmrRelogio.Interval = 1000;
            tmrRelogio.Tick += tmrRelogio_Tick;
            // 
            // CtrlDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitCorpo);
            Controls.Add(flpCards);
            Controls.Add(pnlCabecalho);
            Name = "CtrlDashboard";
            Size = new Size(1094, 619);
            pnlCabecalho.ResumeLayout(false);
            pnlCabecalho.PerformLayout();
            splitCorpo.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitCorpo).EndInit();
            splitCorpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPendencias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCabecalho;
        private Label lblDataHora;
        private Label lblSaudacao;
        private Button btnAtualizarDashboard;
        private FlowLayoutPanel flpCards;
        private SplitContainer splitCorpo;
        private Label lblTituloPendencias;
        private DataGridView dgvPendencias;
        private System.Windows.Forms.Timer tmrRelogio;
        private Button btnWhatsApp;
        private Button btnExportarPdf;
    }
}
