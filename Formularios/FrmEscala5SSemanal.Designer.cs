namespace GuardiaoCincoS.Formularios
{
    partial class FrmEscala5SSemanal
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
            label1 = new Label();
            dtpInicioSemana = new DateTimePicker();
            lblFimSemana = new Label();
            btnCarregarSemana = new Button();
            clbColaboradores = new CheckedListBox();
            btnSalvarEscala = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 26);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Início da semana";
            // 
            // dtpInicioSemana
            // 
            dtpInicioSemana.Format = DateTimePickerFormat.Short;
            dtpInicioSemana.Location = new Point(128, 20);
            dtpInicioSemana.Name = "dtpInicioSemana";
            dtpInicioSemana.Size = new Size(131, 23);
            dtpInicioSemana.TabIndex = 1;
            // 
            // lblFimSemana
            // 
            lblFimSemana.AutoSize = true;
            lblFimSemana.Location = new Point(265, 26);
            lblFimSemana.Name = "lblFimSemana";
            lblFimSemana.Size = new Size(38, 15);
            lblFimSemana.TabIndex = 2;
            lblFimSemana.Text = "label2";
            // 
            // btnCarregarSemana
            // 
            btnCarregarSemana.Location = new Point(38, 53);
            btnCarregarSemana.Name = "btnCarregarSemana";
            btnCarregarSemana.Size = new Size(75, 23);
            btnCarregarSemana.TabIndex = 3;
            btnCarregarSemana.Text = "Carregar";
            btnCarregarSemana.UseVisualStyleBackColor = true;
            btnCarregarSemana.Click += btnCarregarSemana_Click;
            // 
            // clbColaboradores
            // 
            clbColaboradores.FormattingEnabled = true;
            clbColaboradores.Location = new Point(2, 103);
            clbColaboradores.Name = "clbColaboradores";
            clbColaboradores.Size = new Size(797, 346);
            clbColaboradores.TabIndex = 4;
            // 
            // btnSalvarEscala
            // 
            btnSalvarEscala.Location = new Point(693, 53);
            btnSalvarEscala.Name = "btnSalvarEscala";
            btnSalvarEscala.Size = new Size(95, 23);
            btnSalvarEscala.TabIndex = 5;
            btnSalvarEscala.Text = "Salvar Escala";
            btnSalvarEscala.UseVisualStyleBackColor = true;
            btnSalvarEscala.Click += btnSalvarEscala_Click;
            // 
            // FrmEscala5SSemanal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalvarEscala);
            Controls.Add(clbColaboradores);
            Controls.Add(btnCarregarSemana);
            Controls.Add(lblFimSemana);
            Controls.Add(dtpInicioSemana);
            Controls.Add(label1);
            Name = "FrmEscala5SSemanal";
            Text = "FrmEscala5SSemanal";
            Load += FrmEscala5SSemanal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpInicioSemana;
        private Label lblFimSemana;
        private Button btnCarregarSemana;
        private CheckedListBox clbColaboradores;
        private Button btnSalvarEscala;
    }
}