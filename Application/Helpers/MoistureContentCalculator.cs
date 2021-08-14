using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class MoistureContentCalculator
    {

        /// <summary>
        /// using for caculate material wet mass Or material dry mass
        /// </summary>
        /// <param name="tareAndMaterialMass"></param>
        /// <param name="tareMass"></param>
        /// <returns>Material Mass</returns>
        public static double CaculateMaterialMass(double tareAndMaterialMass, double tareMass)
        {
            if (tareAndMaterialMass < 0 || tareMass < 0) throw new ArgumentException("Mass must be greater than 0");
            if (tareMass == 0) throw new ArgumentException("Tare mass is expected, a missing or 0 tare mass may indicate an issue with the result.");
            if (tareMass >= tareAndMaterialMass) throw new ArgumentException("Tare and material mass must be greater than tare mass");

            return tareAndMaterialMass - tareMass;
        }

        /// <summary>
        /// Caculate water content
        /// </summary>
        /// <param name="tareAndMateriaWetMass"></param>
        /// <param name="tareAndMateriaDryMass"></param>
        /// <param name="tareMass"></param>
        /// <returns>Water Content </returns>   
        public static double CaculateWaterContent(double tareAndMateriaWetMass, double tareAndMateriaDryMass, double tareMass)
        {
            if (tareAndMateriaWetMass < 0 || tareAndMateriaDryMass < 0 || tareMass < 0) throw new ArgumentException("Mass must be greater than 0");
            if (tareMass == 0) throw new ArgumentException("Tare mass is expected, a missing or 0 tare mass may indicate an issue with the result.");
            if (tareMass >= tareAndMateriaWetMass) throw new ArgumentException("Tare and wet mass must be greater than tare mass");
            if (tareMass >= tareAndMateriaWetMass) throw new ArgumentException("Tare and dry mass must be greater than tare mass");
            if (tareAndMateriaDryMass >= tareAndMateriaWetMass) throw new ArgumentException("Dry mass greater than wet mass, cannot calculate a result");

            return (tareAndMateriaWetMass - tareAndMateriaDryMass) / (tareAndMateriaDryMass - tareMass) * 100;
        }
    }
}
