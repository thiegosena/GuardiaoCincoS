namespace GuardiaoCincoS.Controles
{
    partial class CardIndicador
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNumero = new Label();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(24, 14);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(13, 15);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "0";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(24, 64);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(57, 15);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Indicador";
            // 
            // CardIndicador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(lblNumero);
            Name = "CardIndicador";
            Size = new Size(210, 110);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumero;
        private Label lblTitulo;
    }
}
