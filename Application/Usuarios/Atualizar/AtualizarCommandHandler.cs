using Application.Commons.Interfaces;
using Application.Commons.Repositories;
using AutoMapper;
using Domain.Commons;
using Domain.Dtos;
using MediatR;

namespace Application.Usuarios.Atualizar
{
    public class AtualizarCommandHandler(IAppDbContext dbContext, IUsuarioRepository usuarioRepository, IMapper mapper) : IRequestHandler<AtualizarCommand, AtualizarResponse>
    {
        private readonly IAppDbContext _dbContext = dbContext;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<AtualizarResponse> Handle(AtualizarCommand request, CancellationToken cancellationToken)
        {
            var usuarioAtual = await _usuarioRepository.ObterPorIdAsync(request.Id, cancellationToken);

            if (usuarioAtual!.Email != request.Email)
            {
                var usuarioExistente = await _usuarioRepository.ProcurarPorEmailAsync(request.Email, cancellationToken);
                if (usuarioExistente != null) throw new DomainException("E-mail já cadastrado");
            }

            var usuarioDto = _mapper.Map<UsuarioDto>(request);

            usuarioAtual.Atualizar(usuarioDto);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<AtualizarResponse>(usuarioAtual);

            return response;
        }
    }
}
