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
        public string Balance { get; set; }
        public double VisualNomialPraticalSize { get; set; }
        public string MaterialExcluded { get; set; }
    }   
}
