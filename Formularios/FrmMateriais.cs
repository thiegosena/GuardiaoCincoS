using System;
using System.Diagnostics;
using System.Windows.Forms;
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

        private void CarregarGrid()
        {
            dgvMateriais.DataSource = null;
            dgvMateriais.DataSource = MaterialEstudoDAO.Listar();
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
                    btnCadastrarMaterial.Text = "Cadastrar Material";
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
                    btnCadastrarMaterial.Text = "Cadastrar Material";
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
                    btnCadastrarMaterial.Text = "Atualizar Material";
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