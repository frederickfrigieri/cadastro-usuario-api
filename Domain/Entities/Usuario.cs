using Domain.Commons;
using Domain.Dtos;

namespace Domain.entities
{
    public class Usuario : EntityBase
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        protected Usuario() { }

        internal Usuario(UsuarioDto dto)
        {
            Nome = dto.Nome;
            Sobrenome = dto.Sobrenome;
            Email = dto.Email;
            Senha = dto.Senha;
        }

        public static Usuario Criar(UsuarioDto dto)
        {
            return new Usuario(dto);
        }

        public Usuario Atualizar(UsuarioDto dto)
        {
            Nome = dto.Nome;
            Sobrenome = dto.Sobrenome;
            Senha = dto.Senha;
            UpdatedAt = DateTime.Now;

            return this;
        }

        public void Deletar()
        {
            Deactivate();
        }
    }

    
}
