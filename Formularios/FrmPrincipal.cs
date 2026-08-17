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
            if (Sessao.NomePerfil != "Administrador")
            {
                mnuUsuarios.Visible = false;
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
            this.Hide();
            using (var frm = new FrmLogin())
            {
                frm.ShowDialog();
            }
            this.Close();
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

        private void mnuOnboarding_Click(object sender, EventArgs e)
        {
            var frm = new FrmOnboarding();
            frm.ShowDialog();
        }

        private void mnuMateriais_Click(object sender, EventArgs e)
        {
            var frm = new FrmMateriais();
            frm.ShowDialog();
        }

        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            var frm = new FrmUsuarios();
            frm.ShowDialog();
        }
    }
}
