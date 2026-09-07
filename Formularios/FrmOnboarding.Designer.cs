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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOnboarding));
            dgvOnboardings = new DataGridView();
            cboColaboradorOnboarding = new ComboBox();
            dtpDataInicioOnboarding = new DateTimePicker();
            btnIniciarOnboarding = new Button();
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
            // cboColaboradorOnboarding
            // 
            cboColaboradorOnboarding.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColaboradorOnboarding.FormattingEnabled = true;
            cboColaboradorOnboarding.Location = new Point(93, 168);
            cboColaboradorOnboarding.Name = "cboColaboradorOnboarding";
            cboColaboradorOnboarding.Size = new Size(147, 23);
            cboColaboradorOnboarding.TabIndex = 2;
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
            ClientSize = new Size(934, 811);
            Controls.Add(btnFechar);
            Controls.Add(btnConcluirOnboarding);
            Controls.Add(btnSalvarProgresso);
            Controls.Add(dgvChecklistOnboarding);
            Controls.Add(btnIniciarOnboarding);
            Controls.Add(dtpDataInicioOnboarding);
            Controls.Add(cboColaboradorOnboarding);
            Controls.Add(dgvOnboardings);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmOnboarding";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Onboarding";
            Load += FrmOnboarding_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOnboardings).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChecklistOnboarding).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvOnboardings;
        private ComboBox cboColaboradorOnboarding;
        private DateTimePicker dtpDataInicioOnboarding;
        private Button btnIniciarOnboarding;
        private DataGridView dgvChecklistOnboarding;
        private Button btnSalvarProgresso;
        private Button btnConcluirOnboarding;
        private Button btnFechar;
    }
}