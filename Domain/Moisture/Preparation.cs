using Domain.Abstractions;
using System;

namespace Domain
{
    // temperatily generate the general object for Preparation
    public class Preparation : EntityBase
    {
        public Guid Id { get; set; }
        public string Method { get; set; }
        public double DryingTemperature { get; set; }
        public BalanceEquipment Balance { get; set; }
        public OvenEquipment Oven { get; set; }
        public string VisualNomialPraticalSize { get; set; }
        public string MaterialExcluded { get; set; }
    }
}
