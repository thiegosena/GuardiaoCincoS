using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GuardiaoCincoS.Controles;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmCalendarioEventos : Form
    {
        private enum ModoTela
        {
            Novo,
            Visualizacao,
            Edicao
        }

        private ModoTela _modoAtual = ModoTela.Novo;
        private EventoCalendario? _eventoSelecionado = null;

        public FrmCalendarioEventos()
        {
            InitializeComponent();
        }

        private void FrmCalendarioEventos_Load(object sender, EventArgs e)
        {
            MontarLayout();

            cboTipoEvento.Items.Clear();
            cboTipoEvento.Items.AddRange(new object[]
            {
                "Treinamento",
                "Curso",
                "Reunião",
                "Onboarding",
                "Auditoria",
                "Tour",
                "Confraternização",
                "Outro"
            });

            CarregarResponsaveis();
            AtualizarDiasComEventoNoCalendario();

            mcalEventos.SelectionStart = DateTime.Today;
            mcalEventos.SelectionEnd = DateTime.Today;

            CarregarEventosDoDiaSelecionado();
            AplicarModo(ModoTela.Novo);
        }

        private void MontarLayout()
        {
            WindowState = FormWindowState.Maximized;
            ClientSize = new Size(1100, 780);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = EstiloVisual.FundoPagina;

            var pnlCabecalho = EstiloVisual.CriarCabecalho("Calendário de Eventos");

            var pnlConteudo = new Panel { Dock = DockStyle.Fill, BackColor = EstiloVisual.FundoPagina, Padding = new Padding(20) };

            // ===== Barra de ações (rodapé, atravessa as duas colunas) =====
            var pnlAcoes = new Panel { Dock = DockStyle.Bottom, Height = 60, Padding = new Padding(0, 20, 0, 0) };
            var flpAcoes = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };

            EstiloVisual.EstilizarBotao(btnNovoEvento, "Novo", EstiloVisual.AzulKyly, Color.White);
            EstiloVisual.EstilizarBotao(btnEditarEvento, "Editar", EstiloVisual.AmareloKyly, EstiloVisual.TextoTitulo);
            EstiloVisual.EstilizarBotao(btnCancelarEdicaoEvento, "Cancelar Edição", Color.FromArgb(210, 214, 220), EstiloVisual.TextoTitulo);
            EstiloVisual.EstilizarBotao(btnSalvarEvento, "Salvar", EstiloVisual.Verde, Color.White);
            EstiloVisual.EstilizarBotao(btnCancelarEvento, "Cancelar Evento", EstiloVisual.Vermelho, Color.White);
            EstiloVisual.EstilizarBotao(btnReativarEvento, "Reativar", EstiloVisual.Verde, Color.White);

            flpAcoes.Controls.Add(btnNovoEvento);
            flpAcoes.Controls.Add(btnEditarEvento);
            flpAcoes.Controls.Add(btnCancelarEdicaoEvento);
            flpAcoes.Controls.Add(btnSalvarEvento);
            flpAcoes.Controls.Add(btnCancelarEvento);
            flpAcoes.Controls.Add(btnReativarEvento);
            pnlAcoes.Controls.Add(flpAcoes);

            // ===== Grade principal: 2 colunas (esquerda 42%, direita 58%) =====
            var gradePrincipal = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            gradePrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            gradePrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));

            // ----- Coluna esquerda: Calendário (topo) + Eventos do Dia (resto) -----
            var pnlEsquerda = new Panel { Dock = DockStyle.Fill };

            var cartaoEventosDia = new CartaoSecao
            {
                Titulo = "Eventos do Dia Selecionado",
                CorDestaque = EstiloVisual.AzulKyly,
                Dock = DockStyle.Fill
            };
            dgvEventosDoDia.Dock = DockStyle.Fill;
            dgvEventosDoDia.Parent = cartaoEventosDia.PainelConteudo;
            EstiloVisual.ConfigurarGrid(dgvEventosDoDia);

            var cartaoCalendario = new CartaoSecao
            {
                Titulo = "Calendário",
                CorDestaque = EstiloVisual.AmareloKyly,
                Dock = DockStyle.Top,
                Height = 300,
                Margin = new Padding(0, 0, 0, 20)
            };

            chkMostrarCancelados.Dock = DockStyle.Bottom;
            chkMostrarCancelados.Height = 26;
            chkMostrarCancelados.Font = EstiloVisual.FonteTexto;
            chkMostrarCancelados.Parent = cartaoCalendario.PainelConteudo;

            mcalEventos.Dock = DockStyle.Fill;
            mcalEventos.BackColor = Color.White;
            mcalEventos.ForeColor = EstiloVisual.TextoTitulo;
            mcalEventos.TitleBackColor = EstiloVisual.AzulMarinho;
            mcalEventos.TitleForeColor = Color.White;
            mcalEventos.TrailingForeColor = EstiloVisual.TextoSecundario;
            mcalEventos.Parent = cartaoCalendario.PainelConteudo;

            // Fill primeiro, Top depois -- mesma regra de sempre: o último
            // adicionado (Calendário) reserva sua faixa antes do Fill (Eventos do Dia).
            pnlEsquerda.Controls.Add(cartaoEventosDia);
            pnlEsquerda.Controls.Add(cartaoCalendario);

            // ----- Coluna direita: Dados do Evento -----
            var cartaoDados = new CartaoSecao
            {
                Titulo = "Dados do Evento",
                CorDestaque = EstiloVisual.Verde,
                Dock = DockStyle.Fill,
                Margin = new Padding(20, 0, 0, 0)
            };

            var grade = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 5 };
            grade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grade.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grade.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grade.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grade.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grade.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Descrição -- ocupa o resto

            var campoTitulo = EstiloVisual.CriarCampo("Título", txtTituloEvento);
            grade.Controls.Add(campoTitulo, 0, 0);
            grade.SetColumnSpan(campoTitulo, 2);

            grade.Controls.Add(EstiloVisual.CriarCampo("Tipo", cboTipoEvento), 0, 1);
            grade.Controls.Add(EstiloVisual.CriarCampo("Local", txtLocalEvento), 1, 1);

            grade.Controls.Add(EstiloVisual.CriarCampo("Data início", dtpDataInicioEvento), 0, 2);
            grade.Controls.Add(EstiloVisual.CriarCampo("Data fim", dtpDataFimEvento), 1, 2);

            var campoResponsavel = EstiloVisual.CriarCampo("Responsável (opcional)", cboResponsavelEvento);
            grade.Controls.Add(campoResponsavel, 0, 3);
            grade.SetColumnSpan(campoResponsavel, 2);

            var campoDescricao = EstiloVisual.CriarCampoMultilinha("Descrição", txtDescricaoEvento, 120);
            grade.Controls.Add(campoDescricao, 0, 4);
            grade.SetColumnSpan(campoDescricao, 2);

            cartaoDados.PainelConteudo.Controls.Add(grade);

            gradePrincipal.Controls.Add(pnlEsquerda, 0, 0);
            gradePrincipal.Controls.Add(cartaoDados, 1, 0);

            // Fill primeiro, Bottom por último -- mesma regra de sempre.
            pnlConteudo.Controls.Add(gradePrincipal);
            pnlConteudo.Controls.Add(pnlAcoes);

            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);

            // MaxLength trava fisicamente a digitação no limite de cada coluna do
            // banco (mesma lição aplicada em Materiais na resposta anterior).
            txtTituloEvento.MaxLength = 200;
            cboTipoEvento.MaxLength = 50;
            txtLocalEvento.MaxLength = 150;
            txtDescricaoEvento.MaxLength = 500;
        }

        private void CarregarResponsaveis()
        {
            var lista = ColaboradorDAO.Listar();
            lista.Insert(0, new Colaborador { Id = 0, Nome = "(Não definir)" });
            cboResponsavelEvento.DataSource = lista;
            cboResponsavelEvento.DisplayMember = "Nome";
            cboResponsavelEvento.ValueMember = "Id";
        }

        private void AtualizarDiasComEventoNoCalendario()
        {
            var datas = EventoCalendarioDAO.ListarDatasComEventos();
            mcalEventos.BoldedDates = datas.Distinct().ToArray();
        }

        private void CarregarEventosDoDiaSelecionado()
        {
            var eventos = EventoCalendarioDAO.ListarPorData(mcalEventos.SelectionStart.Date, chkMostrarCancelados.Checked);
            dgvEventosDoDia.DataSource = null;
            dgvEventosDoDia.DataSource = eventos;

            if (dgvEventosDoDia.Columns["Id"] != null) dgvEventosDoDia.Columns["Id"]!.Visible = false;
            if (dgvEventosDoDia.Columns["IdColaboradorResponsavel"] != null) dgvEventosDoDia.Columns["IdColaboradorResponsavel"]!.Visible = false;
            if (dgvEventosDoDia.Columns["Descricao"] != null) dgvEventosDoDia.Columns["Descricao"]!.Visible = false;

            if (dgvEventosDoDia.Columns["Titulo"] != null) dgvEventosDoDia.Columns["Titulo"]!.HeaderText = "Evento";
            if (dgvEventosDoDia.Columns["Tipo"] != null) dgvEventosDoDia.Columns["Tipo"]!.HeaderText = "Tipo";
            if (dgvEventosDoDia.Columns["Local"] != null) dgvEventosDoDia.Columns["Local"]!.HeaderText = "Local";
            if (dgvEventosDoDia.Columns["NomeResponsavel"] != null) dgvEventosDoDia.Columns["NomeResponsavel"]!.HeaderText = "Responsável";
            if (dgvEventosDoDia.Columns["Status"] != null) dgvEventosDoDia.Columns["Status"]!.HeaderText = "Status";

            if (dgvEventosDoDia.Columns["DataInicio"] != null)
            {
                dgvEventosDoDia.Columns["DataInicio"]!.HeaderText = "Início";
                dgvEventosDoDia.Columns["DataInicio"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvEventosDoDia.Columns["DataFim"] != null)
            {
                dgvEventosDoDia.Columns["DataFim"]!.HeaderText = "Fim";
                dgvEventosDoDia.Columns["DataFim"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            foreach (DataGridViewRow linha in dgvEventosDoDia.Rows)
            {
                var evento = (EventoCalendario)linha.DataBoundItem!;
                if (evento.Status == "Cancelado")
                {
                    linha.DefaultCellStyle.ForeColor = EstiloVisual.TextoSecundario;
                }
            }
        }

        private void mcalEventos_DateChanged(object sender, DateRangeEventArgs e)
        {
            CarregarEventosDoDiaSelecionado();
            AplicarModo(ModoTela.Novo);
        }

        private void chkMostrarCancelados_CheckedChanged(object sender, EventArgs e)
        {
            CarregarEventosDoDiaSelecionado();
        }

        private void dgvEventosDoDia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var linhaSelecionada = dgvEventosDoDia.Rows[e.RowIndex];
            var evento = (EventoCalendario)linhaSelecionada.DataBoundItem!;

            _eventoSelecionado = evento;
            txtTituloEvento.Text = evento.Titulo;
            cboTipoEvento.Text = evento.Tipo;
            dtpDataInicioEvento.Value = evento.DataInicio;
            dtpDataFimEvento.Value = evento.DataFim;
            txtLocalEvento.Text = evento.Local;
            txtDescricaoEvento.Text = evento.Descricao;
            cboResponsavelEvento.SelectedValue = evento.IdColaboradorResponsavel ?? 0;

            AplicarModo(ModoTela.Visualizacao);
        }

        // Centraliza tudo que muda de acordo com o "estado" da tela
        private void AplicarModo(ModoTela modo)
        {
            _modoAtual = modo;

            switch (modo)
            {
                case ModoTela.Novo:
                    LimparCampos();
                    HabilitarCamposCadastro(true);
                    btnSalvarEvento.Text = "Salvar";
                    btnSalvarEvento.Enabled = true;
                    btnEditarEvento.Enabled = false;
                    btnCancelarEdicaoEvento.Enabled = false;
                    btnNovoEvento.Enabled = false;
                    btnCancelarEvento.Enabled = false;
                    btnReativarEvento.Enabled = false;
                    dgvEventosDoDia.Enabled = true;
                    break;

                case ModoTela.Visualizacao:
                    HabilitarCamposCadastro(false);
                    btnSalvarEvento.Text = "Salvar";
                    btnSalvarEvento.Enabled = false;
                    btnEditarEvento.Enabled = true;
                    btnCancelarEdicaoEvento.Enabled = false;
                    btnNovoEvento.Enabled = true;
                    btnCancelarEvento.Enabled = _eventoSelecionado != null && _eventoSelecionado.Status != "Cancelado";
                    btnReativarEvento.Enabled = _eventoSelecionado != null && _eventoSelecionado.Status == "Cancelado";
                    dgvEventosDoDia.Enabled = true;
                    break;

                case ModoTela.Edicao:
                    HabilitarCamposCadastro(true);
                    btnSalvarEvento.Text = "Atualizar";
                    btnSalvarEvento.Enabled = true;
                    btnEditarEvento.Enabled = false;
                    btnCancelarEdicaoEvento.Enabled = true;
                    btnNovoEvento.Enabled = false;
                    btnCancelarEvento.Enabled = false;
                    btnReativarEvento.Enabled = false;
                    dgvEventosDoDia.Enabled = false;
                    break;
            }

            // Colaborador só pode visualizar, nunca cadastrar/editar/cancelar
            if (Sessao.NomePerfil == "Colaborador")
            {
                HabilitarCamposCadastro(false);
                btnNovoEvento.Enabled = false;
                btnEditarEvento.Enabled = false;
                btnCancelarEdicaoEvento.Enabled = false;
                btnSalvarEvento.Enabled = false;
                btnCancelarEvento.Enabled = false;
                btnReativarEvento.Enabled = false;
            }
        }

        private void HabilitarCamposCadastro(bool habilitado)
        {
            txtTituloEvento.Enabled = habilitado;
            cboTipoEvento.Enabled = habilitado;
            dtpDataInicioEvento.Enabled = habilitado;
            dtpDataFimEvento.Enabled = habilitado;
            txtLocalEvento.Enabled = habilitado;
            txtDescricaoEvento.Enabled = habilitado;
            cboResponsavelEvento.Enabled = habilitado;
        }

        private void LimparCampos()
        {
            _eventoSelecionado = null;
            txtTituloEvento.Text = string.Empty;
            cboTipoEvento.Text = string.Empty;
            dtpDataInicioEvento.Value = mcalEventos.SelectionStart.Date;
            dtpDataFimEvento.Value = mcalEventos.SelectionStart.Date;
            txtLocalEvento.Text = string.Empty;
            txtDescricaoEvento.Text = string.Empty;
            if (cboResponsavelEvento.Items.Count > 0) cboResponsavelEvento.SelectedIndex = 0;
        }

        private void btnNovoEvento_Click(object sender, EventArgs e)
        {
            AplicarModo(ModoTela.Novo);
        }

        private void btnEditarEvento_Click(object sender, EventArgs e)
        {
            if (_eventoSelecionado == null)
            {
                MessageBox.Show("Selecione um evento na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AplicarModo(ModoTela.Edicao);
        }

        private void btnCancelarEdicaoEvento_Click(object sender, EventArgs e)
        {
            AplicarModo(ModoTela.Novo);
        }

        private void btnSalvarEvento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTituloEvento.Text))
            {
                MessageBox.Show("Informe o título do evento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cboTipoEvento.Text))
            {
                MessageBox.Show("Informe o tipo do evento (ex: Treinamento, Curso).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpDataFimEvento.Value.Date < dtpDataInicioEvento.Value.Date)
            {
                MessageBox.Show("A data final não pode ser antes da data inicial.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTituloEvento.Text.Trim().Length > 200)
            {
                MessageBox.Show("O título pode ter no máximo 200 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTipoEvento.Text.Trim().Length > 50)
            {
                MessageBox.Show("O tipo pode ter no máximo 50 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtLocalEvento.Text.Trim().Length > 150)
            {
                MessageBox.Show("O local pode ter no máximo 150 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtDescricaoEvento.Text.Trim().Length > 500)
            {
                MessageBox.Show("A descrição pode ter no máximo 500 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idResponsavelSelecionado = Convert.ToInt32(cboResponsavelEvento.SelectedValue);

            var evento = new EventoCalendario
            {
                Id = _eventoSelecionado?.Id ?? 0,
                Titulo = txtTituloEvento.Text.Trim(),
                Tipo = cboTipoEvento.Text.Trim(),
                DataInicio = dtpDataInicioEvento.Value.Date,
                DataFim = dtpDataFimEvento.Value.Date,
                Local = txtLocalEvento.Text.Trim(),
                Descricao = txtDescricaoEvento.Text.Trim(),
                IdColaboradorResponsavel = idResponsavelSelecionado == 0 ? (int?)null : idResponsavelSelecionado
            };

            if (_modoAtual == ModoTela.Edicao)
            {
                EventoCalendarioDAO.Atualizar(evento);
                MessageBox.Show("Evento atualizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EventoCalendarioDAO.Inserir(evento, Sessao.IdUsuario);
                MessageBox.Show("Evento registrado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            AtualizarDiasComEventoNoCalendario();
            CarregarEventosDoDiaSelecionado();
            AplicarModo(ModoTela.Novo);
        }

        private void btnCancelarEvento_Click(object sender, EventArgs e)
        {
            if (_eventoSelecionado == null)
            {
                MessageBox.Show("Selecione um evento na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacao = MessageBox.Show(
                $"Cancelar o evento '{_eventoSelecionado.Titulo}'? Ele fica marcado como cancelado, mas o histórico é mantido.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                EventoCalendarioDAO.Cancelar(_eventoSelecionado.Id);
                AtualizarDiasComEventoNoCalendario();
                CarregarEventosDoDiaSelecionado();
                AplicarModo(ModoTela.Novo);
            }
        }

        private void btnReativarEvento_Click(object sender, EventArgs e)
        {
            if (_eventoSelecionado == null)
            {
                MessageBox.Show("Selecione um evento na lista primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EventoCalendarioDAO.Reativar(_eventoSelecionado.Id);
            AtualizarDiasComEventoNoCalendario();
            CarregarEventosDoDiaSelecionado();
            AplicarModo(ModoTela.Novo);
            MessageBox.Show("Evento reativado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}