namespace GuardiaoCincoS.Formularios
{
    partial class FrmRondas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRondas));
            dgvRondas = new DataGridView();
            chkSomentePendentes = new CheckBox();
            dtpDataRonda = new DateTimePicker();
            cboTipoRonda = new ComboBox();
            cboColaboradorRonda = new ComboBox();
            btnAgendarRonda = new Button();
            txtObservacoesConclusao = new TextBox();
            btnConcluirRonda = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRondas).BeginInit();
            SuspendLayout();
            // 
            // dgvRondas
            // 
            dgvRondas.AllowUserToAddRows = false;
            dgvRondas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRondas.Location = new Point(2, 2);
            dgvRondas.MultiSelect = false;
            dgvRondas.Name = "dgvRondas";
            dgvRondas.ReadOnly = true;
            dgvRondas.Size = new Size(870, 221);
            dgvRondas.TabIndex = 0;
            dgvRondas.CellClick += dgvRondas_CellClick;
            // 
            // chkSomentePendentes
            // 
            chkSomentePendentes.AutoSize = true;
            chkSomentePendentes.Location = new Point(12, 229);
            chkSomentePendentes.Name = "chkSomentePendentes";
            chkSomentePendentes.Size = new Size(174, 19);
            chkSomentePendentes.TabIndex = 1;
            chkSomentePendentes.Text = "Mostrar somente pendentes";
            chkSomentePendentes.UseVisualStyleBackColor = true;
            chkSomentePendentes.CheckedChanged += chkSomentePendentes_CheckedChanged;
            // 
            // dtpDataRonda
            // 
            dtpDataRonda.Format = DateTimePickerFormat.Short;
            dtpDataRonda.Location = new Point(241, 225);
            dtpDataRonda.Name = "dtpDataRonda";
            dtpDataRonda.Size = new Size(158, 23);
            dtpDataRonda.TabIndex = 3;
            dtpDataRonda.ValueChanged += dtpDataRonda_ValueChanged;
            // 
            // cboTipoRonda
            // 
            cboTipoRonda.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoRonda.FormattingEnabled = true;
            cboTipoRonda.Location = new Point(452, 227);
            cboTipoRonda.Name = "cboTipoRonda";
            cboTipoRonda.Size = new Size(121, 23);
            cboTipoRonda.TabIndex = 5;
            // 
            // cboColaboradorRonda
            // 
            cboColaboradorRonda.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColaboradorRonda.FormattingEnabled = true;
            cboColaboradorRonda.Location = new Point(668, 227);
            cboColaboradorRonda.Name = "cboColaboradorRonda";
            cboColaboradorRonda.Size = new Size(147, 23);
            cboColaboradorRonda.TabIndex = 7;
            // 
            // btnAgendarRonda
            // 
            btnAgendarRonda.Location = new Point(12, 400);
            btnAgendarRonda.Name = "btnAgendarRonda";
            btnAgendarRonda.Size = new Size(168, 38);
            btnAgendarRonda.TabIndex = 8;
            btnAgendarRonda.Text = "Agendar Ronda";
            btnAgendarRonda.UseVisualStyleBackColor = true;
            btnAgendarRonda.Click += btnAgendarRonda_Click;
            // 
            // txtObservacoesConclusao
            // 
            txtObservacoesConclusao.Location = new Point(464, 301);
            txtObservacoesConclusao.Multiline = true;
            txtObservacoesConclusao.Name = "txtObservacoesConclusao";
            txtObservacoesConclusao.Size = new Size(351, 137);
            txtObservacoesConclusao.TabIndex = 10;
            // 
            // btnConcluirRonda
            // 
            btnConcluirRonda.Location = new Point(258, 400);
            btnConcluirRonda.Name = "btnConcluirRonda";
            btnConcluirRonda.Size = new Size(168, 38);
            btnConcluirRonda.TabIndex = 11;
            btnConcluirRonda.Text = "Concluir Ronda Selecionada";
            btnConcluirRonda.UseVisualStyleBackColor = true;
            btnConcluirRonda.Click += btnConcluirRonda_Click;
            // 
            // FrmRondas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 861);
            Controls.Add(btnConcluirRonda);
            Controls.Add(txtObservacoesConclusao);
            Controls.Add(btnAgendarRonda);
            Controls.Add(cboColaboradorRonda);
            Controls.Add(cboTipoRonda);
            Controls.Add(dtpDataRonda);
            Controls.Add(chkSomentePendentes);
            Controls.Add(dgvRondas);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmRondas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rondas Internas";
            Load += FrmRondas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRondas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRondas;
        private CheckBox chkSomentePendentes;
        private DateTimePicker dtpDataRonda;
        private ComboBox cboTipoRonda;
        private ComboBox cboColaboradorRonda;
        private Button btnAgendarRonda;
        private TextBox txtObservacoesConclusao;
        private Button btnConcluirRonda;
    }
}