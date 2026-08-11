using System;
using System.Collections.Generic;
using System.Text;

namespace GuardiaoCincoS.Modelos
{
    public class Ronda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int IdColaboradorResponsavel { get; set; }
        public string NomeColaboradorResponsavel { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Observacoes { get; set; } = string.Empty;
        public DateTime? DataHoraConclusao { get; set; }
    }
}
