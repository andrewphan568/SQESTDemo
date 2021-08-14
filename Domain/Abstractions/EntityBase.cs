using System;

namespace Domain.Abstractions
{
    public interface IEntityBase
    {
        DateTime CreatedAtUtc { get; set; }
        DateTime UpdatedAtUtc { get; set; }
       // User CreatedBy { get; set; }
       // User UpdatedBy { get; set; }
    }
}
