using System;

namespace GuardiaoCincoS.Modelos
{
    public class MaterialEstudo
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string CaminhoOuLink { get; set; } = string.Empty;
        public DateTime DataPublicacao { get; set; }
        public bool Ativo { get; set; } = true;
    }
}