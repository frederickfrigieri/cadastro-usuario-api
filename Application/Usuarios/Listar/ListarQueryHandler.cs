using Application.Commons.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Usuarios.Listar
{
    public class ListarQueryHandler(IUsuarioRepository usuarioRepository, IMapper mapper) : IRequestHandler<ListarQuery, ListarResponse[]>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ListarResponse[]> Handle(ListarQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.ListarAsync();

            var response = _mapper.Map<ListarResponse[]>(usuarios);

            return response;
        }
    }
}
