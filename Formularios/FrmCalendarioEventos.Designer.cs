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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalendarioEventos));
            mcalEventos = new MonthCalendar();
            chkMostrarCancelados = new CheckBox();
            dgvEventosDoDia = new DataGridView();
            txtTituloEvento = new TextBox();
            cboTipoEvento = new ComboBox();
            dtpDataInicioEvento = new DateTimePicker();
            dtpDataFimEvento = new DateTimePicker();
            txtLocalEvento = new TextBox();
            txtDescricaoEvento = new TextBox();
            cboResponsavelEvento = new ComboBox();
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
            // txtTituloEvento
            // 
            txtTituloEvento.Location = new Point(632, 12);
            txtTituloEvento.MaxLength = 200;
            txtTituloEvento.Name = "txtTituloEvento";
            txtTituloEvento.Size = new Size(280, 23);
            txtTituloEvento.TabIndex = 4;
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
            // txtLocalEvento
            // 
            txtLocalEvento.Location = new Point(632, 194);
            txtLocalEvento.MaxLength = 150;
            txtLocalEvento.Name = "txtLocalEvento";
            txtLocalEvento.Size = new Size(220, 23);
            txtLocalEvento.TabIndex = 12;
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
            // cboResponsavelEvento
            // 
            cboResponsavelEvento.FormattingEnabled = true;
            cboResponsavelEvento.Location = new Point(723, 374);
            cboResponsavelEvento.MaxLength = 50;
            cboResponsavelEvento.Name = "cboResponsavelEvento";
            cboResponsavelEvento.Size = new Size(189, 23);
            cboResponsavelEvento.TabIndex = 16;
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
            ClientSize = new Size(1084, 741);
            Controls.Add(btnReativarEvento);
            Controls.Add(btnCancelarEdicaoEvento);
            Controls.Add(btnSalvarEvento);
            Controls.Add(btnCancelarEvento);
            Controls.Add(btnEditarEvento);
            Controls.Add(btnNovoEvento);
            Controls.Add(cboResponsavelEvento);
            Controls.Add(txtDescricaoEvento);
            Controls.Add(txtLocalEvento);
            Controls.Add(dtpDataFimEvento);
            Controls.Add(dtpDataInicioEvento);
            Controls.Add(cboTipoEvento);
            Controls.Add(txtTituloEvento);
            Controls.Add(dgvEventosDoDia);
            Controls.Add(chkMostrarCancelados);
            Controls.Add(mcalEventos);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private TextBox txtTituloEvento;
        private ComboBox cboTipoEvento;
        private DateTimePicker dtpDataInicioEvento;
        private DateTimePicker dtpDataFimEvento;
        private TextBox txtLocalEvento;
        private TextBox txtDescricaoEvento;
        private ComboBox cboResponsavelEvento;
        private Button btnNovoEvento;
        private Button btnEditarEvento;
        private Button btnCancelarEvento;
        private Button btnSalvarEvento;
        private Button btnCancelarEdicaoEvento;
        private Button btnReativarEvento;
    }
}