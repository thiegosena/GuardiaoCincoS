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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmColaboradores));
            dgvColaboradores = new DataGridView();
            txtNome = new TextBox();
            txtSetor = new TextBox();
            cboTurno = new ComboBox();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnInativar = new Button();
            chkMostrarInativos = new CheckBox();
            btnEditar = new Button();
            btnCancelarEdicao = new Button();
            btnReativar = new Button();
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
            dgvColaboradores.Size = new Size(982, 225);
            dgvColaboradores.TabIndex = 0;
            dgvColaboradores.CellClick += dgvColaboradores_CellClick;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(145, 287);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(216, 23);
            txtNome.TabIndex = 2;
            // 
            // txtSetor
            // 
            txtSetor.Location = new Point(464, 287);
            txtSetor.Name = "txtSetor";
            txtSetor.Size = new Size(147, 23);
            txtSetor.TabIndex = 4;
            // 
            // cboTurno
            // 
            cboTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTurno.FormattingEnabled = true;
            cboTurno.Items.AddRange(new object[] { "1º Turno", "2º Turno", "3º Turno", "Geral" });
            cboTurno.Location = new Point(688, 287);
            cboTurno.Name = "cboTurno";
            cboTurno.Size = new Size(121, 23);
            cboTurno.TabIndex = 6;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(-15, 473);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(105, 31);
            btnNovo.TabIndex = 7;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(147, 473);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(105, 31);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnInativar
            // 
            btnInativar.Location = new Point(794, 473);
            btnInativar.Name = "btnInativar";
            btnInativar.Size = new Size(105, 31);
            btnInativar.TabIndex = 9;
            btnInativar.Text = "Inativar";
            btnInativar.UseVisualStyleBackColor = true;
            btnInativar.Click += btnInativar_Click;
            // 
            // chkMostrarInativos
            // 
            chkMostrarInativos.AutoSize = true;
            chkMostrarInativos.Location = new Point(13, 232);
            chkMostrarInativos.Name = "chkMostrarInativos";
            chkMostrarInativos.Size = new Size(111, 19);
            chkMostrarInativos.TabIndex = 10;
            chkMostrarInativos.Text = "Mostrar inativos";
            chkMostrarInativos.UseVisualStyleBackColor = true;
            chkMostrarInativos.CheckedChanged += chkMostrarInativos_CheckedChanged;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(300, 473);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(105, 31);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnCancelarEdicao
            // 
            btnCancelarEdicao.Location = new Point(458, 473);
            btnCancelarEdicao.Name = "btnCancelarEdicao";
            btnCancelarEdicao.Size = new Size(105, 31);
            btnCancelarEdicao.TabIndex = 11;
            btnCancelarEdicao.Text = "Cancelar Edição";
            btnCancelarEdicao.UseVisualStyleBackColor = true;
            btnCancelarEdicao.Click += btnCancelarEdicao_Click;
            // 
            // btnReativar
            // 
            btnReativar.Location = new Point(629, 473);
            btnReativar.Name = "btnReativar";
            btnReativar.Size = new Size(105, 31);
            btnReativar.TabIndex = 13;
            btnReativar.Text = "Reativar";
            btnReativar.UseVisualStyleBackColor = true;
            btnReativar.Click += btnReativar_Click;
            // 
            // FrmColaboradores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 661);
            Controls.Add(btnReativar);
            Controls.Add(btnEditar);
            Controls.Add(btnCancelarEdicao);
            Controls.Add(chkMostrarInativos);
            Controls.Add(btnInativar);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(cboTurno);
            Controls.Add(txtSetor);
            Controls.Add(txtNome);
            Controls.Add(dgvColaboradores);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmColaboradores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Colaboradores";
            Load += FrmColaboradores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvColaboradores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvColaboradores;
        private TextBox txtNome;
        private TextBox txtSetor;
        private ComboBox cboTurno;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnInativar;
        private CheckBox chkMostrarInativos;
        private Button btnEditar;
        private Button btnCancelarEdicao;
        private Button btnReativar;
    }
}