namespace GuardiaoCincoS.Formularios
{
    partial class FrmCalendarioEventos
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
            mcalEventos = new MonthCalendar();
            chkMostrarCancelados = new CheckBox();
            dgvEventosDoDia = new DataGridView();
            label1 = new Label();
            txtTituloEvento = new TextBox();
            label2 = new Label();
            cboTipoEvento = new ComboBox();
            label3 = new Label();
            dtpDataInicioEvento = new DateTimePicker();
            dtpDataFimEvento = new DateTimePicker();
            label4 = new Label();
            txtLocalEvento = new TextBox();
            label5 = new Label();
            txtDescricaoEvento = new TextBox();
            label6 = new Label();
            cboResponsavelEvento = new ComboBox();
            label7 = new Label();
            btnNovoEvento = new Button();
            btnEditarEvento = new Button();
            btnCancelarEvento = new Button();
            btnSalvarEvento = new Button();
            btnCancelarEdicaoEvento = new Button();
            btnReativarEvento = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEventosDoDia).BeginInit();
            SuspendLayout();
            // 
            // mcalEventos
            // 
            mcalEventos.Location = new Point(3, 3);
            mcalEventos.Name = "mcalEventos";
            mcalEventos.TabIndex = 0;
            mcalEventos.DateChanged += mcalEventos_DateChanged;
            // 
            // chkMostrarCancelados
            // 
            chkMostrarCancelados.AutoSize = true;
            chkMostrarCancelados.Location = new Point(253, 72);
            chkMostrarCancelados.Name = "chkMostrarCancelados";
            chkMostrarCancelados.Size = new Size(173, 19);
            chkMostrarCancelados.TabIndex = 1;
            chkMostrarCancelados.Text = "Mostrar eventos cancelados";
            chkMostrarCancelados.UseVisualStyleBackColor = true;
            chkMostrarCancelados.CheckedChanged += chkMostrarCancelados_CheckedChanged;
            // 
            // dgvEventosDoDia
            // 
            dgvEventosDoDia.AllowUserToAddRows = false;
            dgvEventosDoDia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEventosDoDia.Location = new Point(3, 177);
            dgvEventosDoDia.MultiSelect = false;
            dgvEventosDoDia.Name = "dgvEventosDoDia";
            dgvEventosDoDia.ReadOnly = true;
            dgvEventosDoDia.Size = new Size(579, 220);
            dgvEventosDoDia.TabIndex = 2;
            dgvEventosDoDia.CellClick += dgvEventosDoDia_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(588, 15);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "Título";
            // 
            // txtTituloEvento
            // 
            txtTituloEvento.Location = new Point(632, 12);
            txtTituloEvento.MaxLength = 200;
            txtTituloEvento.Name = "txtTituloEvento";
            txtTituloEvento.Size = new Size(280, 23);
            txtTituloEvento.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(588, 54);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 5;
            label2.Text = "Tipo";
            // 
            // cboTipoEvento
            // 
            cboTipoEvento.FormattingEnabled = true;
            cboTipoEvento.Location = new Point(632, 51);
            cboTipoEvento.MaxLength = 50;
            cboTipoEvento.Name = "cboTipoEvento";
            cboTipoEvento.Size = new Size(220, 23);
            cboTipoEvento.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(588, 100);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 7;
            label3.Text = "Data início";
            // 
            // dtpDataInicioEvento
            // 
            dtpDataInicioEvento.Format = DateTimePickerFormat.Short;
            dtpDataInicioEvento.Location = new Point(657, 94);
            dtpDataInicioEvento.Name = "dtpDataInicioEvento";
            dtpDataInicioEvento.Size = new Size(195, 23);
            dtpDataInicioEvento.TabIndex = 8;
            // 
            // dtpDataFimEvento
            // 
            dtpDataFimEvento.Format = DateTimePickerFormat.Short;
            dtpDataFimEvento.Location = new Point(657, 142);
            dtpDataFimEvento.Name = "dtpDataFimEvento";
            dtpDataFimEvento.Size = new Size(195, 23);
            dtpDataFimEvento.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(588, 148);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 9;
            label4.Text = "Data fim";
            // 
            // txtLocalEvento
            // 
            txtLocalEvento.Location = new Point(632, 194);
            txtLocalEvento.MaxLength = 150;
            txtLocalEvento.Name = "txtLocalEvento";
            txtLocalEvento.Size = new Size(220, 23);
            txtLocalEvento.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(588, 197);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 11;
            label5.Text = "Local";
            // 
            // txtDescricaoEvento
            // 
            txtDescricaoEvento.Location = new Point(588, 263);
            txtDescricaoEvento.MaxLength = 500;
            txtDescricaoEvento.Multiline = true;
            txtDescricaoEvento.Name = "txtDescricaoEvento";
            txtDescricaoEvento.Size = new Size(324, 105);
            txtDescricaoEvento.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(588, 245);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 13;
            label6.Text = "Descrição";
            // 
            // cboResponsavelEvento
            // 
            cboResponsavelEvento.FormattingEnabled = true;
            cboResponsavelEvento.Location = new Point(723, 374);
            cboResponsavelEvento.MaxLength = 50;
            cboResponsavelEvento.Name = "cboResponsavelEvento";
            cboResponsavelEvento.Size = new Size(189, 23);
            cboResponsavelEvento.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(588, 377);
            label7.Name = "label7";
            label7.Size = new Size(129, 15);
            label7.TabIndex = 15;
            label7.Text = "Responsável (opcional)";
            // 
            // btnNovoEvento
            // 
            btnNovoEvento.Location = new Point(64, 479);
            btnNovoEvento.Name = "btnNovoEvento";
            btnNovoEvento.Size = new Size(102, 29);
            btnNovoEvento.TabIndex = 17;
            btnNovoEvento.Text = "Novo Evento";
            btnNovoEvento.UseVisualStyleBackColor = true;
            btnNovoEvento.Click += btnNovoEvento_Click;
            // 
            // btnEditarEvento
            // 
            btnEditarEvento.Location = new Point(192, 479);
            btnEditarEvento.Name = "btnEditarEvento";
            btnEditarEvento.Size = new Size(102, 29);
            btnEditarEvento.TabIndex = 18;
            btnEditarEvento.Text = "Editar Evento";
            btnEditarEvento.UseVisualStyleBackColor = true;
            btnEditarEvento.Click += btnEditarEvento_Click;
            // 
            // btnCancelarEvento
            // 
            btnCancelarEvento.Location = new Point(588, 479);
            btnCancelarEvento.Name = "btnCancelarEvento";
            btnCancelarEvento.Size = new Size(115, 29);
            btnCancelarEvento.TabIndex = 20;
            btnCancelarEvento.Text = "Cancelar Evento";
            btnCancelarEvento.UseVisualStyleBackColor = true;
            btnCancelarEvento.Click += btnCancelarEvento_Click;
            // 
            // btnSalvarEvento
            // 
            btnSalvarEvento.Location = new Point(456, 479);
            btnSalvarEvento.Name = "btnSalvarEvento";
            btnSalvarEvento.Size = new Size(102, 29);
            btnSalvarEvento.TabIndex = 21;
            btnSalvarEvento.Text = "Registrar Evento";
            btnSalvarEvento.UseVisualStyleBackColor = true;
            btnSalvarEvento.Click += btnSalvarEvento_Click;
            // 
            // btnCancelarEdicaoEvento
            // 
            btnCancelarEdicaoEvento.Location = new Point(324, 479);
            btnCancelarEdicaoEvento.Name = "btnCancelarEdicaoEvento";
            btnCancelarEdicaoEvento.Size = new Size(102, 29);
            btnCancelarEdicaoEvento.TabIndex = 22;
            btnCancelarEdicaoEvento.Text = "Cancelar Edição";
            btnCancelarEdicaoEvento.UseVisualStyleBackColor = true;
            btnCancelarEdicaoEvento.Click += btnCancelarEdicaoEvento_Click;
            // 
            // btnReativarEvento
            // 
            btnReativarEvento.Location = new Point(734, 479);
            btnReativarEvento.Name = "btnReativarEvento";
            btnReativarEvento.Size = new Size(115, 29);
            btnReativarEvento.TabIndex = 23;
            btnReativarEvento.Text = "Reativar Evento";
            btnReativarEvento.UseVisualStyleBackColor = true;
            btnReativarEvento.Click += btnReativarEvento_Click;
            // 
            // FrmCalendarioEventos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(936, 520);
            Controls.Add(btnReativarEvento);
            Controls.Add(btnCancelarEdicaoEvento);
            Controls.Add(btnSalvarEvento);
            Controls.Add(btnCancelarEvento);
            Controls.Add(btnEditarEvento);
            Controls.Add(btnNovoEvento);
            Controls.Add(cboResponsavelEvento);
            Controls.Add(label7);
            Controls.Add(txtDescricaoEvento);
            Controls.Add(label6);
            Controls.Add(txtLocalEvento);
            Controls.Add(label5);
            Controls.Add(dtpDataFimEvento);
            Controls.Add(label4);
            Controls.Add(dtpDataInicioEvento);
            Controls.Add(label3);
            Controls.Add(cboTipoEvento);
            Controls.Add(label2);
            Controls.Add(txtTituloEvento);
            Controls.Add(label1);
            Controls.Add(dgvEventosDoDia);
            Controls.Add(chkMostrarCancelados);
            Controls.Add(mcalEventos);
            Name = "FrmCalendarioEventos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eventos";
            Load += FrmCalendarioEventos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEventosDoDia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar mcalEventos;
        private CheckBox chkMostrarCancelados;
        private DataGridView dgvEventosDoDia;
        private Label label1;
        private TextBox txtTituloEvento;
        private Label label2;
        private ComboBox cboTipoEvento;
        private Label label3;
        private DateTimePicker dtpDataInicioEvento;
        private DateTimePicker dtpDataFimEvento;
        private Label label4;
        private TextBox txtLocalEvento;
        private Label label5;
        private TextBox txtDescricaoEvento;
        private Label label6;
        private ComboBox cboResponsavelEvento;
        private Label label7;
        private Button btnNovoEvento;
        private Button btnEditarEvento;
        private Button btnCancelarEvento;
        private Button btnSalvarEvento;
        private Button btnCancelarEdicaoEvento;
        private Button btnReativarEvento;
    }
}