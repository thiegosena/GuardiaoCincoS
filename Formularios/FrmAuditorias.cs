using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmAuditorias : Form
    {
        private List<PlacaProvisoria> _placasProvisorias = new List<PlacaProvisoria>();
        private List<ItemCorrecao> _itensCorrecao = new List<ItemCorrecao>();

        public FrmAuditorias()
        {
            InitializeComponent();
        }

        private void FrmAuditorias_Load(object sender, EventArgs e)
        {
            ConfigurarChecklistPadrao();
            CarregarAuditores();
            CarregarAcompanhantes();
            CarregarHistorico();
            dtpDataAuditoria.Value = DateTime.Today;
            dtpVencimentoPlaca.Value = DateTime.Today;
            dtpPrazoItemCorrecao.Value = DateTime.Today;

            if (Sessao.NomePerfil == "Colaborador")
            {
                dtpDataAuditoria.Enabled = false;
                txtSetor.Enabled = false;
                cboAuditor.Enabled = false;
                cboAcompanhante.Enabled = false;
                dgvChecklistSensos.Enabled = false;
                txtObservacoesGerais.Enabled = false;
                txtLocalPlaca.Enabled = false;
                dtpVencimentoPlaca.Enabled = false;
                btnAdicionarPlaca.Enabled = false;
                btnRemoverPlaca.Enabled = false;
                txtDescricaoItemCorrecao.Enabled = false;
                dtpPrazoItemCorrecao.Enabled = false;
                btnAdicionarItemCorrecao.Enabled = false;
                btnRemoverItemCorrecao.Enabled = false;
                btnSalvarAuditoria.Enabled = false;
            }
        }

        private void ConfigurarChecklistPadrao()
        {
            dgvChecklistSensos.Columns.Clear();
            dgvChecklistSensos.Columns.Add("Senso", "Senso");
            dgvChecklistSensos.Columns.Add("Nota", "Nota (0 a 5)");
            dgvChecklistSensos.Columns.Add("Observacao", "Observação");

            dgvChecklistSensos.Columns["Senso"]!.ReadOnly = true;
            dgvChecklistSensos.Columns["Senso"]!.Width = 220;
            dgvChecklistSensos.Columns["Nota"]!.Width = 100;

            dgvChecklistSensos.Rows.Clear();
            string[] sensos =
            {
                "1S - Seiri (Utilização)",
                "2S - Seiton (Organização)",
                "3S - Seiso (Limpeza)",
                "4S - Seiketsu (Padronização)",
                "5S - Shitsuke (Disciplina)"
            };

            foreach (var senso in sensos)
            {
                int indice = dgvChecklistSensos.Rows.Add();
                dgvChecklistSensos.Rows[indice].Cells["Senso"].Value = senso;
                dgvChecklistSensos.Rows[indice].Cells["Nota"].Value = 0;
            }
        }

        private void CarregarAuditores()
        {
            cboAuditor.DataSource = ColaboradorDAO.Listar();
            cboAuditor.DisplayMember = "Nome";
            cboAuditor.ValueMember = "Id";
        }

        private void CarregarAcompanhantes()
        {
            var lista = ColaboradorDAO.Listar();
            lista.Insert(0, new Colaborador { Id = 0, Nome = "(Não informar)" });
            cboAcompanhante.DataSource = lista;
            cboAcompanhante.DisplayMember = "Nome";
            cboAcompanhante.ValueMember = "Id";
        }

        private void CarregarHistorico()
        {
            dgvHistoricoAuditorias.DataSource = null;
            dgvHistoricoAuditorias.DataSource = AuditoriaDAO.Listar();
        }

        private void AtualizarGridPlacas()
        {
            dgvPlacasProvisorias.DataSource = null;
            dgvPlacasProvisorias.DataSource = _placasProvisorias;

            if (dgvPlacasProvisorias.Columns["Id"] != null) dgvPlacasProvisorias.Columns["Id"]!.Visible = false;
            if (dgvPlacasProvisorias.Columns["IdAuditoria"] != null) dgvPlacasProvisorias.Columns["IdAuditoria"]!.Visible = false;
            if (dgvPlacasProvisorias.Columns["Status"] != null) dgvPlacasProvisorias.Columns["Status"]!.Visible = false;
            if (dgvPlacasProvisorias.Columns["LocalPlaca"] != null) dgvPlacasProvisorias.Columns["LocalPlaca"]!.HeaderText = "Local";
            if (dgvPlacasProvisorias.Columns["DataVencimento"] != null) dgvPlacasProvisorias.Columns["DataVencimento"]!.HeaderText = "Vencimento";
        }

        private void AtualizarGridItensCorrecao()
        {
            dgvItensCorrecao.DataSource = null;
            dgvItensCorrecao.DataSource = _itensCorrecao;

            if (dgvItensCorrecao.Columns["Id"] != null) dgvItensCorrecao.Columns["Id"]!.Visible = false;
            if (dgvItensCorrecao.Columns["IdAuditoria"] != null) dgvItensCorrecao.Columns["IdAuditoria"]!.Visible = false;
            if (dgvItensCorrecao.Columns["Status"] != null) dgvItensCorrecao.Columns["Status"]!.Visible = false;
            if (dgvItensCorrecao.Columns["Descricao"] != null) dgvItensCorrecao.Columns["Descricao"]!.HeaderText = "Item a corrigir";
            if (dgvItensCorrecao.Columns["DataLimite"] != null) dgvItensCorrecao.Columns["DataLimite"]!.HeaderText = "Prazo";
        }

        private void btnAdicionarPlaca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocalPlaca.Text))
            {
                MessageBox.Show("Informe o local da placa provisória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _placasProvisorias.Add(new PlacaProvisoria
            {
                LocalPlaca = txtLocalPlaca.Text.Trim(),
                DataVencimento = dtpVencimentoPlaca.Value.Date
            });

            txtLocalPlaca.Text = string.Empty;
            AtualizarGridPlacas();
        }

        private void btnRemoverPlaca_Click(object sender, EventArgs e)
        {
            var linhaSelecionada = dgvPlacasProvisorias.CurrentRow;
            if (linhaSelecionada == null)
            {
                MessageBox.Show("Selecione uma placa na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var placaSelecionada = (PlacaProvisoria)linhaSelecionada.DataBoundItem!;
            _placasProvisorias.Remove(placaSelecionada);
            AtualizarGridPlacas();
        }

        private void btnAdicionarItemCorrecao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescricaoItemCorrecao.Text))
            {
                MessageBox.Show("Descreva o item que precisa ser corrigido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _itensCorrecao.Add(new ItemCorrecao
            {
                Descricao = txtDescricaoItemCorrecao.Text.Trim(),
                DataLimite = dtpPrazoItemCorrecao.Value.Date
            });

            txtDescricaoItemCorrecao.Text = string.Empty;
            AtualizarGridItensCorrecao();
        }

        private void btnRemoverItemCorrecao_Click(object sender, EventArgs e)
        {
            var linhaSelecionada = dgvItensCorrecao.CurrentRow;
            if (linhaSelecionada == null)
            {
                MessageBox.Show("Selecione um item na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var itemSelecionado = (ItemCorrecao)linhaSelecionada.DataBoundItem!;
            _itensCorrecao.Remove(itemSelecionado);
            AtualizarGridItensCorrecao();
        }

        private void btnSalvarAuditoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSetor.Text))
            {
                MessageBox.Show("Informe o setor auditado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboAuditor.SelectedValue == null)
            {
                MessageBox.Show("Selecione o Guardião responsável pela auditoria.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var itens = new List<ItemAuditoria>();
            int somaNotas = 0;

            foreach (DataGridViewRow linha in dgvChecklistSensos.Rows)
            {
                string senso = linha.Cells["Senso"].Value?.ToString() ?? string.Empty;
                string notaTexto = linha.Cells["Nota"].Value?.ToString() ?? "0";

                if (!int.TryParse(notaTexto, out int nota) || nota < 0 || nota > 5)
                {
                    MessageBox.Show($"A nota do item '{senso}' deve ser um número inteiro entre 0 e 5.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                itens.Add(new ItemAuditoria
                {
                    Senso = senso,
                    Nota = nota,
                    Observacao = linha.Cells["Observacao"].Value?.ToString() ?? string.Empty
                });
                somaNotas += nota;
            }

            decimal pontuacaoTotal = Math.Round((somaNotas / (decimal)(itens.Count * 5)) * 100, 2);

            int idAcompanhanteSelecionado = Convert.ToInt32(cboAcompanhante.SelectedValue);

            var cabecalho = new Auditoria
            {
                Data = dtpDataAuditoria.Value.Date,
                Setor = txtSetor.Text.Trim(),
                IdColaboradorAuditor = Convert.ToInt32(cboAuditor.SelectedValue),
                IdColaboradorAcompanhante = idAcompanhanteSelecionado == 0 ? (int?)null : idAcompanhanteSelecionado,
                PontuacaoTotal = pontuacaoTotal,
                ObservacoesGerais = txtObservacoesGerais.Text.Trim()
            };

            AuditoriaDAO.Inserir(cabecalho, itens, _placasProvisorias, _itensCorrecao, Sessao.IdUsuario);

            MessageBox.Show($"Auditoria registrada! Pontuação do checklist 5S: {pontuacaoTotal}%", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtSetor.Text = string.Empty;
            txtObservacoesGerais.Text = string.Empty;
            cboAcompanhante.SelectedIndex = 0;
            ConfigurarChecklistPadrao();

            _placasProvisorias = new List<PlacaProvisoria>();
            _itensCorrecao = new List<ItemCorrecao>();
            AtualizarGridPlacas();
            AtualizarGridItensCorrecao();

            CarregarHistorico();


        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}