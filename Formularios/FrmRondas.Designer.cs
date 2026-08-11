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
            dgvRondas = new DataGridView();
            chkSomentePendentes = new CheckBox();
            label1 = new Label();
            dtpDataRonda = new DateTimePicker();
            label2 = new Label();
            cboTipoRonda = new ComboBox();
            label3 = new Label();
            cboColaboradorRonda = new ComboBox();
            btnAgendarRonda = new Button();
            label4 = new Label();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(204, 230);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 2;
            label1.Text = "Data";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(415, 229);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 4;
            label2.Text = "Tipo";
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(589, 231);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 6;
            label3.Text = "Colaborador";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(572, 283);
            label4.Name = "label4";
            label4.Size = new Size(147, 15);
            label4.TabIndex = 9;
            label4.Text = "Observações da conclusão";
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
            ClientSize = new Size(874, 450);
            Controls.Add(btnConcluirRonda);
            Controls.Add(txtObservacoesConclusao);
            Controls.Add(label4);
            Controls.Add(btnAgendarRonda);
            Controls.Add(cboColaboradorRonda);
            Controls.Add(label3);
            Controls.Add(cboTipoRonda);
            Controls.Add(label2);
            Controls.Add(dtpDataRonda);
            Controls.Add(label1);
            Controls.Add(chkSomentePendentes);
            Controls.Add(dgvRondas);
            Name = "FrmRondas";
            Text = "FrmRondas";
            Load += FrmRondas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRondas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRondas;
        private CheckBox chkSomentePendentes;
        private Label label1;
        private DateTimePicker dtpDataRonda;
        private Label label2;
        private ComboBox cboTipoRonda;
        private Label label3;
        private ComboBox cboColaboradorRonda;
        private Button btnAgendarRonda;
        private Label label4;
        private TextBox txtObservacoesConclusao;
        private Button btnConcluirRonda;
    }
}