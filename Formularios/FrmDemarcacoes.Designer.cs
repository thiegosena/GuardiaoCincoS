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
            label1 = new Label();
            txtLocal = new TextBox();
            label2 = new Label();
            txtDescricao = new TextBox();
            label3 = new Label();
            dtpDataIdentificacao = new DateTimePicker();
            dtpDataPrevista = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            cboResponsavel = new ComboBox();
            btnRegistrarDemarcacao = new Button();
            txtObservacoesConclusao = new TextBox();
            label6 = new Label();
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
            dgvDemarcacoes.Size = new Size(800, 152);
            dgvDemarcacoes.TabIndex = 0;
            dgvDemarcacoes.CellClick += dgvDemarcacoes_CellClick;
            // 
            // chkSomentePendentes
            // 
            chkSomentePendentes.AutoSize = true;
            chkSomentePendentes.Location = new Point(12, 158);
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
            label1.Location = new Point(203, 159);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 2;
            label1.Text = "Local";
            // 
            // txtLocal
            // 
            txtLocal.Location = new Point(244, 156);
            txtLocal.Name = "txtLocal";
            txtLocal.Size = new Size(127, 23);
            txtLocal.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(388, 159);
            label2.Name = "label2";
            label2.Size = new Size(160, 15);
            label2.TabIndex = 4;
            label2.Text = "O que precisa ser demarcado";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(554, 156);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(234, 76);
            txtDescricao.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 213);
            label3.Name = "label3";
            label3.Size = new Size(118, 15);
            label3.TabIndex = 6;
            label3.Text = "Data de identificação";
            // 
            // dtpDataIdentificacao
            // 
            dtpDataIdentificacao.Format = DateTimePickerFormat.Short;
            dtpDataIdentificacao.Location = new Point(135, 207);
            dtpDataIdentificacao.Name = "dtpDataIdentificacao";
            dtpDataIdentificacao.Size = new Size(142, 23);
            dtpDataIdentificacao.TabIndex = 7;
            // 
            // dtpDataPrevista
            // 
            dtpDataPrevista.Format = DateTimePickerFormat.Short;
            dtpDataPrevista.Location = new Point(397, 209);
            dtpDataPrevista.Name = "dtpDataPrevista";
            dtpDataPrevista.Size = new Size(142, 23);
            dtpDataPrevista.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(283, 215);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 8;
            label4.Text = "Prazo para concluir";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 311);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 10;
            label5.Text = "Responsável";
            // 
            // cboResponsavel
            // 
            cboResponsavel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboResponsavel.FormattingEnabled = true;
            cboResponsavel.Location = new Point(90, 308);
            cboResponsavel.Name = "cboResponsavel";
            cboResponsavel.Size = new Size(187, 23);
            cboResponsavel.TabIndex = 11;
            // 
            // btnRegistrarDemarcacao
            // 
            btnRegistrarDemarcacao.Font = new Font("Segoe UI", 10F);
            btnRegistrarDemarcacao.Location = new Point(12, 403);
            btnRegistrarDemarcacao.Name = "btnRegistrarDemarcacao";
            btnRegistrarDemarcacao.Size = new Size(226, 35);
            btnRegistrarDemarcacao.TabIndex = 12;
            btnRegistrarDemarcacao.Text = "Registrar Demarcação Pendente";
            btnRegistrarDemarcacao.UseVisualStyleBackColor = true;
            btnRegistrarDemarcacao.Click += btnRegistrarDemarcacao_Click;
            // 
            // txtObservacoesConclusao
            // 
            txtObservacoesConclusao.Location = new Point(554, 299);
            txtObservacoesConclusao.Multiline = true;
            txtObservacoesConclusao.Name = "txtObservacoesConclusao";
            txtObservacoesConclusao.Size = new Size(234, 85);
            txtObservacoesConclusao.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(401, 311);
            label6.Name = "label6";
            label6.Size = new Size(147, 15);
            label6.TabIndex = 13;
            label6.Text = "Observações da conclusão";
            // 
            // btnConcluirDemarcacao
            // 
            btnConcluirDemarcacao.Font = new Font("Segoe UI", 10F);
            btnConcluirDemarcacao.Location = new Point(562, 403);
            btnConcluirDemarcacao.Name = "btnConcluirDemarcacao";
            btnConcluirDemarcacao.Size = new Size(226, 35);
            btnConcluirDemarcacao.TabIndex = 15;
            btnConcluirDemarcacao.Text = "Concluir Demarcação Selecionada";
            btnConcluirDemarcacao.UseVisualStyleBackColor = true;
            btnConcluirDemarcacao.Click += btnConcluirDemarcacao_Click;
            // 
            // FrmDemarcacoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConcluirDemarcacao);
            Controls.Add(txtObservacoesConclusao);
            Controls.Add(label6);
            Controls.Add(btnRegistrarDemarcacao);
            Controls.Add(cboResponsavel);
            Controls.Add(label5);
            Controls.Add(dtpDataPrevista);
            Controls.Add(label4);
            Controls.Add(dtpDataIdentificacao);
            Controls.Add(label3);
            Controls.Add(txtDescricao);
            Controls.Add(label2);
            Controls.Add(txtLocal);
            Controls.Add(label1);
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
        private Label label1;
        private TextBox txtLocal;
        private Label label2;
        private TextBox txtDescricao;
        private Label label3;
        private DateTimePicker dtpDataIdentificacao;
        private DateTimePicker dtpDataPrevista;
        private Label label4;
        private Label label5;
        private ComboBox cboResponsavel;
        private Button btnRegistrarDemarcacao;
        private TextBox txtObservacoesConclusao;
        private Label label6;
        private Button btnConcluirDemarcacao;
    }
}