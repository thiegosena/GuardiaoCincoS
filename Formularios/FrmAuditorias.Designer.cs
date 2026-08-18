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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuditorias));
            dgvHistoricoAuditorias = new DataGridView();
            label1 = new Label();
            dtpDataAuditoria = new DateTimePicker();
            label2 = new Label();
            txtSetor = new TextBox();
            label3 = new Label();
            cboAuditor = new ComboBox();
            dgvChecklistSensos = new DataGridView();
            label4 = new Label();
            txtObservacoesGerais = new TextBox();
            btnSalvarAuditoria = new Button();
            imageList1 = new ImageList(components);
            btnFechar = new Button();
            label5 = new Label();
            label6 = new Label();
            cboAcompanhante = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            txtLocalPlaca = new TextBox();
            label9 = new Label();
            dtpVencimentoPlaca = new DateTimePicker();
            btnAdicionarPlaca = new Button();
            dgvPlacasProvisorias = new DataGridView();
            btnRemoverPlaca = new Button();
            label10 = new Label();
            label11 = new Label();
            txtDescricaoItemCorrecao = new TextBox();
            label12 = new Label();
            dtpPrazoItemCorrecao = new DateTimePicker();
            btnAdicionarItemCorrecao = new Button();
            dgvItensCorrecao = new DataGridView();
            btnRemoverItemCorrecao = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHistoricoAuditorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChecklistSensos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPlacasProvisorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItensCorrecao).BeginInit();
            SuspendLayout();
            // 
            // dgvHistoricoAuditorias
            // 
            dgvHistoricoAuditorias.AllowUserToAddRows = false;
            dgvHistoricoAuditorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistoricoAuditorias.Location = new Point(59, 67);
            dgvHistoricoAuditorias.Name = "dgvHistoricoAuditorias";
            dgvHistoricoAuditorias.ReadOnly = true;
            dgvHistoricoAuditorias.Size = new Size(584, 150);
            dgvHistoricoAuditorias.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(59, 236);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Data";
            // 
            // dtpDataAuditoria
            // 
            dtpDataAuditoria.Format = DateTimePickerFormat.Short;
            dtpDataAuditoria.Location = new Point(96, 230);
            dtpDataAuditoria.Name = "dtpDataAuditoria";
            dtpDataAuditoria.Size = new Size(200, 23);
            dtpDataAuditoria.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(313, 236);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 3;
            label2.Text = "Setor";
            // 
            // txtSetor
            // 
            txtSetor.Location = new Point(353, 230);
            txtSetor.Name = "txtSetor";
            txtSetor.Size = new Size(100, 23);
            txtSetor.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(464, 236);
            label3.Name = "label3";
            label3.Size = new Size(195, 15);
            label3.TabIndex = 5;
            label3.Text = "Guardião responsável pela auditoria";
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
            dgvChecklistSensos.Location = new Point(665, 67);
            dgvChecklistSensos.Name = "dgvChecklistSensos";
            dgvChecklistSensos.RowHeadersVisible = false;
            dgvChecklistSensos.Size = new Size(446, 150);
            dgvChecklistSensos.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(813, 236);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 8;
            label4.Text = "Observações gerais";
            // 
            // txtObservacoesGerais
            // 
            txtObservacoesGerais.Location = new Point(813, 259);
            txtObservacoesGerais.Multiline = true;
            txtObservacoesGerais.Name = "txtObservacoesGerais";
            txtObservacoesGerais.Size = new Size(298, 147);
            txtObservacoesGerais.TabIndex = 9;
            // 
            // btnSalvarAuditoria
            // 
            btnSalvarAuditoria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalvarAuditoria.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalvarAuditoria.ImageKey = "Save.png";
            btnSalvarAuditoria.ImageList = imageList1;
            btnSalvarAuditoria.Location = new Point(59, 807);
            btnSalvarAuditoria.Name = "btnSalvarAuditoria";
            btnSalvarAuditoria.Size = new Size(154, 41);
            btnSalvarAuditoria.TabIndex = 10;
            btnSalvarAuditoria.Text = "Salvar Auditoria";
            btnSalvarAuditoria.TextAlign = ContentAlignment.MiddleRight;
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
            // 
            // btnFechar
            // 
            btnFechar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFechar.ImageAlign = ContentAlignment.MiddleLeft;
            btnFechar.ImageKey = "Close.png";
            btnFechar.ImageList = imageList1;
            btnFechar.Location = new Point(1013, 807);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(98, 41);
            btnFechar.TabIndex = 11;
            btnFechar.Text = "Fechar";
            btnFechar.TextAlign = ContentAlignment.MiddleRight;
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label5.Location = new Point(510, 9);
            label5.Name = "label5";
            label5.Size = new Size(152, 41);
            label5.TabIndex = 12;
            label5.Text = "Auditoria";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(469, 278);
            label6.Name = "label6";
            label6.Size = new Size(159, 15);
            label6.TabIndex = 13;
            label6.Text = "Colaborador acompanhante:";
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label7.Location = new Point(59, 273);
            label7.Name = "label7";
            label7.Size = new Size(335, 25);
            label7.TabIndex = 15;
            label7.Text = "— Placas Provisórias Identificadas —";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(59, 311);
            label8.Name = "label8";
            label8.Size = new Size(85, 15);
            label8.TabIndex = 16;
            label8.Text = "Local da placa:";
            // 
            // txtLocalPlaca
            // 
            txtLocalPlaca.Location = new Point(150, 308);
            txtLocalPlaca.Name = "txtLocalPlaca";
            txtLocalPlaca.Size = new Size(131, 23);
            txtLocalPlaca.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F);
            label9.Location = new Point(347, 314);
            label9.Name = "label9";
            label9.Size = new Size(73, 15);
            label9.TabIndex = 16;
            label9.Text = "Vencimento:";
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
            dgvPlacasProvisorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label10.Location = new Point(59, 502);
            label10.Name = "label10";
            label10.Size = new Size(234, 25);
            label10.TabIndex = 15;
            label10.Text = "— Itens para Correção —";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F);
            label11.Location = new Point(59, 536);
            label11.Name = "label11";
            label11.Size = new Size(84, 15);
            label11.TabIndex = 16;
            label11.Text = "Item a corrigir:";
            // 
            // txtDescricaoItemCorrecao
            // 
            txtDescricaoItemCorrecao.Location = new Point(149, 533);
            txtDescricaoItemCorrecao.Name = "txtDescricaoItemCorrecao";
            txtDescricaoItemCorrecao.Size = new Size(147, 23);
            txtDescricaoItemCorrecao.TabIndex = 17;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F);
            label12.Location = new Point(302, 536);
            label12.Name = "label12";
            label12.Size = new Size(122, 15);
            label12.TabIndex = 16;
            label12.Text = "Prazo para conclusão:";
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
            dgvItensCorrecao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            // FrmAuditorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1168, 860);
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
            Controls.Add(label9);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label8);
            Controls.Add(label10);
            Controls.Add(label7);
            Controls.Add(cboAcompanhante);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnFechar);
            Controls.Add(btnSalvarAuditoria);
            Controls.Add(txtObservacoesGerais);
            Controls.Add(label4);
            Controls.Add(dgvChecklistSensos);
            Controls.Add(cboAuditor);
            Controls.Add(label3);
            Controls.Add(txtSetor);
            Controls.Add(label2);
            Controls.Add(dtpDataAuditoria);
            Controls.Add(label1);
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
        private Label label1;
        private DateTimePicker dtpDataAuditoria;
        private Label label2;
        private TextBox txtSetor;
        private Label label3;
        private ComboBox cboAuditor;
        private DataGridView dgvChecklistSensos;
        private Label label4;
        private TextBox txtObservacoesGerais;
        private Button btnSalvarAuditoria;
        private ImageList imageList1;
        private Button btnFechar;
        private Label label5;
        private Label label6;
        private ComboBox cboAcompanhante;
        private Label label7;
        private Label label8;
        private TextBox txtLocalPlaca;
        private Label label9;
        private DateTimePicker dtpVencimentoPlaca;
        private Button btnAdicionarPlaca;
        private DataGridView dgvPlacasProvisorias;
        private Button btnRemoverPlaca;
        private Label label10;
        private Label label11;
        private TextBox txtDescricaoItemCorrecao;
        private Label label12;
        private DateTimePicker dtpPrazoItemCorrecao;
        private Button btnAdicionarItemCorrecao;
        private DataGridView dgvItensCorrecao;
        private Button btnRemoverItemCorrecao;
    }
}