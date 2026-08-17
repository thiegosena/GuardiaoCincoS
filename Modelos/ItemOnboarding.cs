using System;

namespace GuardiaoCincoS.Modelos
{
    public class ItemOnboarding
    {
        public int Id { get; set; }
        public int IdOnboarding { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public bool Concluido { get; set; }
        public DateTime? DataConclusaoItem { get; set; }
    }
}