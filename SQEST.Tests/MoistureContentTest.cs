using Application.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace SQEST.Tests
{
    public class MoistureContentTest
    {
        public static IEnumerable<object[]> CaculateMaterialMass_ThrowException_Data =>
         new List<object[]>
         {
              //tareAndMaterialMass, tareMass

                new object[] { -1, 300.0 },  // tareAndMateriaWetMass < 0
                new object[] { 0, 300.0 },   // tareAndMateriaWetMass = 0
                new object[] { 4000.0, -1},  // tareMass < 0
                new object[] { 4000.0, 0},   // tareMass = 0
                new object[] { 300, 4000}    // tareMass >= tareAndMaterialMass              
         };

        public static IEnumerable<object[]> CaculateWaterContent_ThrowException_Data =>
         new List<object[]>
         {
             //tareAndMateriaWetMass, tareAndMateriaDryMass, tareMass

               new object[] { -1, 2525.7, 300.0},       // tareAndMateriaWetMass < 0
               new object[] { 0, 2525.7, 300.0},        // tareAndMateriaWetMass = 0
               new object[] { 2859.6, -1, 300.0},       // tareAndMateriaDryMass < 0
               new object[] { 2859.6, 0, 300.0},        // tareAndMateriaDryMass = 0
               new object[] { 2859.6, 2525.7, -1},      // tareMass < 0
               new object[] { 2859.6, 2525.7, 0},       // tareMass = 0
               new object[] { 2859.6, 2525.7, 2859.6},  // tareMass = tareAndMateriaWetMass
               new object[] { 2859.6, 2525.7, 3000.0},  // tareMass > tareAndMateriaWetMass
               new object[] { 2859.6, 2525.7, 2525.7},  // tareMass = tareAndMateriaDryMass
               new object[] { 2859.6, 2525.7, 3000.0},  // tareMass > tareAndMateriaDryMass
               new object[] { 2859.6, 2859.6, 300.0},   // tareAndMateriaDryMass = tareAndMateriaWetMass
               new object[] { 2859.6, 3000.0, 300.0},   // tareAndMateriaDryMass > tareAndMateriaWetMass                            
         };

        [Theory]
        [InlineData(4000, 300, 3700.0)]
        [InlineData(4000.46, 300, 3700.5)] //expectedValue round up from 3700.46
        [InlineData(4000.44, 300, 3700.4)] //expectedValue round down from 3700.44
        [InlineData(2859.6, 300.0, 2559.6)]
        public void CaculateMaterialMass(double tareAndMaterialMass, double tareMass, double expectedValue)
        {
            var result = MoistureContentCalculator.CaculateMaterialMass(tareAndMaterialMass, tareMass);
            Assert.Equal(expectedValue, result,1);
        }

        [Theory]
        [InlineData(4000, 3260, 300, 25.0)]
        [InlineData(4000, 3200, 300, 27.6)] //expectedValue round up from 27.59
        [InlineData(4000, 3000, 300, 37.0)] //expectedValue round down from 37.04
        [InlineData(2859.6, 2525.7, 300.0, 15.0)]
        public void CaculateWaterContent(double tareAndMateriaWetMass, double tareAndMateriaDryMass, double tareMass, double expectedValue)
        {
            var result = MoistureContentCalculator.CaculateWaterContent(tareAndMateriaWetMass,tareAndMateriaDryMass, tareMass);
            Assert.Equal(expectedValue, result,1);
        }

        [Theory]
        [MemberData(nameof(CaculateMaterialMass_ThrowException_Data))]
        public void CaculateMaterialMass_ThrowExceptions(double tareAndMaterialMass, double tareMass)
        {       
            Assert.Throws<ArgumentException>(() => MoistureContentCalculator.CaculateMaterialMass(tareAndMaterialMass, tareMass));          
        }

        [Theory]
        [MemberData(nameof(CaculateWaterContent_ThrowException_Data))]
        public void CaculateWaterContent_ThrownExceptions(double tareAndMateriaWetMass, double tareAndMateriaDryMass, double tareMass)
        {
            Assert.Throws<ArgumentException>(() => MoistureContentCalculator.CaculateWaterContent(tareAndMateriaWetMass, tareAndMateriaDryMass, tareMass));
        }


    }
}
