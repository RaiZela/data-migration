using Microsoft.EntityFrameworkCore;
using technicians_domain.Models;

namespace technicians_application.Data.Intefaces;

public interface IApplicationDbContext
{
    DbSet<Technician> Technicians { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
