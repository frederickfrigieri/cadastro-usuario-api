using Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Commons.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Usuario> Usuarios { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
