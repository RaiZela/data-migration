namespace technicians_domain.Abstractions;

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