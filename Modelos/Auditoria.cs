using System;

namespace GuardiaoCincoS.Modelos
{
    public class Auditoria
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Setor { get; set; } = string.Empty;
        public int IdColaboradorAuditor { get; set; }
        public string NomeAuditor { get; set; } = string.Empty;
        public int? IdColaboradorAcompanhante { get; set; }
        public string NomeAcompanhante { get; set; } = string.Empty;
        public decimal PontuacaoTotal { get; set; }
        public string ObservacoesGerais { get; set; } = string.Empty;
        public DateTime DataHoraRegistro { get; set; }
    }
}