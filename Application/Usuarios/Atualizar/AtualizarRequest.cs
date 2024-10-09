namespace Application.Usuarios.Atualizar
{
    public class AtualizarRequest
    {
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Email { get; set; }
    }
}
