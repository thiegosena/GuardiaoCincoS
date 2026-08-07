namespace GuardiaoCincoS.Servicos
{
    public static class Sessao
    {
        public static int IdUsuario { get; set; }
        public static string NomeCompleto { get; set; } = string.Empty;
        public static int IdPerfil { get; set; }
        public static string NomePerfil { get; set; } = string.Empty;

        public static void Encerrar()
        {
            IdUsuario = 0;
            NomeCompleto = string.Empty;
            IdPerfil = 0;
            NomePerfil = string.Empty;
        }
    }
}