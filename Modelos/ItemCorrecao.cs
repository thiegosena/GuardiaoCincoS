using System;

namespace GuardiaoCincoS.Modelos
{
    public class ItemCorrecao
    {
        public int Id { get; set; }
        public int IdAuditoria { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataLimite { get; set; }
        public string Status { get; set; } = "Pendente";
    }
}