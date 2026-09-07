using System;
using System.Drawing;
using System.Windows.Forms;
using GuardiaoCincoS.Servicos;

namespace GuardiaoCincoS.Formularios
{
    // Tela própria de aviso de atualização — substitui a tela padrão do
    // AutoUpdater.NET (que é em inglês e tenta mostrar a página inteira do
    // GitHub). Aqui só mostramos texto puro de changelog, sem navegador
    // embutido nenhum. Mesmo padrão usado no Sistema de Escala.
    public class FormAtualizacaoDisponivel : Form
    {
        public bool AtualizarAgora { get; private set; } = false;

        public FormAtualizacaoDisponivel(string versaoAtual, string versaoNova, string changelog)
        {
            Text = "Atualização disponível";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(460, 420);
            Font = new Font("Segoe UI", 9.5f);

            var pnlTopo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = EstiloVisual.AzulMarinho
            };
            var lblTitulo = new Label
            {
                Text = "Uma nova versão do Sistema Guardião 5S está disponível!",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                Location = new Point(20, 15),
                Size = new Size(420, 40)
            };
            var lblVersoes = new Label
            {
                Text = $"Versão instalada: {versaoAtual}      →      Nova versão: {versaoNova}",
                ForeColor = EstiloVisual.AmareloKyly,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Location = new Point(20, 58),
                Size = new Size(420, 24)
            };
            pnlTopo.Controls.Add(lblTitulo);
            pnlTopo.Controls.Add(lblVersoes);

            var lblNotas = new Label
            {
                Text = "O que mudou nessa versão:",
                Location = new Point(20, 104),
                AutoSize = true,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = EstiloVisual.TextoTitulo
            };

            var txtChangelog = new RichTextBox
            {
                Location = new Point(20, 128),
                Size = new Size(420, 210),
                ReadOnly = true,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = EstiloVisual.FundoPagina,
                Font = new Font("Segoe UI", 9f),
                Text = string.IsNullOrWhiteSpace(changelog) ? "(sem notas para esta versão)" : changelog
            };

            var btnDepois = new Button
            {
                Text = "Agora não",
                Location = new Point(230, 355),
                Size = new Size(100, 34)
            };
            btnDepois.Click += (s, e) => { AtualizarAgora = false; DialogResult = DialogResult.OK; Close(); };

            var btnAtualizar = new Button
            {
                Text = "Atualizar agora",
                Location = new Point(340, 355),
                Size = new Size(100, 34),
                BackColor = EstiloVisual.AzulKyly,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAtualizar.FlatAppearance.BorderSize = 0;
            btnAtualizar.Click += (s, e) => { AtualizarAgora = true; DialogResult = DialogResult.OK; Close(); };

            Controls.Add(pnlTopo);
            Controls.Add(lblNotas);
            Controls.Add(txtChangelog);
            Controls.Add(btnDepois);
            Controls.Add(btnAtualizar);

            AcceptButton = btnAtualizar;
            CancelButton = btnDepois;
        }
    }
}