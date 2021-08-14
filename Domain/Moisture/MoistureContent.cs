using Domain.Abstractions;
using System;

namespace Domain.Moisture
{
    public class MoistureContent : IEntityBase
    {
        public Guid Id { get; set; }
        public string TareId { get; set; }
        public double TareMass { get; set; }
        public double TareAndMaterialWetMass { get; set; }

        public string Balance { get; set; }
        public double TareAndMaterialDryMass { get; set; }
        public double MaterialDryMass { get; set; }

        public double WaterContent { get; set; }
        public bool SelectInsufficientSampleMass { get; set; }
        public bool SelectDryingTemperature { get; set; }
        public bool SelectMaterialExcluded { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAtUtc { get; set; }
    }
}
