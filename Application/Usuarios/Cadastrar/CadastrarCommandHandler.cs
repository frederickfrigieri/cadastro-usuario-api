using Application.Commons.Repositories;
using AutoMapper;
using Domain.Commons.Exceptions;
using Domain.Dtos;
using Domain.entities;
using MediatR;

namespace Application.Usuarios.Cadastrar
{
    public class CadastrarCommandHandler(IUsuarioRepository usuarioRepository, IMapper mapper) : IRequestHandler<CadastrarCommand, CadastrarResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CadastrarResponse> Handle(CadastrarCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ProcurarPorEmailAsync(request.Email, cancellationToken);

            if (usuario != null) throw new DomainException("Email já está sendo utilizado");

            var usuarioDto = _mapper.Map<UsuarioDto>(request);
            usuario = Usuario.Criar(usuarioDto);

            await _usuarioRepository.CadastrarAsync(usuario, cancellationToken);
            var response = _mapper.Map<CadastrarResponse>(usuario);
            
            return response;
        }
    }
}
