using Domain.Dtos;
using Domain.entities;

namespace Application.UnitTest.FakeData
{
    public class Usuarios
    {
        public static Usuario ObterUsuario(UsuarioDto usuarioDto)
        {
            return Usuario.Criar(usuarioDto);
        }

        public static UsuarioDto ObterUsuarioDtoA()
        {
            return  new UsuarioDto
            {
                Email = "zeroberto@test.com",
                Nome = "Zé",
                Sobrenome = "Roberto",
                Senha = "123456"
            };
        }

        public static UsuarioDto ObterUsuarioB()
        {
            return new UsuarioDto
            {
                Email = "renato@test.com",
                Nome = "Renato",
                Sobrenome = "Chain",
                Senha = "123456"
            };
        }
    }
}
