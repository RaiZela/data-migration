using clients_domain.Models;
using Microsoft.EntityFrameworkCore;

namespace clients_application.Data.Intefaces;

public interface IApplicationDbContext
{
    DbSet<Client> Clients { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
