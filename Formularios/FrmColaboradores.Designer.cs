namespace GuardiaoCincoS.Formularios
{
    partial class FrmColaboradores
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
            dgvColaboradores = new DataGridView();
            label1 = new Label();
            txtNome = new TextBox();
            txtSetor = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cboTurno = new ComboBox();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnInativar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvColaboradores).BeginInit();
            SuspendLayout();
            // 
            // dgvColaboradores
            // 
            dgvColaboradores.AllowUserToAddRows = false;
            dgvColaboradores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvColaboradores.Location = new Point(12, 1);
            dgvColaboradores.MultiSelect = false;
            dgvColaboradores.Name = "dgvColaboradores";
            dgvColaboradores.ReadOnly = true;
            dgvColaboradores.Size = new Size(776, 225);
            dgvColaboradores.TabIndex = 0;
            dgvColaboradores.CellClick += dgvColaboradores_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 249);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(95, 246);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 2;
            // 
            // txtSetor
            // 
            txtSetor.Location = new Point(304, 246);
            txtSetor.Name = "txtSetor";
            txtSetor.Size = new Size(100, 23);
            txtSetor.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(258, 249);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 3;
            label2.Text = "Setor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(436, 249);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "Turno";
            // 
            // cboTurno
            // 
            cboTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTurno.FormattingEnabled = true;
            cboTurno.Items.AddRange(new object[] { "1º Turno", "2º Turno", "3º Turno", "Geral" });
            cboTurno.Location = new Point(481, 246);
            cboTurno.Name = "cboTurno";
            cboTurno.Size = new Size(121, 23);
            cboTurno.TabIndex = 6;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(74, 400);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(75, 23);
            btnNovo.TabIndex = 7;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(236, 400);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnInativar
            // 
            btnInativar.Location = new Point(400, 400);
            btnInativar.Name = "btnInativar";
            btnInativar.Size = new Size(75, 23);
            btnInativar.TabIndex = 9;
            btnInativar.Text = "Inativar";
            btnInativar.UseVisualStyleBackColor = true;
            btnInativar.Click += btnInativar_Click;
            // 
            // FrmColaboradores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnInativar);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(cboTurno);
            Controls.Add(label3);
            Controls.Add(txtSetor);
            Controls.Add(label2);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Controls.Add(dgvColaboradores);
            Name = "FrmColaboradores";
            Text = "FrmColaboradores";
            Load += FrmColaboradores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvColaboradores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvColaboradores;
        private Label label1;
        private TextBox txtNome;
        private TextBox txtSetor;
        private Label label2;
        private Label label3;
        private ComboBox cboTurno;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnInativar;
    }
}