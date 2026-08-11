using GuardiaoCincoS.Servicos;
using GuardiaoCincoS.Formularios;
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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblStatusUsuario.Text = $"Logado como: {Sessao.NomeCompleto} ({Sessao.NomePerfil})";

            if (Sessao.NomePerfil == "Colaborador")
            {
                cadastrosToolStripMenuItem.Visible = false;
            }
        }

        private void mnuCadastrosColaboradores_Click(object sender, EventArgs e)
        {
            var frm = new FrmColaboradores();
            frm.ShowDialog();
        }

        private void mnuCadastrosEscala5S_Click(object sender, EventArgs e)
        {
            var frm = new FrmEscala5SSemanal();
            frm.ShowDialog();
        }

        private void mnuSistemaSair_Click(object sender, EventArgs e)
        {
            Sessao.Encerrar();
            Application.Exit();
        }

        private void mnuRondas_Click(object sender, EventArgs e)
        {
            var frm = new FrmRondas();
            frm.ShowDialog();
        }

        private void mnuAuditorias_Click(object sender, EventArgs e)
        {
            var frm = new FrmAuditorias();
            frm.ShowDialog();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuDemarcacoes_Click(object sender, EventArgs e)
        {
            var frm = new FrmDemarcacoes();
            frm.ShowDialog();
        }
    }
}
