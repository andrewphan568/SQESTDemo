using Domain.Abstractions;
using System;

namespace Domain
{
    public class OvenEquipment : IEquipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public AppUser CreatedBy { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public AppUser UpdatedBy { get; set; }
    }
}
