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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEscala5SSemanal));
            dtpInicioSemana = new DateTimePicker();
            btnCarregarSemana = new Button();
            clbColaboradores = new CheckedListBox();
            btnSalvarEscala = new Button();
            lblFimSemana = new Label();
            SuspendLayout();
            // 
            // dtpInicioSemana
            // 
            dtpInicioSemana.Format = DateTimePickerFormat.Short;
            dtpInicioSemana.Location = new Point(128, 20);
            dtpInicioSemana.Name = "dtpInicioSemana";
            dtpInicioSemana.Size = new Size(131, 23);
            dtpInicioSemana.TabIndex = 1;
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
            clbColaboradores.Size = new Size(571, 346);
            clbColaboradores.TabIndex = 4;
            // 
            // btnSalvarEscala
            // 
            btnSalvarEscala.Location = new Point(329, 498);
            btnSalvarEscala.Name = "btnSalvarEscala";
            btnSalvarEscala.Size = new Size(95, 23);
            btnSalvarEscala.TabIndex = 5;
            btnSalvarEscala.Text = "Salvar Escala";
            btnSalvarEscala.UseVisualStyleBackColor = true;
            btnSalvarEscala.Click += btnSalvarEscala_Click;
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
            // FrmEscala5SSemanal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 611);
            Controls.Add(btnSalvarEscala);
            Controls.Add(clbColaboradores);
            Controls.Add(btnCarregarSemana);
            Controls.Add(lblFimSemana);
            Controls.Add(dtpInicioSemana);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmEscala5SSemanal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Escala 5S";
            Load += FrmEscala5SSemanal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dtpInicioSemana;
        private Button btnCarregarSemana;
        private CheckedListBox clbColaboradores;
        private Button btnSalvarEscala;
        private Label lblFimSemana;
    }
}