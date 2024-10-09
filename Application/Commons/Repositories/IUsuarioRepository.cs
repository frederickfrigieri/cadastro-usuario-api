using Application.Usuarios.Cadastrar;
using Domain.entities;

namespace Application.Commons.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> CadastrarAsync(Usuario usuario, CancellationToken cancellationToken);
        Task<Usuario?> GetAsync(string email, CancellationToken cancellationToken);
    }
}
