using MediatR;

namespace Application.Usuarios.Atualizar
{
    public class AtualizarCommand : IRequest<AtualizarResponse>
    {
        public required Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Email { get; set; }
    }
}
