namespace GuardiaoCincoS.Modelos
{
    public class ItemAuditoria
    {
        public int Id { get; set; }
        public int IdAuditoria { get; set; }
        public string Senso { get; set; } = string.Empty;
        public int Nota { get; set; }
        public string Observacao { get; set; } = string.Empty;
    }
}