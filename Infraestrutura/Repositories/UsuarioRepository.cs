using Application.Commons.Interfaces;
using Application.Commons.Repositories;
using Domain.Commons;
using Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository(IAppDbContext dbContext) : IUsuarioRepository
    {
        private readonly IAppDbContext _dbContext = dbContext;

        public async Task<Usuario> CadastrarAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            _dbContext.Usuarios.Add(usuario);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return usuario;
        }

        public async Task<Usuario[]> ListarAsync()
        {
            var usuarios = await _dbContext.Usuarios.ToArrayAsync();

            return usuarios;
        }

        public async Task<Usuario?> ProcurarPorEmailAsync(string email, CancellationToken cancellationToken)
        {
            var usuario = await _dbContext.Usuarios.SingleOrDefaultAsync(x => x.Email == email, cancellationToken);

            return usuario;
        }

        public async Task<Usuario> ObterPorIdAsync(Guid usuarioId, CancellationToken cancellationToken)
        {
            var usuario = await _dbContext.Usuarios.SingleOrDefaultAsync(x => x.Id == usuarioId, cancellationToken) ?? throw new DomainException("Usuário não encontrado");

            return usuario;
        }
    }
}
