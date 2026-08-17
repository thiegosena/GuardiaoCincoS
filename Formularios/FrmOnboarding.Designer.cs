namespace GuardiaoCincoS.Formularios
{
    partial class FrmOnboarding
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
            dgvOnboardings = new DataGridView();
            label1 = new Label();
            cboColaboradorOnboarding = new ComboBox();
            label2 = new Label();
            dtpDataInicioOnboarding = new DateTimePicker();
            btnIniciarOnboarding = new Button();
            label3 = new Label();
            dgvChecklistOnboarding = new DataGridView();
            btnSalvarProgresso = new Button();
            btnConcluirOnboarding = new Button();
            btnFechar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOnboardings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChecklistOnboarding).BeginInit();
            SuspendLayout();
            // 
            // dgvOnboardings
            // 
            dgvOnboardings.AllowUserToAddRows = false;
            dgvOnboardings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOnboardings.Location = new Point(12, 12);
            dgvOnboardings.MultiSelect = false;
            dgvOnboardings.Name = "dgvOnboardings";
            dgvOnboardings.ReadOnly = true;
            dgvOnboardings.Size = new Size(776, 150);
            dgvOnboardings.TabIndex = 0;
            dgvOnboardings.CellClick += dgvOnboardings_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 171);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 1;
            label1.Text = "Colaborador";
            // 
            // cboColaboradorOnboarding
            // 
            cboColaboradorOnboarding.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColaboradorOnboarding.FormattingEnabled = true;
            cboColaboradorOnboarding.Location = new Point(93, 168);
            cboColaboradorOnboarding.Name = "cboColaboradorOnboarding";
            cboColaboradorOnboarding.Size = new Size(147, 23);
            cboColaboradorOnboarding.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 171);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 3;
            label2.Text = "Data de início";
            // 
            // dtpDataInicioOnboarding
            // 
            dtpDataInicioOnboarding.Format = DateTimePickerFormat.Short;
            dtpDataInicioOnboarding.Location = new Point(331, 168);
            dtpDataInicioOnboarding.Name = "dtpDataInicioOnboarding";
            dtpDataInicioOnboarding.Size = new Size(123, 23);
            dtpDataInicioOnboarding.TabIndex = 4;
            // 
            // btnIniciarOnboarding
            // 
            btnIniciarOnboarding.Location = new Point(652, 167);
            btnIniciarOnboarding.Name = "btnIniciarOnboarding";
            btnIniciarOnboarding.Size = new Size(122, 23);
            btnIniciarOnboarding.TabIndex = 5;
            btnIniciarOnboarding.Text = "Iniciar Onboarding";
            btnIniciarOnboarding.UseVisualStyleBackColor = true;
            btnIniciarOnboarding.Click += btnIniciarOnboarding_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(282, 204);
            label3.Name = "label3";
            label3.Size = new Size(208, 15);
            label3.TabIndex = 6;
            label3.Text = "Checklist do onboarding selecionado";
            // 
            // dgvChecklistOnboarding
            // 
            dgvChecklistOnboarding.AllowUserToAddRows = false;
            dgvChecklistOnboarding.AllowUserToDeleteRows = false;
            dgvChecklistOnboarding.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChecklistOnboarding.Location = new Point(12, 231);
            dgvChecklistOnboarding.MultiSelect = false;
            dgvChecklistOnboarding.Name = "dgvChecklistOnboarding";
            dgvChecklistOnboarding.RowHeadersVisible = false;
            dgvChecklistOnboarding.Size = new Size(776, 150);
            dgvChecklistOnboarding.TabIndex = 7;
            // 
            // btnSalvarProgresso
            // 
            btnSalvarProgresso.Location = new Point(652, 387);
            btnSalvarProgresso.Name = "btnSalvarProgresso";
            btnSalvarProgresso.Size = new Size(122, 23);
            btnSalvarProgresso.TabIndex = 8;
            btnSalvarProgresso.Text = "Salvar Progresso";
            btnSalvarProgresso.UseVisualStyleBackColor = true;
            btnSalvarProgresso.Click += btnSalvarProgresso_Click;
            // 
            // btnConcluirOnboarding
            // 
            btnConcluirOnboarding.Location = new Point(12, 516);
            btnConcluirOnboarding.Name = "btnConcluirOnboarding";
            btnConcluirOnboarding.Size = new Size(134, 33);
            btnConcluirOnboarding.TabIndex = 9;
            btnConcluirOnboarding.Text = "Concluir Onboarding";
            btnConcluirOnboarding.UseVisualStyleBackColor = true;
            btnConcluirOnboarding.Click += btnConcluirOnboarding_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(654, 516);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(134, 33);
            btnFechar.TabIndex = 10;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // FrmOnboarding
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 561);
            Controls.Add(btnFechar);
            Controls.Add(btnConcluirOnboarding);
            Controls.Add(btnSalvarProgresso);
            Controls.Add(dgvChecklistOnboarding);
            Controls.Add(label3);
            Controls.Add(btnIniciarOnboarding);
            Controls.Add(dtpDataInicioOnboarding);
            Controls.Add(label2);
            Controls.Add(cboColaboradorOnboarding);
            Controls.Add(label1);
            Controls.Add(dgvOnboardings);
            Name = "FrmOnboarding";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Onboarding";
            Load += FrmOnboarding_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOnboardings).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChecklistOnboarding).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvOnboardings;
        private Label label1;
        private ComboBox cboColaboradorOnboarding;
        private Label label2;
        private DateTimePicker dtpDataInicioOnboarding;
        private Button btnIniciarOnboarding;
        private Label label3;
        private DataGridView dgvChecklistOnboarding;
        private Button btnSalvarProgresso;
        private Button btnConcluirOnboarding;
        private Button btnFechar;
    }
}