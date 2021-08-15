using Domain.Abstractions;
using System;

namespace Domain.Moisture
{
    public class MoistureContent : EntityBase
    {
        public Guid Id { get; set; }
        public string WorksheetId { get; set; }
        public Project Project { get; set; }
        public SourceMaterial SourceMaterial { get; set; }
        public Specification Specification { get; set; }
        public Sample Sample { get; set; }
        public Preparation Preparation { get; set; }
        public StandardTestMethod StandardTestMethod { get; set; }
        public string TareId { get; set; }
        public double TareMass { get; set; }
        public double TareAndMaterialWetMass { get; set; }

        public double TareAndMaterialDryMass { get; set; }
        public double MaterialDryMass { get; set; }

        public double WaterContentPercentage { get; set; }
        public bool SelectInsufficientSampleMass { get; set; } 
        public bool SelectDryingTemperature { get; set; }
        public bool SelectMaterialExcluded { get; set; }

        public string TesterName { get; set; } // should use AppUser? or  create another Laboratory Staff table ?
        public DateTime DateTested { get; set; }
         
        public string Remarks { get; set; }
        public string CheckerName { get; set; } // should use AppUser? or  create another Laboratory Staff table ?
        public DateTime DateChecked { get; set; }


    }
}
