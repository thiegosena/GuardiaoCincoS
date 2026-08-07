namespace GuardiaoCincoS.Modelos
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Setor { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}