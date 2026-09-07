namespace GuardiaoCincoS.Formularios
{
    partial class FrmAuditorias
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuditorias));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvHistoricoAuditorias = new DataGridView();
            dtpDataAuditoria = new DateTimePicker();
            txtSetor = new TextBox();
            cboAuditor = new ComboBox();
            dgvChecklistSensos = new DataGridView();
            txtObservacoesGerais = new TextBox();
            btnSalvarAuditoria = new Button();
            imageList1 = new ImageList(components);
            btnFechar = new Button();
            cboAcompanhante = new ComboBox();
            txtLocalPlaca = new TextBox();
            dtpVencimentoPlaca = new DateTimePicker();
            btnAdicionarPlaca = new Button();
            dgvPlacasProvisorias = new DataGridView();
            btnRemoverPlaca = new Button();
            txtDescricaoItemCorrecao = new TextBox();
            dtpPrazoItemCorrecao = new DateTimePicker();
            btnAdicionarItemCorrecao = new Button();
            dgvItensCorrecao = new DataGridView();
            btnRemoverItemCorrecao = new Button();
            btnNovaAuditoria = new Button();
            btnEditarAuditoria = new Button();
            btnCancelarEdicaoAuditoria = new Button();
            btnExcluirAuditoria = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHistoricoAuditorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChecklistSensos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPlacasProvisorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItensCorrecao).BeginInit();
            SuspendLayout();
            // 
            // dgvHistoricoAuditorias
            // 
            dgvHistoricoAuditorias.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvHistoricoAuditorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistoricoAuditorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvHistoricoAuditorias.DefaultCellStyle = dataGridViewCellStyle2;
            dgvHistoricoAuditorias.Location = new Point(59, 67);
            dgvHistoricoAuditorias.Name = "dgvHistoricoAuditorias";
            dgvHistoricoAuditorias.ReadOnly = true;
            dgvHistoricoAuditorias.Size = new Size(915, 150);
            dgvHistoricoAuditorias.TabIndex = 0;
            dgvHistoricoAuditorias.CellClick += dgvHistoricoAuditorias_CellClick;
            // 
            // dtpDataAuditoria
            // 
            dtpDataAuditoria.Format = DateTimePickerFormat.Short;
            dtpDataAuditoria.Location = new Point(96, 230);
            dtpDataAuditoria.Name = "dtpDataAuditoria";
            dtpDataAuditoria.Size = new Size(200, 23);
            dtpDataAuditoria.TabIndex = 2;
            // 
            // txtSetor
            // 
            txtSetor.Location = new Point(353, 230);
            txtSetor.Name = "txtSetor";
            txtSetor.Size = new Size(100, 23);
            txtSetor.TabIndex = 4;
            // 
            // cboAuditor
            // 
            cboAuditor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAuditor.FormattingEnabled = true;
            cboAuditor.Location = new Point(670, 230);
            cboAuditor.Name = "cboAuditor";
            cboAuditor.Size = new Size(121, 23);
            cboAuditor.TabIndex = 6;
            // 
            // dgvChecklistSensos
            // 
            dgvChecklistSensos.AllowUserToAddRows = false;
            dgvChecklistSensos.AllowUserToDeleteRows = false;
            dgvChecklistSensos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChecklistSensos.Location = new Point(665, 435);
            dgvChecklistSensos.Name = "dgvChecklistSensos";
            dgvChecklistSensos.RowHeadersVisible = false;
            dgvChecklistSensos.Size = new Size(325, 224);
            dgvChecklistSensos.TabIndex = 7;
            // 
            // txtObservacoesGerais
            // 
            txtObservacoesGerais.Location = new Point(813, 259);
            txtObservacoesGerais.Multiline = true;
            txtObservacoesGerais.Name = "txtObservacoesGerais";
            txtObservacoesGerais.Size = new Size(161, 147);
            txtObservacoesGerais.TabIndex = 9;
            // 
            // btnSalvarAuditoria
            // 
            btnSalvarAuditoria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalvarAuditoria.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalvarAuditoria.ImageKey = "Save.png";
            btnSalvarAuditoria.ImageList = imageList1;
            btnSalvarAuditoria.Location = new Point(-18, 806);
            btnSalvarAuditoria.Name = "btnSalvarAuditoria";
            btnSalvarAuditoria.Size = new Size(154, 41);
            btnSalvarAuditoria.TabIndex = 10;
            btnSalvarAuditoria.Text = "Salvar";
            btnSalvarAuditoria.UseVisualStyleBackColor = true;
            btnSalvarAuditoria.Click += btnSalvarAuditoria_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Save.png");
            imageList1.Images.SetKeyName(1, "Close.png");
            imageList1.Images.SetKeyName(2, "Plus.png");
            imageList1.Images.SetKeyName(3, "Minus.png");
            imageList1.Images.SetKeyName(4, "New.png");
            imageList1.Images.SetKeyName(5, "Edit.png");
            imageList1.Images.SetKeyName(6, "Cancel.png");
            imageList1.Images.SetKeyName(7, "Delete.png");
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Transparent;
            btnFechar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFechar.ImageAlign = ContentAlignment.MiddleLeft;
            btnFechar.ImageKey = "Close.png";
            btnFechar.ImageList = imageList1;
            btnFechar.Location = new Point(1128, 0);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(40, 38);
            btnFechar.TabIndex = 11;
            btnFechar.TextAlign = ContentAlignment.MiddleRight;
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // cboAcompanhante
            // 
            cboAcompanhante.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAcompanhante.FormattingEnabled = true;
            cboAcompanhante.Location = new Point(634, 275);
            cboAcompanhante.Name = "cboAcompanhante";
            cboAcompanhante.Size = new Size(157, 23);
            cboAcompanhante.TabIndex = 14;
            // 
            // txtLocalPlaca
            // 
            txtLocalPlaca.Location = new Point(150, 308);
            txtLocalPlaca.Name = "txtLocalPlaca";
            txtLocalPlaca.Size = new Size(131, 23);
            txtLocalPlaca.TabIndex = 17;
            // 
            // dtpVencimentoPlaca
            // 
            dtpVencimentoPlaca.Format = DateTimePickerFormat.Short;
            dtpVencimentoPlaca.Location = new Point(428, 308);
            dtpVencimentoPlaca.Name = "dtpVencimentoPlaca";
            dtpVencimentoPlaca.Size = new Size(200, 23);
            dtpVencimentoPlaca.TabIndex = 18;
            // 
            // btnAdicionarPlaca
            // 
            btnAdicionarPlaca.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdicionarPlaca.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdicionarPlaca.ImageKey = "Plus.png";
            btnAdicionarPlaca.ImageList = imageList1;
            btnAdicionarPlaca.Location = new Point(59, 435);
            btnAdicionarPlaca.Name = "btnAdicionarPlaca";
            btnAdicionarPlaca.Size = new Size(163, 41);
            btnAdicionarPlaca.TabIndex = 19;
            btnAdicionarPlaca.Text = "Adicionar Placa";
            btnAdicionarPlaca.TextAlign = ContentAlignment.MiddleRight;
            btnAdicionarPlaca.UseVisualStyleBackColor = true;
            btnAdicionarPlaca.Click += btnAdicionarPlaca_Click;
            // 
            // dgvPlacasProvisorias
            // 
            dgvPlacasProvisorias.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPlacasProvisorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPlacasProvisorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvPlacasProvisorias.DefaultCellStyle = dataGridViewCellStyle4;
            dgvPlacasProvisorias.Location = new Point(59, 337);
            dgvPlacasProvisorias.Name = "dgvPlacasProvisorias";
            dgvPlacasProvisorias.ReadOnly = true;
            dgvPlacasProvisorias.Size = new Size(569, 92);
            dgvPlacasProvisorias.TabIndex = 20;
            // 
            // btnRemoverPlaca
            // 
            btnRemoverPlaca.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRemoverPlaca.ImageAlign = ContentAlignment.MiddleLeft;
            btnRemoverPlaca.ImageKey = "Minus.png";
            btnRemoverPlaca.ImageList = imageList1;
            btnRemoverPlaca.Location = new Point(391, 435);
            btnRemoverPlaca.Name = "btnRemoverPlaca";
            btnRemoverPlaca.Size = new Size(237, 41);
            btnRemoverPlaca.TabIndex = 21;
            btnRemoverPlaca.Text = "Remover Placa Selecionada";
            btnRemoverPlaca.TextAlign = ContentAlignment.MiddleRight;
            btnRemoverPlaca.UseVisualStyleBackColor = true;
            btnRemoverPlaca.Click += btnRemoverPlaca_Click;
            // 
            // txtDescricaoItemCorrecao
            // 
            txtDescricaoItemCorrecao.Location = new Point(149, 533);
            txtDescricaoItemCorrecao.Name = "txtDescricaoItemCorrecao";
            txtDescricaoItemCorrecao.Size = new Size(147, 23);
            txtDescricaoItemCorrecao.TabIndex = 17;
            // 
            // dtpPrazoItemCorrecao
            // 
            dtpPrazoItemCorrecao.Format = DateTimePickerFormat.Short;
            dtpPrazoItemCorrecao.Location = new Point(428, 533);
            dtpPrazoItemCorrecao.Name = "dtpPrazoItemCorrecao";
            dtpPrazoItemCorrecao.Size = new Size(200, 23);
            dtpPrazoItemCorrecao.TabIndex = 18;
            // 
            // btnAdicionarItemCorrecao
            // 
            btnAdicionarItemCorrecao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdicionarItemCorrecao.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdicionarItemCorrecao.ImageKey = "Plus.png";
            btnAdicionarItemCorrecao.ImageList = imageList1;
            btnAdicionarItemCorrecao.Location = new Point(59, 665);
            btnAdicionarItemCorrecao.Name = "btnAdicionarItemCorrecao";
            btnAdicionarItemCorrecao.Size = new Size(163, 41);
            btnAdicionarItemCorrecao.TabIndex = 19;
            btnAdicionarItemCorrecao.Text = "Adicionar Item";
            btnAdicionarItemCorrecao.TextAlign = ContentAlignment.MiddleRight;
            btnAdicionarItemCorrecao.UseVisualStyleBackColor = true;
            btnAdicionarItemCorrecao.Click += btnAdicionarItemCorrecao_Click;
            // 
            // dgvItensCorrecao
            // 
            dgvItensCorrecao.AllowUserToAddRows = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvItensCorrecao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvItensCorrecao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvItensCorrecao.DefaultCellStyle = dataGridViewCellStyle6;
            dgvItensCorrecao.Location = new Point(59, 562);
            dgvItensCorrecao.Name = "dgvItensCorrecao";
            dgvItensCorrecao.ReadOnly = true;
            dgvItensCorrecao.Size = new Size(569, 97);
            dgvItensCorrecao.TabIndex = 22;
            // 
            // btnRemoverItemCorrecao
            // 
            btnRemoverItemCorrecao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRemoverItemCorrecao.ImageAlign = ContentAlignment.MiddleLeft;
            btnRemoverItemCorrecao.ImageKey = "Minus.png";
            btnRemoverItemCorrecao.ImageList = imageList1;
            btnRemoverItemCorrecao.Location = new Point(391, 665);
            btnRemoverItemCorrecao.Name = "btnRemoverItemCorrecao";
            btnRemoverItemCorrecao.Size = new Size(237, 41);
            btnRemoverItemCorrecao.TabIndex = 21;
            btnRemoverItemCorrecao.Text = "Remover Item Selecionado";
            btnRemoverItemCorrecao.TextAlign = ContentAlignment.MiddleRight;
            btnRemoverItemCorrecao.UseVisualStyleBackColor = true;
            btnRemoverItemCorrecao.Click += btnRemoverItemCorrecao_Click;
            // 
            // btnNovaAuditoria
            // 
            btnNovaAuditoria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNovaAuditoria.ImageAlign = ContentAlignment.MiddleLeft;
            btnNovaAuditoria.ImageKey = "New.png";
            btnNovaAuditoria.ImageList = imageList1;
            btnNovaAuditoria.Location = new Point(195, 806);
            btnNovaAuditoria.Name = "btnNovaAuditoria";
            btnNovaAuditoria.Size = new Size(154, 41);
            btnNovaAuditoria.TabIndex = 23;
            btnNovaAuditoria.Text = "Novo";
            btnNovaAuditoria.UseVisualStyleBackColor = true;
            btnNovaAuditoria.Click += btnNovaAuditoria_Click;
            // 
            // btnEditarAuditoria
            // 
            btnEditarAuditoria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditarAuditoria.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditarAuditoria.ImageKey = "Edit.png";
            btnEditarAuditoria.ImageList = imageList1;
            btnEditarAuditoria.Location = new Point(419, 806);
            btnEditarAuditoria.Name = "btnEditarAuditoria";
            btnEditarAuditoria.Size = new Size(154, 41);
            btnEditarAuditoria.TabIndex = 24;
            btnEditarAuditoria.Text = "Editar";
            btnEditarAuditoria.UseVisualStyleBackColor = true;
            btnEditarAuditoria.Click += btnEditarAuditoria_Click;
            // 
            // btnCancelarEdicaoAuditoria
            // 
            btnCancelarEdicaoAuditoria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelarEdicaoAuditoria.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelarEdicaoAuditoria.ImageKey = "Cancel.png";
            btnCancelarEdicaoAuditoria.ImageList = imageList1;
            btnCancelarEdicaoAuditoria.Location = new Point(640, 806);
            btnCancelarEdicaoAuditoria.Name = "btnCancelarEdicaoAuditoria";
            btnCancelarEdicaoAuditoria.Size = new Size(154, 41);
            btnCancelarEdicaoAuditoria.TabIndex = 25;
            btnCancelarEdicaoAuditoria.Text = "Cancelar Edição";
            btnCancelarEdicaoAuditoria.TextAlign = ContentAlignment.MiddleRight;
            btnCancelarEdicaoAuditoria.UseVisualStyleBackColor = true;
            btnCancelarEdicaoAuditoria.Click += btnCancelarEdicaoAuditoria_Click;
            // 
            // btnExcluirAuditoria
            // 
            btnExcluirAuditoria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExcluirAuditoria.ImageAlign = ContentAlignment.MiddleLeft;
            btnExcluirAuditoria.ImageKey = "Delete.png";
            btnExcluirAuditoria.ImageList = imageList1;
            btnExcluirAuditoria.Location = new Point(861, 806);
            btnExcluirAuditoria.Name = "btnExcluirAuditoria";
            btnExcluirAuditoria.Size = new Size(154, 41);
            btnExcluirAuditoria.TabIndex = 26;
            btnExcluirAuditoria.Text = "Excluir";
            btnExcluirAuditoria.UseVisualStyleBackColor = true;
            btnExcluirAuditoria.Click += btnExcluirAuditoria_Click;
            // 
            // FrmAuditorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1000, 950);
            Controls.Add(btnExcluirAuditoria);
            Controls.Add(btnCancelarEdicaoAuditoria);
            Controls.Add(btnEditarAuditoria);
            Controls.Add(btnNovaAuditoria);
            Controls.Add(dgvItensCorrecao);
            Controls.Add(btnRemoverItemCorrecao);
            Controls.Add(btnRemoverPlaca);
            Controls.Add(dgvPlacasProvisorias);
            Controls.Add(btnAdicionarItemCorrecao);
            Controls.Add(btnAdicionarPlaca);
            Controls.Add(dtpPrazoItemCorrecao);
            Controls.Add(dtpVencimentoPlaca);
            Controls.Add(txtDescricaoItemCorrecao);
            Controls.Add(txtLocalPlaca);
            Controls.Add(cboAcompanhante);
            Controls.Add(btnFechar);
            Controls.Add(btnSalvarAuditoria);
            Controls.Add(txtObservacoesGerais);
            Controls.Add(dgvChecklistSensos);
            Controls.Add(cboAuditor);
            Controls.Add(txtSetor);
            Controls.Add(dtpDataAuditoria);
            Controls.Add(dgvHistoricoAuditorias);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAuditorias";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Auditoria";
            Load += FrmAuditorias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistoricoAuditorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChecklistSensos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPlacasProvisorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItensCorrecao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHistoricoAuditorias;
        private DateTimePicker dtpDataAuditoria;
        private TextBox txtSetor;
        private ComboBox cboAuditor;
        private DataGridView dgvChecklistSensos;
        private TextBox txtObservacoesGerais;
        private Button btnSalvarAuditoria;
        private ImageList imageList1;
        private Button btnFechar;
        private ComboBox cboAcompanhante;
        private TextBox txtLocalPlaca;
        private DateTimePicker dtpVencimentoPlaca;
        private Button btnAdicionarPlaca;
        private DataGridView dgvPlacasProvisorias;
        private Button btnRemoverPlaca;
        private TextBox txtDescricaoItemCorrecao;
        private DateTimePicker dtpPrazoItemCorrecao;
        private Button btnAdicionarItemCorrecao;
        private DataGridView dgvItensCorrecao;
        private Button btnRemoverItemCorrecao;
        private Button btnNovaAuditoria;
        private Button btnEditarAuditoria;
        private Button btnCancelarEdicaoAuditoria;
        private Button btnExcluirAuditoria;
    }
}