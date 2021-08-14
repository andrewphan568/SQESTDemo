using System;

namespace Domain.Abstractions
{
    public class EntityBase : IEntityBase
    {
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;    
        public DateTime UpdatedAtUtc { get; set; }
        /*public AppUser CreatedBy { get; set; }
        public AppUser UpdatedBy { get; set; }*/
    }
}
