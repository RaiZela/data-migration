using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_order_domain.Abstractions;

public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; }
    //public DateTime? CreatedAt { get; set; }
    //public Guid CreatedByUserId { get; set; }
    //public User CreatedByUser { get; set; }
    //public DateTime? LastModified { get; set; }
    //public Guid LastModifiedByUserId { get; set; }
    //public User LastModifiedByUser { get; set; }
}