using Application.Commons.Interfaces;
using Application.Commons.Repositories;
using MediatR;

namespace Application.Usuarios.Apagar
{
    public class ApagarCommandHandler(IUsuarioRepository usuarioRepository, IAppDbContext dbContext) : IRequestHandler<ApagarCommand, ApagarResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IAppDbContext _dbContext = dbContext;

        public async Task<ApagarResponse> Handle(ApagarCommand request, CancellationToken cancellationToken)
        {
            var usuarioAtual = await _usuarioRepository.ObterPorIdAsync(request.UsuarioId, cancellationToken);

            usuarioAtual.Deletar();

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ApagarResponse { Deleted = true };
        }
    }
}
