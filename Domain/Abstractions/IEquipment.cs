using System;

namespace Domain.Abstractions
{
    public interface IEquipment
    {
        string Name { get; set; }
        string Code { get; set; }
        DateTime ManufactureDate { get; set; }
        DateTime CreatedAtUtc { get; set; }
        DateTime UpdatedAtUtc { get; set; }
/*        AppUser CreatedBy { get; set; }
        AppUser UpdatedBy { get; set; }*/
    }
}
