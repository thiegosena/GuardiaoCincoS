using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmColaboradores : Form
    {
        private int _idSelecionado = 0;

        public FrmColaboradores()
        {
            InitializeComponent();
        }

        private void FrmColaboradores_Load(object sender, EventArgs e)
        {
            CarregarGrid();
            LimparCampos();
        }

        private void CarregarGrid()
        {
            dgvColaboradores.DataSource = null;
            dgvColaboradores.DataSource = ColaboradorDAO.Listar();
        }

        private void LimparCampos()
        {
            _idSelecionado = 0;
            txtNome.Text = "";
            txtSetor.Text = "";
            cboTurno.SelectedIndex = -1;
            txtNome.Focus();
        }

        private void dgvColaboradores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var linha = dgvColaboradores.Rows[e.RowIndex];
            _idSelecionado = Convert.ToInt32(linha.Cells["Id"].Value);
            txtNome.Text = linha.Cells["Nome"].Value?.ToString() ?? string.Empty;
            txtSetor.Text = linha.Cells["Setor"].Value?.ToString() ?? string.Empty;
            cboTurno.Text = linha.Cells["Turno"].Value?.ToString() ?? string.Empty;
        }

        private void btnNovo_Click(object sender, EventArgs e) => LimparCampos();

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do colaborador.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var colaborador = new Colaborador
            {
                Id = _idSelecionado,
                Nome = txtNome.Text.Trim(),
                Setor = txtSetor.Text.Trim(),
                Turno = cboTurno.Text.Trim()
            };

            if (_idSelecionado == 0)
                ColaboradorDAO.Inserir(colaborador);
            else
                ColaboradorDAO.Atualizar(colaborador);

            CarregarGrid();
            LimparCampos();
        }

        private void btnInativar_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Selecione um colaborador na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacao = MessageBox.Show(
                "Inativar este colaborador? Ele sai das listas, mas o histórico é mantido.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                ColaboradorDAO.Inativar(_idSelecionado);
                CarregarGrid();
                LimparCampos();
            }
        }
    }
}
