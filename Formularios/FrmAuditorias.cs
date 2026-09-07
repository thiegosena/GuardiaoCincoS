using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GuardiaoCincoS.Controles;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmAuditorias : Form
    {
        private enum ModoTela
        {
            Novo,
            Visualizacao,
            Edicao
        }

        private List<PlacaProvisoria> _placasProvisorias = new List<PlacaProvisoria>();
        private List<ItemCorrecao> _itensCorrecao = new List<ItemCorrecao>();

        private ModoTela _modoAtual = ModoTela.Novo;
        private int _idAuditoriaSelecionada = 0;

        public FrmAuditorias()
        {
            InitializeComponent();
        }

        private void FrmAuditorias_Load(object sender, EventArgs e)
        {
            MontarLayout();

            EstiloVisual.ConfigurarGrid(dgvHistoricoAuditorias);
            EstiloVisual.ConfigurarGrid(dgvChecklistSensos, somenteLeitura: false);
            EstiloVisual.ConfigurarGrid(dgvPlacasProvisorias);
            EstiloVisual.ConfigurarGrid(dgvItensCorrecao);

            ConfigurarChecklistPadrao();
            CarregarAuditores();
            CarregarAcompanhantes();
            CarregarHistorico();
            dtpDataAuditoria.Value = DateTime.Today;
            dtpVencimentoPlaca.Value = DateTime.Today;
            dtpPrazoItemCorrecao.Value = DateTime.Today;

            AplicarModo(ModoTela.Novo);
        }

        private void MontarLayout()
        {
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen; // usado só se o usuário restaurar a janela
            MinimumSize = new Size(1100, 750);
            BackColor = EstiloVisual.FundoPagina;

            var pnlCabecalho = EstiloVisual.CriarCabecalho("Auditorias 5S");

            // Sem AutoScroll -- a grade 2x2 abaixo é toda baseada em porcentagem (Percent),
            // então ela sempre ocupa exatamente o espaço disponível, sem sobrar nem cortar,
            // não importa o tamanho da tela.
            var pnlConteudo = new Panel { Dock = DockStyle.Fill, BackColor = EstiloVisual.FundoPagina, Padding = new Padding(20) };

            // ===== Grade principal 2x2 =====
            var gradePrincipal = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2 };
            gradePrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            gradePrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            gradePrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            gradePrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));

            // ===== Card 1: histórico =====
            var cartaoHistorico = new CartaoSecao
            {
                Titulo = "Histórico de Auditorias",
                CorDestaque = EstiloVisual.AzulKyly,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 10, 10)
            };
            dgvHistoricoAuditorias.Dock = DockStyle.Fill;
            dgvHistoricoAuditorias.Parent = cartaoHistorico.PainelConteudo;

            // ===== Card 2: dados da auditoria + checklist =====
            var cartaoDados = new CartaoSecao
            {
                Titulo = "Dados da Auditoria",
                CorDestaque = EstiloVisual.AmareloKyly,
                Dock = DockStyle.Fill,
                Margin = new Padding(10, 0, 0, 10)
            };

            var gradeDados = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 5 };
            gradeDados.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gradeDados.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gradeDados.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            gradeDados.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            gradeDados.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            gradeDados.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // checklist -- ocupa todo o resto
            gradeDados.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            gradeDados.Controls.Add(EstiloVisual.CriarCampo("Data", dtpDataAuditoria), 0, 0);
            gradeDados.Controls.Add(EstiloVisual.CriarCampo("Setor", txtSetor), 1, 0);
            gradeDados.Controls.Add(EstiloVisual.CriarCampo("Guardião responsável", cboAuditor), 0, 1);
            gradeDados.Controls.Add(EstiloVisual.CriarCampo("Colaborador acompanhante", cboAcompanhante), 1, 1);

            var lblChecklist = EstiloVisual.CriarTituloSubsecao("Checklist 5S");
            gradeDados.Controls.Add(lblChecklist, 0, 2);
            gradeDados.SetColumnSpan(lblChecklist, 2);

            dgvChecklistSensos.Dock = DockStyle.Fill;
            gradeDados.Controls.Add(dgvChecklistSensos, 0, 3);
            gradeDados.SetColumnSpan(dgvChecklistSensos, 2);

            var campoObservacoesGerais = EstiloVisual.CriarCampoMultilinha("Observações gerais", txtObservacoesGerais, 55);
            gradeDados.Controls.Add(campoObservacoesGerais, 0, 4);
            gradeDados.SetColumnSpan(campoObservacoesGerais, 2);

            cartaoDados.PainelConteudo.Controls.Add(gradeDados);

            // ===== Card 3: placas provisórias =====
            var cartaoPlacas = new CartaoSecao
            {
                Titulo = "Placas Provisórias Identificadas",
                CorDestaque = EstiloVisual.Laranja,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 10, 10, 0)
            };

            var gradePlacas = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 3 };
            gradePlacas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gradePlacas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gradePlacas.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            gradePlacas.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            gradePlacas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // grid -- ocupa todo o resto

            gradePlacas.Controls.Add(EstiloVisual.CriarCampo("Local da placa", txtLocalPlaca), 0, 0);
            gradePlacas.Controls.Add(EstiloVisual.CriarCampo("Vencimento", dtpVencimentoPlaca), 1, 0);

            var pnlBotoesPlacas = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true, Dock = DockStyle.Top, Height = 50, Margin = new Padding(6, 4, 6, 8) };
            EstiloVisual.EstilizarBotao(btnAdicionarPlaca, "Adicionar Placa", EstiloVisual.Verde, Color.White);
            EstiloVisual.EstilizarBotao(btnRemoverPlaca, "Remover Placa", EstiloVisual.Vermelho, Color.White);
            pnlBotoesPlacas.Controls.Add(btnAdicionarPlaca);
            pnlBotoesPlacas.Controls.Add(btnRemoverPlaca);
            gradePlacas.Controls.Add(pnlBotoesPlacas, 0, 1);
            gradePlacas.SetColumnSpan(pnlBotoesPlacas, 2);

            dgvPlacasProvisorias.Dock = DockStyle.Fill;
            gradePlacas.Controls.Add(dgvPlacasProvisorias, 0, 2);
            gradePlacas.SetColumnSpan(dgvPlacasProvisorias, 2);

            cartaoPlacas.PainelConteudo.Controls.Add(gradePlacas);

            // ===== Card 4: itens de correção =====
            var cartaoItens = new CartaoSecao
            {
                Titulo = "Itens para Correção",
                CorDestaque = EstiloVisual.Laranja,
                Dock = DockStyle.Fill,
                Margin = new Padding(10, 10, 0, 0)
            };

            var gradeItens = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 3 };
            gradeItens.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gradeItens.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gradeItens.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            gradeItens.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            gradeItens.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // grid -- ocupa todo o resto

            gradeItens.Controls.Add(EstiloVisual.CriarCampo("Item a corrigir", txtDescricaoItemCorrecao), 0, 0);
            gradeItens.Controls.Add(EstiloVisual.CriarCampo("Prazo para conclusão", dtpPrazoItemCorrecao), 1, 0);

            var pnlBotoesItens = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true, Dock = DockStyle.Top, Height = 50, Margin = new Padding(6, 4, 6, 8) };
            EstiloVisual.EstilizarBotao(btnAdicionarItemCorrecao, "Adicionar Item", EstiloVisual.Verde, Color.White);
            EstiloVisual.EstilizarBotao(btnRemoverItemCorrecao, "Remover Item", EstiloVisual.Vermelho, Color.White);
            pnlBotoesItens.Controls.Add(btnAdicionarItemCorrecao);
            pnlBotoesItens.Controls.Add(btnRemoverItemCorrecao);
            gradeItens.Controls.Add(pnlBotoesItens, 0, 1);
            gradeItens.SetColumnSpan(pnlBotoesItens, 2);

            dgvItensCorrecao.Dock = DockStyle.Fill;
            gradeItens.Controls.Add(dgvItensCorrecao, 0, 2);
            gradeItens.SetColumnSpan(dgvItensCorrecao, 2);

            cartaoItens.PainelConteudo.Controls.Add(gradeItens);

            // Cada card ocupa uma célula fixa da grade 2x2 -- diferente do Dock=Top de
            // antes, aqui a posição é definida pela célula (coluna, linha), não pela
            // ordem de adição. Por isso não existe mais risco de inverter a ordem.
            gradePrincipal.Controls.Add(cartaoHistorico, 0, 0);
            gradePrincipal.Controls.Add(cartaoDados, 1, 0);
            gradePrincipal.Controls.Add(cartaoPlacas, 0, 1);
            gradePrincipal.Controls.Add(cartaoItens, 1, 1);

            // ===== Ações finais =====
            var pnlAcoes = new Panel { Dock = DockStyle.Bottom, Height = 50 };
            var flpAcoes = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };

            EstiloVisual.EstilizarBotao(btnNovaAuditoria, "Nova", EstiloVisual.AzulKyly, Color.White);
            EstiloVisual.EstilizarBotao(btnEditarAuditoria, "Editar", EstiloVisual.AmareloKyly, EstiloVisual.TextoTitulo);
            EstiloVisual.EstilizarBotao(btnCancelarEdicaoAuditoria, "Cancelar Edição", Color.FromArgb(210, 214, 220), EstiloVisual.TextoTitulo);
            EstiloVisual.EstilizarBotao(btnSalvarAuditoria, "Salvar", EstiloVisual.Verde, Color.White);
            EstiloVisual.EstilizarBotao(btnExcluirAuditoria, "Excluir", EstiloVisual.Vermelho, Color.White);
            EstiloVisual.EstilizarBotao(btnFechar, "Fechar", Color.FromArgb(210, 214, 220), EstiloVisual.TextoTitulo);

            flpAcoes.Controls.Add(btnNovaAuditoria);
            flpAcoes.Controls.Add(btnEditarAuditoria);
            flpAcoes.Controls.Add(btnCancelarEdicaoAuditoria);
            flpAcoes.Controls.Add(btnSalvarAuditoria);
            flpAcoes.Controls.Add(btnExcluirAuditoria);
            flpAcoes.Controls.Add(btnFechar);
            pnlAcoes.Controls.Add(flpAcoes);

            // Fill primeiro, Bottom por último -- mesma regra de sempre: o último
            // adicionado é processado primeiro e reserva sua faixa antes do Fill.
            pnlConteudo.Controls.Add(gradePrincipal);
            pnlConteudo.Controls.Add(pnlAcoes);

            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
        }



        private void ConfigurarChecklistPadrao()
        {
            dgvChecklistSensos.Columns.Clear();
            dgvChecklistSensos.Columns.Add("Senso", "Senso");
            dgvChecklistSensos.Columns.Add("Nota", "Nota (0 a 5)");
            dgvChecklistSensos.Columns.Add("Observacao", "Observação");

            dgvChecklistSensos.Columns["Senso"]!.ReadOnly = true;
            dgvChecklistSensos.Columns["Senso"]!.FillWeight = 45f;
            dgvChecklistSensos.Columns["Nota"]!.FillWeight = 15f;
            dgvChecklistSensos.Columns["Observacao"]!.FillWeight = 40f;

            dgvChecklistSensos.Rows.Clear();
            string[] sensos =
            {
                "1S - Seiri (Utilização)",
                "2S - Seiton (Organização)",
                "3S - Seiso (Limpeza)",
                "4S - Seiketsu (Saúde)",
                "5S - Shitsuke (Autodisciplina)"
            };

            foreach (var senso in sensos)
            {
                int indice = dgvChecklistSensos.Rows.Add();
                dgvChecklistSensos.Rows[indice].Cells["Senso"].Value = senso;
                dgvChecklistSensos.Rows[indice].Cells["Nota"].Value = 0;
            }
        }

        private void PreencherChecklistComItens(List<ItemAuditoria> itens)
        {
            ConfigurarChecklistPadrao();

            foreach (DataGridViewRow linha in dgvChecklistSensos.Rows)
            {
                string senso = linha.Cells["Senso"].Value?.ToString() ?? string.Empty;
                var itemCorrespondente = itens.FirstOrDefault(i => i.Senso == senso);

                if (itemCorrespondente != null)
                {
                    linha.Cells["Nota"].Value = itemCorrespondente.Nota;
                    linha.Cells["Observacao"].Value = itemCorrespondente.Observacao;
                }
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

            if (dgvHistoricoAuditorias.Columns["Id"] != null) dgvHistoricoAuditorias.Columns["Id"]!.Visible = false;
            if (dgvHistoricoAuditorias.Columns["IdColaboradorAuditor"] != null) dgvHistoricoAuditorias.Columns["IdColaboradorAuditor"]!.Visible = false;
            if (dgvHistoricoAuditorias.Columns["IdColaboradorAcompanhante"] != null) dgvHistoricoAuditorias.Columns["IdColaboradorAcompanhante"]!.Visible = false;

            if (dgvHistoricoAuditorias.Columns["Data"] != null)
            {
                dgvHistoricoAuditorias.Columns["Data"]!.HeaderText = "Data";
                dgvHistoricoAuditorias.Columns["Data"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvHistoricoAuditorias.Columns["Setor"] != null)
                dgvHistoricoAuditorias.Columns["Setor"]!.HeaderText = "Setor";
            if (dgvHistoricoAuditorias.Columns["NomeAuditor"] != null)
                dgvHistoricoAuditorias.Columns["NomeAuditor"]!.HeaderText = "Guardião";
            if (dgvHistoricoAuditorias.Columns["NomeAcompanhante"] != null)
                dgvHistoricoAuditorias.Columns["NomeAcompanhante"]!.HeaderText = "Acompanhante";
            if (dgvHistoricoAuditorias.Columns["PontuacaoTotal"] != null)
            {
                dgvHistoricoAuditorias.Columns["PontuacaoTotal"]!.HeaderText = "Pontuação";
                dgvHistoricoAuditorias.Columns["PontuacaoTotal"]!.DefaultCellStyle.Format = "0.##'%'";
            }
            if (dgvHistoricoAuditorias.Columns["ObservacoesGerais"] != null)
                dgvHistoricoAuditorias.Columns["ObservacoesGerais"]!.HeaderText = "Observações";
            if (dgvHistoricoAuditorias.Columns["DataHoraRegistro"] != null)
            {
                dgvHistoricoAuditorias.Columns["DataHoraRegistro"]!.HeaderText = "Registrado em";
                dgvHistoricoAuditorias.Columns["DataHoraRegistro"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        private void dgvHistoricoAuditorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var linha = dgvHistoricoAuditorias.Rows[e.RowIndex];
            var auditoria = (Auditoria)linha.DataBoundItem!;

            CarregarAuditoriaSelecionada(auditoria.Id);
        }

        private void CarregarAuditoriaSelecionada(int idAuditoria)
        {
            var cabecalho = AuditoriaDAO.ObterCabecalhoPorId(idAuditoria);
            if (cabecalho == null) return;

            _idAuditoriaSelecionada = idAuditoria;

            dtpDataAuditoria.Value = cabecalho.Data;
            txtSetor.Text = cabecalho.Setor;
            cboAuditor.SelectedValue = cabecalho.IdColaboradorAuditor;
            cboAcompanhante.SelectedValue = cabecalho.IdColaboradorAcompanhante ?? 0;
            txtObservacoesGerais.Text = cabecalho.ObservacoesGerais;

            var itensChecklist = ItemAuditoriaDAO.ListarPorAuditoria(idAuditoria);
            PreencherChecklistComItens(itensChecklist);

            _placasProvisorias = PlacaProvisoriaDAO.ListarPorAuditoria(idAuditoria);
            _itensCorrecao = ItemCorrecaoDAO.ListarPorAuditoria(idAuditoria);
            AtualizarGridPlacas();
            AtualizarGridItensCorrecao();

            AplicarModo(ModoTela.Visualizacao);
        }

        private void AplicarModo(ModoTela modo)
        {
            _modoAtual = modo;

            switch (modo)
            {
                case ModoTela.Novo:
                    LimparFormularioParaNovo();
                    HabilitarCamposCadastro(true);
                    btnSalvarAuditoria.Text = "Salvar";
                    btnSalvarAuditoria.Enabled = true;
                    btnNovaAuditoria.Enabled = false;
                    btnEditarAuditoria.Enabled = false;
                    btnCancelarEdicaoAuditoria.Enabled = false;
                    btnExcluirAuditoria.Enabled = false;
                    dgvHistoricoAuditorias.Enabled = true;
                    break;

                case ModoTela.Visualizacao:
                    HabilitarCamposCadastro(false);
                    btnSalvarAuditoria.Text = "Salvar";
                    btnSalvarAuditoria.Enabled = false;
                    btnNovaAuditoria.Enabled = true;
                    btnEditarAuditoria.Enabled = true;
                    btnCancelarEdicaoAuditoria.Enabled = false;
                    btnExcluirAuditoria.Enabled = Sessao.NomePerfil == "Administrador";
                    dgvHistoricoAuditorias.Enabled = true;
                    break;

                case ModoTela.Edicao:
                    HabilitarCamposCadastro(true);
                    btnSalvarAuditoria.Text = "Atualizar";
                    btnSalvarAuditoria.Enabled = true;
                    btnNovaAuditoria.Enabled = false;
                    btnEditarAuditoria.Enabled = false;
                    btnCancelarEdicaoAuditoria.Enabled = true;
                    btnExcluirAuditoria.Enabled = false;
                    dgvHistoricoAuditorias.Enabled = false;
                    break;
            }

            if (Sessao.NomePerfil == "Colaborador")
            {
                HabilitarCamposCadastro(false);
                btnSalvarAuditoria.Enabled = false;
                btnNovaAuditoria.Enabled = false;
                btnEditarAuditoria.Enabled = false;
                btnCancelarEdicaoAuditoria.Enabled = false;
                btnExcluirAuditoria.Enabled = false;
            }
        }

        private void HabilitarCamposCadastro(bool habilitado)
        {
            dtpDataAuditoria.Enabled = habilitado;
            txtSetor.Enabled = habilitado;
            cboAuditor.Enabled = habilitado;
            cboAcompanhante.Enabled = habilitado;
            dgvChecklistSensos.Enabled = habilitado;
            txtObservacoesGerais.Enabled = habilitado;
            txtLocalPlaca.Enabled = habilitado;
            dtpVencimentoPlaca.Enabled = habilitado;
            btnAdicionarPlaca.Enabled = habilitado;
            btnRemoverPlaca.Enabled = habilitado;
            txtDescricaoItemCorrecao.Enabled = habilitado;
            dtpPrazoItemCorrecao.Enabled = habilitado;
            btnAdicionarItemCorrecao.Enabled = habilitado;
            btnRemoverItemCorrecao.Enabled = habilitado;
        }

        private void LimparFormularioParaNovo()
        {
            _idAuditoriaSelecionada = 0;
            dtpDataAuditoria.Value = DateTime.Today;
            txtSetor.Text = string.Empty;
            if (cboAcompanhante.Items.Count > 0) cboAcompanhante.SelectedIndex = 0;
            txtObservacoesGerais.Text = string.Empty;
            dtpVencimentoPlaca.Value = DateTime.Today;
            dtpPrazoItemCorrecao.Value = DateTime.Today;

            ConfigurarChecklistPadrao();

            _placasProvisorias = new List<PlacaProvisoria>();
            _itensCorrecao = new List<ItemCorrecao>();
            AtualizarGridPlacas();
            AtualizarGridItensCorrecao();
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
                DataVencimento = dtpVencimentoPlaca.Value.Date,
                Status = "Pendente"
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
                DataLimite = dtpPrazoItemCorrecao.Value.Date,
                Status = "Pendente"
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
                Id = _idAuditoriaSelecionada,
                Data = dtpDataAuditoria.Value.Date,
                Setor = txtSetor.Text.Trim(),
                IdColaboradorAuditor = Convert.ToInt32(cboAuditor.SelectedValue),
                IdColaboradorAcompanhante = idAcompanhanteSelecionado == 0 ? (int?)null : idAcompanhanteSelecionado,
                PontuacaoTotal = pontuacaoTotal,
                ObservacoesGerais = txtObservacoesGerais.Text.Trim()
            };

            if (_modoAtual == ModoTela.Edicao)
            {
                AuditoriaDAO.Atualizar(cabecalho, itens, _placasProvisorias, _itensCorrecao);
                MessageBox.Show($"Auditoria atualizada! Pontuação do checklist 5S: {pontuacaoTotal}%", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AuditoriaDAO.Inserir(cabecalho, itens, _placasProvisorias, _itensCorrecao, Sessao.IdUsuario);
                MessageBox.Show($"Auditoria registrada! Pontuação do checklist 5S: {pontuacaoTotal}%", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CarregarHistorico();
            AplicarModo(ModoTela.Novo);
        }

        private void btnNovaAuditoria_Click(object sender, EventArgs e)
        {
            AplicarModo(ModoTela.Novo);
        }

        private void btnEditarAuditoria_Click(object sender, EventArgs e)
        {
            if (_idAuditoriaSelecionada == 0)
            {
                MessageBox.Show("Selecione uma auditoria no histórico primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AplicarModo(ModoTela.Edicao);
        }

        private void btnCancelarEdicaoAuditoria_Click(object sender, EventArgs e)
        {
            if (_idAuditoriaSelecionada == 0)
            {
                AplicarModo(ModoTela.Novo);
            }
            else
            {
                CarregarAuditoriaSelecionada(_idAuditoriaSelecionada);
            }
        }

        private void btnExcluirAuditoria_Click(object sender, EventArgs e)
        {
            if (_idAuditoriaSelecionada == 0)
            {
                MessageBox.Show("Selecione uma auditoria no histórico primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacao = MessageBox.Show(
                "Excluir esta auditoria definitivamente? Isso remove também todas as placas provisórias e " +
                "itens de correção vinculados a ela. Esta ação não pode ser desfeita.",
                "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacao != DialogResult.Yes) return;

            AuditoriaDAO.Excluir(_idAuditoriaSelecionada);

            CarregarHistorico();
            AplicarModo(ModoTela.Novo);

            MessageBox.Show("Auditoria excluída.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}