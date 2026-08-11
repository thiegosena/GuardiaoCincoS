using System;

namespace GuardiaoCincoS.Modelos
{
    public class PlacaProvisoria
    {
        public int Id { get; set; }
        public int IdAuditoria { get; set; }
        public string LocalPlaca { get; set; } = string.Empty;
        public DateTime DataVencimento { get; set; }
        public string Status { get; set; } = "Pendente";
    }
}