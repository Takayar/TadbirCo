using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tadbir.MMP.Models.Entities;

namespace Tadbir.MMP.Seeds
{
    public class DataBaseContextSeed
    {
        public static void TypeSeed(ModelBuilder modelBuilder)
        {
            foreach (var typeInsurance in GetInsuranceTypes())
            {
                modelBuilder.Entity<InsuranceType>().HasData(typeInsurance);
            }
           
        }
        private static IEnumerable<InsuranceType> GetInsuranceTypes()
        {
            return new List<InsuranceType>()
            {
                new InsuranceType() {  InsuranceTypeId =1,Name="دندان پزشکی", MinInsuranceCoverage=4000,MaxInsuranceCoverage=400000000,InsuranceRate=0.0042},
                new InsuranceType() {  InsuranceTypeId=2,Name="جراحی", MinInsuranceCoverage=5000,MaxInsuranceCoverage=500000000,InsuranceRate=0.0052 },
                new InsuranceType() {  InsuranceTypeId=3,Name="بستری",MinInsuranceCoverage=2000,MaxInsuranceCoverage=200000000,InsuranceRate=0.005},



            };
        }
    }
}
