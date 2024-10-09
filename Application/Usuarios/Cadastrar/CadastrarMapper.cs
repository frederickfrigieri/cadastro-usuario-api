using AutoMapper;
using Domain.Dtos;
using Domain.entities;

namespace Application.Usuarios.Cadastrar
{
    public class CadastrarMapper : Profile
    {
        public CadastrarMapper()
        {
            CreateMap<CadastrarRequest, CadastrarCommand>();
            CreateMap<CadastrarCommand, UsuarioDto>();
            CreateMap<Usuario, CadastrarResponse>();
        }
    }
}
