using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_order_domain.Abstractions;

public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}
public interface IEntity
{
    //public DateTime? CreatedAt { get; set; }
    //public Guid CreatedByUserId { get; set; }
    //public DateTime? LastModified { get; set; }
    //public Guid LastModifiedByUserId { get; set; }
}