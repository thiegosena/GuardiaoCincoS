namespace GuardiaoCincoS.Formularios
{
    partial class FrmMateriais
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMateriais));
            dgvMateriais = new DataGridView();
            label1 = new Label();
            txtTituloMaterial = new TextBox();
            label2 = new Label();
            cboCategoriaMaterial = new ComboBox();
            txtDescricaoMaterial = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtCaminhoOuLink = new TextBox();
            btnSelecionarArquivo = new Button();
            label5 = new Label();
            dtpDataPublicacaoMaterial = new DateTimePicker();
            btnCadastrarMaterial = new Button();
            btnAcessarMaterial = new Button();
            btnInativarMaterial = new Button();
            btnEditarMaterial = new Button();
            btnCancelarEdicao = new Button();
            btnNovoMaterial = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMateriais).BeginInit();
            SuspendLayout();
            // 
            // dgvMateriais
            // 
            dgvMateriais.AllowUserToAddRows = false;
            dgvMateriais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMateriais.Location = new Point(0, 0);
            dgvMateriais.MultiSelect = false;
            dgvMateriais.Name = "dgvMateriais";
            dgvMateriais.ReadOnly = true;
            dgvMateriais.Size = new Size(799, 150);
            dgvMateriais.TabIndex = 0;
            dgvMateriais.CellClick += dgvMateriais_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 162);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "Título";
            // 
            // txtTituloMaterial
            // 
            txtTituloMaterial.Location = new Point(56, 156);
            txtTituloMaterial.Name = "txtTituloMaterial";
            txtTituloMaterial.Size = new Size(276, 23);
            txtTituloMaterial.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 197);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 3;
            label2.Text = "Categoria";
            // 
            // cboCategoriaMaterial
            // 
            cboCategoriaMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoriaMaterial.FormattingEnabled = true;
            cboCategoriaMaterial.Location = new Point(76, 191);
            cboCategoriaMaterial.Name = "cboCategoriaMaterial";
            cboCategoriaMaterial.Size = new Size(256, 23);
            cboCategoriaMaterial.TabIndex = 4;
            // 
            // txtDescricaoMaterial
            // 
            txtDescricaoMaterial.Location = new Point(423, 156);
            txtDescricaoMaterial.Multiline = true;
            txtDescricaoMaterial.Name = "txtDescricaoMaterial";
            txtDescricaoMaterial.Size = new Size(365, 86);
            txtDescricaoMaterial.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(359, 162);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 5;
            label3.Text = "Descrição";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 257);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 7;
            label4.Text = "Arquivo ou Link";
            // 
            // txtCaminhoOuLink
            // 
            txtCaminhoOuLink.Location = new Point(109, 254);
            txtCaminhoOuLink.Name = "txtCaminhoOuLink";
            txtCaminhoOuLink.Size = new Size(171, 23);
            txtCaminhoOuLink.TabIndex = 8;
            // 
            // btnSelecionarArquivo
            // 
            btnSelecionarArquivo.Location = new Point(286, 254);
            btnSelecionarArquivo.Name = "btnSelecionarArquivo";
            btnSelecionarArquivo.Size = new Size(133, 23);
            btnSelecionarArquivo.TabIndex = 9;
            btnSelecionarArquivo.Text = "Selecionar Arquivo...";
            btnSelecionarArquivo.UseVisualStyleBackColor = true;
            btnSelecionarArquivo.Click += btnSelecionarArquivo_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 301);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 10;
            label5.Text = "Data de publicação";
            // 
            // dtpDataPublicacaoMaterial
            // 
            dtpDataPublicacaoMaterial.Format = DateTimePickerFormat.Short;
            dtpDataPublicacaoMaterial.Location = new Point(126, 295);
            dtpDataPublicacaoMaterial.Name = "dtpDataPublicacaoMaterial";
            dtpDataPublicacaoMaterial.Size = new Size(163, 23);
            dtpDataPublicacaoMaterial.TabIndex = 11;
            // 
            // btnCadastrarMaterial
            // 
            btnCadastrarMaterial.Location = new Point(423, 404);
            btnCadastrarMaterial.Name = "btnCadastrarMaterial";
            btnCadastrarMaterial.Size = new Size(113, 34);
            btnCadastrarMaterial.TabIndex = 12;
            btnCadastrarMaterial.Text = "Cadastrar Material";
            btnCadastrarMaterial.UseVisualStyleBackColor = true;
            btnCadastrarMaterial.Click += btnCadastrarMaterial_Click;
            // 
            // btnAcessarMaterial
            // 
            btnAcessarMaterial.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAcessarMaterial.Location = new Point(527, 282);
            btnAcessarMaterial.Name = "btnAcessarMaterial";
            btnAcessarMaterial.Size = new Size(144, 50);
            btnAcessarMaterial.TabIndex = 13;
            btnAcessarMaterial.Text = "Acessar Material";
            btnAcessarMaterial.UseVisualStyleBackColor = true;
            btnAcessarMaterial.Click += btnAcessarMaterial_Click;
            // 
            // btnInativarMaterial
            // 
            btnInativarMaterial.Location = new Point(575, 404);
            btnInativarMaterial.Name = "btnInativarMaterial";
            btnInativarMaterial.Size = new Size(113, 34);
            btnInativarMaterial.TabIndex = 14;
            btnInativarMaterial.Text = "Inativar Material";
            btnInativarMaterial.UseVisualStyleBackColor = true;
            btnInativarMaterial.Click += btnInativarMaterial_Click;
            // 
            // btnEditarMaterial
            // 
            btnEditarMaterial.Location = new Point(126, 404);
            btnEditarMaterial.Name = "btnEditarMaterial";
            btnEditarMaterial.Size = new Size(77, 34);
            btnEditarMaterial.TabIndex = 15;
            btnEditarMaterial.Text = "Editar";
            btnEditarMaterial.UseVisualStyleBackColor = true;
            btnEditarMaterial.Click += btnEditarMaterial_Click;
            // 
            // btnCancelarEdicao
            // 
            btnCancelarEdicao.Location = new Point(228, 404);
            btnCancelarEdicao.Name = "btnCancelarEdicao";
            btnCancelarEdicao.Size = new Size(101, 34);
            btnCancelarEdicao.TabIndex = 16;
            btnCancelarEdicao.Text = "Cancelar Edição";
            btnCancelarEdicao.UseVisualStyleBackColor = true;
            btnCancelarEdicao.Click += btnCancelarEdicao_Click;
            // 
            // btnNovoMaterial
            // 
            btnNovoMaterial.Location = new Point(26, 404);
            btnNovoMaterial.Name = "btnNovoMaterial";
            btnNovoMaterial.Size = new Size(77, 34);
            btnNovoMaterial.TabIndex = 17;
            btnNovoMaterial.Text = "Novo";
            btnNovoMaterial.UseVisualStyleBackColor = true;
            btnNovoMaterial.Click += btnNovoMaterial_Click;
            // 
            // FrmMateriais
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNovoMaterial);
            Controls.Add(btnCancelarEdicao);
            Controls.Add(btnEditarMaterial);
            Controls.Add(btnInativarMaterial);
            Controls.Add(btnAcessarMaterial);
            Controls.Add(btnCadastrarMaterial);
            Controls.Add(dtpDataPublicacaoMaterial);
            Controls.Add(label5);
            Controls.Add(btnSelecionarArquivo);
            Controls.Add(txtCaminhoOuLink);
            Controls.Add(label4);
            Controls.Add(txtDescricaoMaterial);
            Controls.Add(label3);
            Controls.Add(cboCategoriaMaterial);
            Controls.Add(label2);
            Controls.Add(txtTituloMaterial);
            Controls.Add(label1);
            Controls.Add(dgvMateriais);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMateriais";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Materiais - Estudo";
            Load += FrmMateriais_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMateriais).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMateriais;
        private Label label1;
        private TextBox txtTituloMaterial;
        private Label label2;
        private ComboBox cboCategoriaMaterial;
        private TextBox txtDescricaoMaterial;
        private Label label3;
        private Label label4;
        private TextBox txtCaminhoOuLink;
        private Button btnSelecionarArquivo;
        private Label label5;
        private DateTimePicker dtpDataPublicacaoMaterial;
        private Button btnCadastrarMaterial;
        private Button btnAcessarMaterial;
        private Button btnInativarMaterial;
        private Button btnEditarMaterial;
        private Button btnCancelarEdicao;
        private Button btnNovoMaterial;
    }
}