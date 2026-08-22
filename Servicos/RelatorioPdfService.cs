using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using GuardiaoCincoS.Modelos;

// Aliases: resolvem a ambiguidade entre MigraDoc.DocumentObjectModel.Color/Orientation
// e System.Drawing.Color / System.Windows.Forms.Orientation, que já são importados
// automaticamente em todo o projeto (usings implícitos de projetos WinForms).
using Color = MigraDoc.DocumentObjectModel.Color;
using Orientation = MigraDoc.DocumentObjectModel.Orientation;

namespace GuardiaoCincoS.Servicos
{
    public static class RelatorioPdfService
    {
        private static readonly Color CorAzulMarinho = new Color(27, 42, 74);
        private static readonly Color CorVermelho = new Color(220, 53, 69);
        private static readonly Color CorLaranja = new Color(253, 126, 20);
        private static readonly Color CorVerde = new Color(40, 167, 69);
        private static readonly Color CorCabecalhoTabela = new Color(244, 246, 249);

        public static string GerarRelatorioPendencias(List<ItemPendencia> pendencias)
        {
            var documento = new Document();
            documento.Info.Title = "Relatório de Pendências - Sistema Guardião 5S";
            documento.Info.Author = "Sistema Guardião 5S";

            var secao = documento.AddSection();
            secao.PageSetup.PageFormat = PageFormat.A4;
            secao.PageSetup.Orientation = Orientation.Landscape;
            secao.PageSetup.TopMargin = "1.5cm";
            secao.PageSetup.BottomMargin = "1.5cm";
            secao.PageSetup.LeftMargin = "1.5cm";
            secao.PageSetup.RightMargin = "1.5cm";

            var paragrafoTitulo = secao.AddParagraph("Sistema Guardião 5S");
            paragrafoTitulo.Format.Font.Size = 18;
            paragrafoTitulo.Format.Font.Bold = true;
            paragrafoTitulo.Format.Font.Color = CorAzulMarinho;

            var paragrafoSubtitulo = secao.AddParagraph("Relatório de Pendências dos Guardiões");
            paragrafoSubtitulo.Format.Font.Size = 13;
            paragrafoSubtitulo.Format.Font.Color = CorAzulMarinho;
            paragrafoSubtitulo.Format.SpaceAfter = "0.2cm";

            var paragrafoData = secao.AddParagraph($"Gerado em {DateTime.Now:dd/MM/yyyy HH:mm}");
            paragrafoData.Format.Font.Size = 9;
            paragrafoData.Format.Font.Color = Colors.Gray;
            paragrafoData.Format.SpaceAfter = "0.6cm";

            if (pendencias.Count == 0)
            {
                var paragrafoVazio = secao.AddParagraph("Nenhuma pendência em aberto no momento. Parabéns!");
                paragrafoVazio.Format.Font.Size = 11;
            }
            else
            {
                var tabela = secao.AddTable();
                tabela.Borders.Color = new Color(220, 220, 220);
                tabela.Borders.Width = 0.5;

                tabela.AddColumn("3.2cm");
                tabela.AddColumn("4cm");
                tabela.AddColumn("7cm");
                tabela.AddColumn("2.5cm");
                tabela.AddColumn("3.3cm");

                var linhaCabecalho = tabela.AddRow();
                linhaCabecalho.Shading.Color = CorCabecalhoTabela;
                linhaCabecalho.Format.Font.Bold = true;
                linhaCabecalho.Cells[0].AddParagraph("Tipo");
                linhaCabecalho.Cells[1].AddParagraph("Local/Setor");
                linhaCabecalho.Cells[2].AddParagraph("Descrição");
                linhaCabecalho.Cells[3].AddParagraph("Prazo");
                linhaCabecalho.Cells[4].AddParagraph("Situação");

                foreach (var item in pendencias)
                {
                    var linha = tabela.AddRow();
                    linha.Cells[0].AddParagraph(item.Origem);
                    linha.Cells[1].AddParagraph(item.LocalOuSetor);
                    linha.Cells[2].AddParagraph(item.Descricao);
                    linha.Cells[3].AddParagraph(item.Prazo.ToString("dd/MM/yyyy"));
                    linha.Cells[4].AddParagraph(item.SituacaoTexto);

                    Color corLinha = item.DiasRestantes < 0 ? CorVermelho
                        : item.DiasRestantes <= 3 ? CorLaranja
                        : CorVerde;


                    for (int indiceCelula = 0; indiceCelula < linha.Cells.Count; indiceCelula++)
                    {
                        Cell celula = linha.Cells[indiceCelula];
                        celula.Format.Font.Color = corLinha;
                        celula.Format.Font.Size = 9;
                        celula.VerticalAlignment = VerticalAlignment.Center;
                    }
                }
            }

            var renderizador = new PdfDocumentRenderer { Document = documento };
            renderizador.RenderDocument();

            string pastaRelatorios = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "GuardiaoCincoS", "Relatorios");
            Directory.CreateDirectory(pastaRelatorios);

            string nomeArquivo = $"Pendencias_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string caminhoCompleto = Path.Combine(pastaRelatorios, nomeArquivo);

            renderizador.PdfDocument.Save(caminhoCompleto);

            return caminhoCompleto;
        }

        public static void AbrirArquivo(string caminhoArquivo)
        {
            var processo = new ProcessStartInfo(caminhoArquivo) { UseShellExecute = true };
            Process.Start(processo);
        }
    }
}