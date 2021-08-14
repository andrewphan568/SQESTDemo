using Domain;
using Domain.Moisture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MoistureContentDto
    {
        public Guid Id { get; set; }

        public Project Project { get; set; }
        public SourceMaterial SourceMaterial { get; set; }
        public Specification Specification { get; set; }
        public Sample Sample { get; set; }
        public Preparation Preparation { get; set; }

        public string TareId { get; set; }
        public double TareMass { get; set; }
        public double TareAndMaterialWetMass { get; set; }

        public double TareAndMaterialDryMass { get; set; }
        public double MaterialDryMass { get; set; }

        public double WaterContentPercentage { get; set; }
        public bool SelectInsufficientSampleMass { get; set; }
        public bool SelectDryingTemperature { get; set; }
        public bool SelectMaterialExcluded { get; set; }

        public string TesterName { get; set; } 
        public DateTime DateTested { get; set; }

        public string Remarks { get; set; }
        public string CheckerName { get; set; } 
        public DateTime DateChecked { get; set; }
    }
}
