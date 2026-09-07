using System;

namespace GuardiaoCincoS.Modelos
{
    public class ItemPendencia
    {
        public int Id { get; set; }
        public string Origem { get; set; } = string.Empty;
        public string LocalOuSetor { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime Prazo { get; set; }

        public int DiasRestantes => (Prazo.Date - DateTime.Today).Days;

        public string SituacaoTexto
        {
            get
            {
                if (DiasRestantes < 0) return $"Atrasado há {Math.Abs(DiasRestantes)} dia(s)";
                if (DiasRestantes == 0) return "Vence hoje";
                return $"Vence em {DiasRestantes} dia(s)";
            }
        }
    }
}