using System;
using System.Linq;
using System.Windows.Forms;
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
                    btnSalvarEvento.Text = "Registrar Evento";
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
                    btnSalvarEvento.Text = "Registrar Evento";
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
                    btnSalvarEvento.Text = "Atualizar Evento";
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