using Domain.entities;

namespace Application.Commons.Repositories
{
    public interface IUsuarioRepository
    {
        Task CadastrarAsync(Usuario usuario, CancellationToken cancellationToken);
        Task<Usuario?> ProcurarPorEmailAsync(string email, CancellationToken cancellationToken);
        Task<Usuario> ObterPorIdAsync(Guid usuarioId, CancellationToken cancellationToken);
        Task<Usuario[]> ListarAsync();
    }
}
