using System;

namespace GuardiaoCincoS.Modelos
{
    public class Onboarding
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public string NomeColaborador { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public string Status { get; set; } = "Em Andamento";
        public DateTime? DataConclusao { get; set; }
        public string Observacoes { get; set; } = string.Empty;
    }
}