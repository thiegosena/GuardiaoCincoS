using System;

namespace GuardiaoCincoS.Modelos
{
    public class EventoCalendario
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Local { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int? IdColaboradorResponsavel { get; set; }
        public string NomeResponsavel { get; set; } = string.Empty;
        public string Status { get; set; } = "Agendado";
    }
}