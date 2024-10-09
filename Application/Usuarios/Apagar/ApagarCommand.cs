using MediatR;

namespace Application.Usuarios.Apagar
{
    public class ApagarCommand : IRequest<ApagarResponse>
    {
        public Guid UsuarioId { get; set; }
    }
}
