using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GuardiaoCincoS.Dados;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Formularios
{
    public partial class FrmEscala5SSemanal : Form
    {
        private List<Colaborador> _todosColaboradores = new List<Colaborador>();

        public FrmEscala5SSemanal()
        {
            InitializeComponent();
        }

        private void FrmEscala5SSemanal_Load(object sender, EventArgs e)
        {
            dtpInicioSemana.Value = ObterSegundaFeira(DateTime.Today);
            CarregarSemana();
        }

        private DateTime ObterSegundaFeira(DateTime data)
        {
            int diferenca = (7 + (data.DayOfWeek - DayOfWeek.Monday)) % 7;
            return data.AddDays(-diferenca).Date;
        }

        private void CarregarSemana()
        {
            DateTime inicio = dtpInicioSemana.Value.Date;
            DateTime fim = inicio.AddDays(6);
            lblFimSemana.Text = $"até {fim:dd/MM/yyyy}";

            _todosColaboradores = ColaboradorDAO.Listar();
            var idsNaEscala = EscalaDAO.ListarColaboradoresNaEscala(inicio).Select(c => c.Id).ToHashSet();

            clbColaboradores.Items.Clear();
            foreach (var colaborador in _todosColaboradores)
            {
                clbColaboradores.Items.Add(colaborador.Nome, idsNaEscala.Contains(colaborador.Id));
            }
        }

        private void btnCarregarSemana_Click(object sender, EventArgs e) => CarregarSemana();

        private void btnSalvarEscala_Click(object sender, EventArgs e)
        {
            DateTime inicio = dtpInicioSemana.Value.Date;
            DateTime fim = inicio.AddDays(6);

            var idsSelecionados = new List<int>();
            for (int i = 0; i < clbColaboradores.Items.Count; i++)
            {
                if (clbColaboradores.GetItemChecked(i))
                    idsSelecionados.Add(_todosColaboradores[i].Id);
            }

            EscalaDAO.SalvarEscala(inicio, fim, idsSelecionados);
            MessageBox.Show("Escala 5S da semana salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}