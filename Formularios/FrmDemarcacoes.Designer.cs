namespace GuardiaoCincoS.Formularios
{
    partial class FrmDemarcacoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDemarcacoes));
            dgvDemarcacoes = new DataGridView();
            chkSomentePendentes = new CheckBox();
            txtLocal = new TextBox();
            txtDescricao = new TextBox();
            dtpDataIdentificacao = new DateTimePicker();
            dtpDataPrevista = new DateTimePicker();
            cboResponsavel = new ComboBox();
            btnRegistrarDemarcacao = new Button();
            txtObservacoesConclusao = new TextBox();
            btnConcluirDemarcacao = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDemarcacoes).BeginInit();
            SuspendLayout();
            // 
            // dgvDemarcacoes
            // 
            dgvDemarcacoes.AllowUserToAddRows = false;
            dgvDemarcacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDemarcacoes.Dock = DockStyle.Top;
            dgvDemarcacoes.Location = new Point(0, 0);
            dgvDemarcacoes.MultiSelect = false;
            dgvDemarcacoes.Name = "dgvDemarcacoes";
            dgvDemarcacoes.ReadOnly = true;
            dgvDemarcacoes.Size = new Size(884, 152);
            dgvDemarcacoes.TabIndex = 0;
            dgvDemarcacoes.CellClick += dgvDemarcacoes_CellClick;
            // 
            // chkSomentePendentes
            // 
            chkSomentePendentes.AutoSize = true;
            chkSomentePendentes.Location = new Point(11, 158);
            chkSomentePendentes.Name = "chkSomentePendentes";
            chkSomentePendentes.Size = new Size(174, 19);
            chkSomentePendentes.TabIndex = 1;
            chkSomentePendentes.Text = "Mostrar somente pendentes";
            chkSomentePendentes.UseVisualStyleBackColor = true;
            chkSomentePendentes.CheckedChanged += chkSomentePendentes_CheckedChanged;
            // 
            // txtLocal
            // 
            txtLocal.Location = new Point(135, 221);
            txtLocal.Name = "txtLocal";
            txtLocal.Size = new Size(243, 23);
            txtLocal.TabIndex = 3;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(592, 168);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(280, 76);
            txtDescricao.TabIndex = 5;
            // 
            // dtpDataIdentificacao
            // 
            dtpDataIdentificacao.Format = DateTimePickerFormat.Short;
            dtpDataIdentificacao.Location = new Point(135, 272);
            dtpDataIdentificacao.Name = "dtpDataIdentificacao";
            dtpDataIdentificacao.Size = new Size(142, 23);
            dtpDataIdentificacao.TabIndex = 7;
            // 
            // dtpDataPrevista
            // 
            dtpDataPrevista.Format = DateTimePickerFormat.Short;
            dtpDataPrevista.Location = new Point(447, 272);
            dtpDataPrevista.Name = "dtpDataPrevista";
            dtpDataPrevista.Size = new Size(142, 23);
            dtpDataPrevista.TabIndex = 9;
            // 
            // cboResponsavel
            // 
            cboResponsavel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboResponsavel.FormattingEnabled = true;
            cboResponsavel.Location = new Point(90, 361);
            cboResponsavel.Name = "cboResponsavel";
            cboResponsavel.Size = new Size(187, 23);
            cboResponsavel.TabIndex = 11;
            // 
            // btnRegistrarDemarcacao
            // 
            btnRegistrarDemarcacao.Font = new Font("Segoe UI", 10F);
            btnRegistrarDemarcacao.Location = new Point(12, 476);
            btnRegistrarDemarcacao.Name = "btnRegistrarDemarcacao";
            btnRegistrarDemarcacao.Size = new Size(142, 35);
            btnRegistrarDemarcacao.TabIndex = 12;
            btnRegistrarDemarcacao.Text = "Registrar";
            btnRegistrarDemarcacao.UseVisualStyleBackColor = true;
            btnRegistrarDemarcacao.Click += btnRegistrarDemarcacao_Click;
            // 
            // txtObservacoesConclusao
            // 
            txtObservacoesConclusao.Location = new Point(566, 349);
            txtObservacoesConclusao.Multiline = true;
            txtObservacoesConclusao.Name = "txtObservacoesConclusao";
            txtObservacoesConclusao.Size = new Size(280, 85);
            txtObservacoesConclusao.TabIndex = 14;
            // 
            // btnConcluirDemarcacao
            // 
            btnConcluirDemarcacao.Font = new Font("Segoe UI", 10F);
            btnConcluirDemarcacao.Location = new Point(730, 476);
            btnConcluirDemarcacao.Name = "btnConcluirDemarcacao";
            btnConcluirDemarcacao.Size = new Size(142, 35);
            btnConcluirDemarcacao.TabIndex = 15;
            btnConcluirDemarcacao.Text = "Concluir";
            btnConcluirDemarcacao.UseVisualStyleBackColor = true;
            btnConcluirDemarcacao.Click += btnConcluirDemarcacao_Click;
            // 
            // FrmDemarcacoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 961);
            Controls.Add(btnConcluirDemarcacao);
            Controls.Add(txtObservacoesConclusao);
            Controls.Add(btnRegistrarDemarcacao);
            Controls.Add(cboResponsavel);
            Controls.Add(dtpDataPrevista);
            Controls.Add(dtpDataIdentificacao);
            Controls.Add(txtDescricao);
            Controls.Add(txtLocal);
            Controls.Add(chkSomentePendentes);
            Controls.Add(dgvDemarcacoes);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmDemarcacoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Controle de Demarcações";
            Load += FrmDemarcacoes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDemarcacoes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDemarcacoes;
        private CheckBox chkSomentePendentes;
        private TextBox txtLocal;
        private TextBox txtDescricao;
        private DateTimePicker dtpDataIdentificacao;
        private DateTimePicker dtpDataPrevista;
        private ComboBox cboResponsavel;
        private Button btnRegistrarDemarcacao;
        private TextBox txtObservacoesConclusao;
        private Button btnConcluirDemarcacao;
    }
}