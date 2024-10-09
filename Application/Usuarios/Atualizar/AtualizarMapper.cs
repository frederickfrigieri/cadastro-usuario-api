using AutoMapper;
using Domain.Dtos;
using Domain.entities;

namespace Application.Usuarios.Atualizar
{
    public class CadastrarMapper : Profile
    {
        public CadastrarMapper()
        {
            CreateMap<AtualizarRequest, AtualizarCommand>();
            CreateMap<AtualizarCommand, UsuarioDto>();
            CreateMap<Usuario, AtualizarResponse>();
        }
    }
}
