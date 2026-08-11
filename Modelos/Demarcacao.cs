using System;

namespace GuardiaoCincoS.Modelos
{
    public class Demarcacao
    {
        public int Id { get; set; }
        public string Local { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataIdentificacao { get; set; }
        public DateTime DataPrevista { get; set; }
        public int IdColaboradorResponsavel { get; set; }
        public string NomeResponsavel { get; set; } = string.Empty;
        public string Status { get; set; } = "Pendente";
        public DateTime? DataConclusao { get; set; }
        public string ObservacoesConclusao { get; set; } = string.Empty;
    }
}