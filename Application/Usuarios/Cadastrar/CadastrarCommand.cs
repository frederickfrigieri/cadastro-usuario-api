using MediatR;

namespace Application.Usuarios.Cadastrar
{
    public class CadastrarCommand : IRequest<CadastrarResponse>
    {
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string ConfirmarSenha { get; set; }
    }
}
