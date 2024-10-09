using AutoMapper;
using Domain.entities;

namespace Application.Usuarios.Listar
{
    public class ListarMapper : Profile
    {
        public ListarMapper()
        {
            CreateMap<Usuario, ListarResponse>()
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.CreatedAt.ToString("dd/MM/yyyy HH:mm")));
        }
    }
}
