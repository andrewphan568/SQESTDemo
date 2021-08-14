using Domain.Abstractions;
using System;

namespace Domain
{
    public class BalanceEquipment : IEquipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAtUtc { get; set; }
    }
}
}
