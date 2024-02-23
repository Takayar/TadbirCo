using System;
using System.Collections.Generic;

namespace Tadbir.MMP.Models.Entities
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        public string RequestSubject { get; set; } //عنوان
       
        public double NetInsurancePremium { get; set; } //حق بیمه خالص
        public DateTime InsertTime { get; set; } 
        public bool IsRemoved { get; set; }
        public List<ReqDetails> ReqDetails { get; set; }
    }

    public class ReqDetails
    {
        public int Id { get; set; }
        public int ToDoId { get; set; }
        public int InsuranceTypeId { get; set; }
        public int RequestInsuranceCoverage { get; set; } //پوشش درخواستی کاربر
        public double NetInsurancePremiumItem { get; set; } //حق بیمه خالص

    }
    public class InsuranceType
    {
        public int InsuranceTypeId { get; set; }
        public string Name { get; set; } //عنوان پوشش
        public int MinInsuranceCoverage { get; set; } //حداقل پوشش
        public int MaxInsuranceCoverage { get; set; }//حداکثر پوشش
        public double InsuranceRate { get; set; } //نرخ پوشش
    }

}
