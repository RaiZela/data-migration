using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_order_domain.Models;

namespace work_order_application.Data.Interfaces;

public interface IApplicationDbContext
{
    DbSet<WorkOrder> WorkOrders { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
