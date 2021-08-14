using System;

namespace Domain.Abstractions
{
    public interface IEntityBase
    {
        DateTime CreatedAtUtc { get; set; }
        DateTime UpdatedAtUtc { get; set; }
     /*   AppUser CreatedBy { get; set; }
        AppUser UpdatedBy { get; set; }*/
    }
}
