using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GuardiaoCincoS.Modelos;

namespace GuardiaoCincoS.Servicos
{
    public static class WhatsAppService
    {
        public static void EnviarResumoPendencias(List<ItemPendencia> pendencias)
        {
            string mensagem = MontarMensagem(pendencias);
            AbrirComMensagem(mensagem);
        }

        private static string MontarMensagem(List<ItemPendencia> pendencias)
        {
            var construtor = new StringBuilder();
            construtor.AppendLine("*Sistema Guardião 5S - Pendências*");
            construtor.AppendLine($"Gerado em {DateTime.Now:dd/MM/yyyy HH:mm}");
            construtor.AppendLine();

            if (pendencias.Count == 0)
            {
                construtor.AppendLine("Nenhuma pendência em aberto no momento. ✅");
            }
            else
            {
                int atrasadas = pendencias.Count(p => p.DiasRestantes < 0);
                construtor.AppendLine($"Total de pendências: {pendencias.Count}");
                construtor.AppendLine($"Atrasadas: {atrasadas}");
                construtor.AppendLine();

                foreach (var item in pendencias.Take(10))
                {
                    construtor.AppendLine($"• [{item.Origem}] {item.LocalOuSetor} - {item.Descricao} ({item.SituacaoTexto})");
                }

                if (pendencias.Count > 10)
                {
                    construtor.AppendLine($"... e mais {pendencias.Count - 10} pendência(s).");
                }
            }

            return construtor.ToString();
        }

        public static void AbrirComMensagem(string mensagem)
        {
            string mensagemCodificada = Uri.EscapeDataString(mensagem);
            string url = $"https://wa.me/+16232130072?text={mensagemCodificada}";

            var processo = new ProcessStartInfo(url) { UseShellExecute = true };
            Process.Start(processo);
        }
    }
}