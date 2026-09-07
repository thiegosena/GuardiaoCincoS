using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GuardiaoCincoS.Controles;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmMateriais : Form
    {
        private enum ModoTela
        {
            Novo,
            Visualizacao,
            Edicao
        }

        private int _idMaterialSelecionado = 0;
        private ModoTela _modoAtual = ModoTela.Novo;

        public FrmMateriais()
        {
            InitializeComponent();
        }

        private void FrmMateriais_Load(object sender, EventArgs e)
        {
            MontarLayout();

            cboCategoriaMaterial.Items.Clear();
            cboCategoriaMaterial.Items.AddRange(new object[]
            {
                "Ebook",
                "Vídeo",
                "Slides",
                "Treinamento",
                "Procedimento/Instrução de Trabalho",
                "Estudo Dirigido",
                "Outro"
            });

            CarregarGrid();
            AplicarModo(ModoTela.Novo);
        }

        private void MontarLayout()
        {
            ClientSize = new Size(950, 850);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = EstiloVisual.FundoPagina;

            var pnlCabecalho = EstiloVisual.CriarCabecalho("Materiais de Estudo");

            var pnlConteudo = new Panel { Dock = DockStyle.Fill, BackColor = EstiloVisual.FundoPagina, AutoScroll = true, Padding = new Padding(20) };

            // ===== Card 1: grid =====
            var cartaoGrid = new CartaoSecao
            {
                Titulo = "Materiais Cadastrados",
                CorDestaque = EstiloVisual.AzulKyly,
                Dock = DockStyle.Top,
                Height = 260,
                Margin = new Padding(0, 0, 0, 20)
            };
            dgvMateriais.Dock = DockStyle.Fill;
            dgvMateriais.Parent = cartaoGrid.PainelConteudo;
            EstiloVisual.ConfigurarGrid(dgvMateriais);

            // ===== Card 2: dados do material =====
            var cartaoDados = new CartaoSecao
            {
                Titulo = "Dados do Material",
                CorDestaque = EstiloVisual.AmareloKyly,
                Dock = DockStyle.Top,
                Height = 400
            };

            var grade = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 2, RowCount = 4, Padding = new Padding(4) };
            grade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            for (int i = 0; i < grade.RowCount; i++)
                grade.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            txtTituloMaterial.MaxLength = 200;
            cboCategoriaMaterial.MaxLength = 100;
            txtCaminhoOuLink.MaxLength = 500;
            txtDescricaoMaterial.MaxLength = 500;

            var campoTitulo = EstiloVisual.CriarCampo("Título", txtTituloMaterial);
            grade.Controls.Add(campoTitulo, 0, 0);
            grade.SetColumnSpan(campoTitulo, 2);

            grade.Controls.Add(EstiloVisual.CriarCampo("Categoria", cboCategoriaMaterial), 0, 1);
            grade.Controls.Add(EstiloVisual.CriarCampo("Data de publicação", dtpDataPublicacaoMaterial), 1, 1);

            var campoArquivo = CriarCampoArquivo();
            grade.Controls.Add(campoArquivo, 0, 2);
            grade.SetColumnSpan(campoArquivo, 2);

            var campoDescricao = EstiloVisual.CriarCampoMultilinha("Descrição", txtDescricaoMaterial, 90);
            grade.Controls.Add(campoDescricao, 0, 3);
            grade.SetColumnSpan(campoDescricao, 2);

            cartaoDados.PainelConteudo.Controls.Add(grade);

            // ===== Ações finais =====
            var pnlAcoes = new Panel { Dock = DockStyle.Top, Height = 60, Padding = new Padding(0, 20, 0, 0) };
            var flpAcoes = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };

            EstiloVisual.EstilizarBotao(btnNovoMaterial, "Novo", EstiloVisual.AzulKyly, Color.White);
            EstiloVisual.EstilizarBotao(btnEditarMaterial, "Editar", EstiloVisual.AmareloKyly, EstiloVisual.TextoTitulo);
            EstiloVisual.EstilizarBotao(btnCancelarEdicao, "Cancelar Edição", Color.FromArgb(210, 214, 220), EstiloVisual.TextoTitulo);
            EstiloVisual.EstilizarBotao(btnCadastrarMaterial, "Salvar", EstiloVisual.Verde, Color.White);
            EstiloVisual.EstilizarBotao(btnAcessarMaterial, "Acessar", EstiloVisual.AzulMarinho, Color.White);
            EstiloVisual.EstilizarBotao(btnInativarMaterial, "Inativar", EstiloVisual.Vermelho, Color.White);

            flpAcoes.Controls.Add(btnNovoMaterial);
            flpAcoes.Controls.Add(btnEditarMaterial);
            flpAcoes.Controls.Add(btnCancelarEdicao);
            flpAcoes.Controls.Add(btnCadastrarMaterial);
            flpAcoes.Controls.Add(btnAcessarMaterial);
            flpAcoes.Controls.Add(btnInativarMaterial);
            pnlAcoes.Controls.Add(flpAcoes);

            // Ordem de adição = inverso da ordem visual desejada (Grid -> Dados -> Ações).
            pnlConteudo.Controls.Add(pnlAcoes);
            pnlConteudo.Controls.Add(cartaoDados);
            pnlConteudo.Controls.Add(cartaoGrid);

            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
        }

        // Campo composto: rótulo em cima, e a caixa de texto dividindo a linha
        // com o botão "Selecionar Arquivo..." encostado à direita.
        private Panel CriarCampoArquivo()
        {
            var painel = new Panel { Dock = DockStyle.Fill, Margin = new Padding(6), Height = 60 };

            var linhaCampoBotao = new Panel { Dock = DockStyle.Fill };

            txtCaminhoOuLink.Dock = DockStyle.Fill;
            txtCaminhoOuLink.Font = new Font("Segoe UI", 10F);
            txtCaminhoOuLink.BorderStyle = BorderStyle.FixedSingle;

            EstiloVisual.EstilizarBotao(btnSelecionarArquivo, "Selecionar Arquivo...", Color.FromArgb(210, 214, 220), EstiloVisual.TextoTitulo);
            btnSelecionarArquivo.Dock = DockStyle.Right;
            btnSelecionarArquivo.Width = 160;

            // txtCaminhoOuLink (Fill) primeiro, botão (Right) depois -- mesma regra
            // de sempre: o último adicionado reserva seu espaço primeiro (a faixa
            // direita fixa), e o Fill absorve o que sobrar.
            linhaCampoBotao.Controls.Add(txtCaminhoOuLink);
            linhaCampoBotao.Controls.Add(btnSelecionarArquivo);

            var lbl = new Label
            {
                Text = "Arquivo ou Link",
                Dock = DockStyle.Top,
                Height = 20,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = EstiloVisual.TextoSecundario
            };

            painel.Controls.Add(linhaCampoBotao);
            painel.Controls.Add(lbl);

            return painel;
        }

        private void CarregarGrid()
        {
            dgvMateriais.DataSource = null;
            dgvMateriais.DataSource = MaterialEstudoDAO.Listar();

            if (dgvMateriais.Columns["Id"] != null) dgvMateriais.Columns["Id"]!.Visible = false;
            if (dgvMateriais.Columns["Ativo"] != null) dgvMateriais.Columns["Ativo"]!.Visible = false;

            if (dgvMateriais.Columns["Titulo"] != null) dgvMateriais.Columns["Titulo"]!.HeaderText = "Título";
            if (dgvMateriais.Columns["Categoria"] != null) dgvMateriais.Columns["Categoria"]!.HeaderText = "Categoria";
            if (dgvMateriais.Columns["Descricao"] != null) dgvMateriais.Columns["Descricao"]!.HeaderText = "Descrição";
            if (dgvMateriais.Columns["CaminhoOuLink"] != null) dgvMateriais.Columns["CaminhoOuLink"]!.HeaderText = "Arquivo/Link";
            if (dgvMateriais.Columns["DataPublicacao"] != null)
            {
                dgvMateriais.Columns["DataPublicacao"]!.HeaderText = "Publicado em";
                dgvMateriais.Columns["DataPublicacao"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        // Centraliza tudo que muda de acordo com o "estado" da tela
        private void AplicarModo(ModoTela modo)
        {
            _modoAtual = modo;
            bool ehColaborador = Sessao.NomePerfil == "Colaborador";

            switch (modo)
            {
                case ModoTela.Novo:
                    LimparCampos();
                    HabilitarCamposCadastro(!ehColaborador);
                    btnCadastrarMaterial.Text = "Salvar";
                    btnCadastrarMaterial.Enabled = !ehColaborador;
                    btnEditarMaterial.Enabled = false;
                    btnCancelarEdicao.Enabled = false;
                    btnNovoMaterial.Enabled = false;
                    btnAcessarMaterial.Enabled = false;
                    btnInativarMaterial.Enabled = false;
                    dgvMateriais.Enabled = true;
                    break;

                case ModoTela.Visualizacao:
                    HabilitarCamposCadastro(false);
                    btnCadastrarMaterial.Text = "Salvar";
                    btnCadastrarMaterial.Enabled = false;
                    btnEditarMaterial.Enabled = !ehColaborador;
                    btnCancelarEdicao.Enabled = false;
                    btnNovoMaterial.Enabled = !ehColaborador;
                    btnAcessarMaterial.Enabled = true; // colaborador pode acessar mesmo sem editar
                    btnInativarMaterial.Enabled = !ehColaborador;
                    dgvMateriais.Enabled = true;
                    break;

                case ModoTela.Edicao:
                    HabilitarCamposCadastro(true);
                    btnCadastrarMaterial.Text = "Atualizar";
                    btnCadastrarMaterial.Enabled = true;
                    btnEditarMaterial.Enabled = false;
                    btnCancelarEdicao.Enabled = true;
                    btnNovoMaterial.Enabled = false;
                    btnAcessarMaterial.Enabled = false;
                    btnInativarMaterial.Enabled = false;
                    dgvMateriais.Enabled = false; // impede trocar de linha no meio da edição
                    break;
            }
        }

        private void HabilitarCamposCadastro(bool habilitado)
        {
            txtTituloMaterial.Enabled = habilitado;
            cboCategoriaMaterial.Enabled = habilitado;
            txtDescricaoMaterial.Enabled = habilitado;
            txtCaminhoOuLink.Enabled = habilitado;
            btnSelecionarArquivo.Enabled = habilitado;
            dtpDataPublicacaoMaterial.Enabled = habilitado;
        }

        private void LimparCampos()
        {
            _idMaterialSelecionado = 0;
            txtTituloMaterial.Text = string.Empty;
            if (cboCategoriaMaterial.Items.Count > 0) cboCategoriaMaterial.SelectedIndex = 0;
            txtDescricaoMaterial.Text = string.Empty;
            txtCaminhoOuLink.Text = string.Empty;
            dtpDataPublicacaoMaterial.Value = DateTime.Today;
        }

        private void dgvMateriais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var linhaSelecionada = dgvMateriais.Rows[e.RowIndex];
            var material = (MaterialEstudo)linhaSelecionada.DataBoundItem!;

            _idMaterialSelecionado = material.Id;
            txtTituloMaterial.Text = material.Titulo;
            cboCategoriaMaterial.Text = material.Categoria;
            txtDescricaoMaterial.Text = material.Descricao;
            txtCaminhoOuLink.Text = material.CaminhoOuLink;
            dtpDataPublicacaoMaterial.Value = material.DataPublicacao;

            AplicarModo(ModoTela.Visualizacao);
        }

        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            using (var dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Selecionar arquivo do material";
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    txtCaminhoOuLink.Text = dialogo.FileName;
                }
            }
        }

        private void btnNovoMaterial_Click(object sender, EventArgs e)
        {
            AplicarModo(ModoTela.Novo);
        }

        private void btnEditarMaterial_Click(object sender, EventArgs e)
        {
            if (_idMaterialSelecionado == 0)
            {
                MessageBox.Show("Selecione um material na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AplicarModo(ModoTela.Edicao);
        }

        private void btnCancelarEdicao_Click(object sender, EventArgs e)
        {
            AplicarModo(ModoTela.Novo);
        }

        private void btnCadastrarMaterial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTituloMaterial.Text))
            {
                MessageBox.Show("Informe o título do material.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCaminhoOuLink.Text))
            {
                MessageBox.Show("Informe o caminho do arquivo ou o link do material.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTituloMaterial.Text.Trim().Length > 200)
            {
                MessageBox.Show("O título pode ter no máximo 200 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCategoriaMaterial.Text.Trim().Length > 100)
            {
                MessageBox.Show("A categoria pode ter no máximo 100 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCaminhoOuLink.Text.Trim().Length > 500)
            {
                MessageBox.Show("O caminho do arquivo ou link pode ter no máximo 500 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtDescricaoMaterial.Text.Trim().Length > 500)
            {
                MessageBox.Show("A descrição pode ter no máximo 500 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var material = new MaterialEstudo
            {
                Id = _idMaterialSelecionado,
                Titulo = txtTituloMaterial.Text.Trim(),
                Categoria = cboCategoriaMaterial.Text,
                Descricao = txtDescricaoMaterial.Text.Trim(),
                CaminhoOuLink = txtCaminhoOuLink.Text.Trim(),
                DataPublicacao = dtpDataPublicacaoMaterial.Value.Date
            };

            if (_modoAtual == ModoTela.Edicao)
            {
                MaterialEstudoDAO.Atualizar(material);
                MessageBox.Show("Material atualizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MaterialEstudoDAO.Inserir(material, Sessao.IdUsuario);
                MessageBox.Show("Material cadastrado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CarregarGrid();
            AplicarModo(ModoTela.Novo);
        }

        private void btnAcessarMaterial_Click(object sender, EventArgs e)
        {
            if (_idMaterialSelecionado == 0)
            {
                MessageBox.Show("Selecione um material na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var linhaSelecionada = dgvMateriais.CurrentRow;
            if (linhaSelecionada == null) return;

            var material = (MaterialEstudo)linhaSelecionada.DataBoundItem!;

            try
            {
                var processo = new ProcessStartInfo(material.CaminhoOuLink)
                {
                    UseShellExecute = true
                };
                Process.Start(processo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir esse material: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInativarMaterial_Click(object sender, EventArgs e)
        {
            if (_idMaterialSelecionado == 0)
            {
                MessageBox.Show("Selecione um material na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacao = MessageBox.Show(
                "Inativar este material? Ele deixa de aparecer na lista, mas o registro é mantido.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                MaterialEstudoDAO.Inativar(_idMaterialSelecionado);
                CarregarGrid();
                AplicarModo(ModoTela.Novo);
            }
        }
    }
}