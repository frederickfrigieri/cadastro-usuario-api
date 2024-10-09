namespace Application.Usuarios.Listar
{
    public class ListarResponse
    {
        public required string Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Email { get; set; }
        public required string DataCadastro { get; set; }
    }
}
