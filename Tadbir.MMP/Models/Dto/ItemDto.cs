using System.ComponentModel.DataAnnotations;
using Tadbir.MMP.Models.Entities;

namespace Tadbir.MMP.Models.Dto
{
    public class ItemDto

    {
        [Required]
        public string RequestSubject { get; set; } //عنوان
        [Required]
        public int[] RequestInsuranceCoverage { get; set; } //پوشش درخواستی کاربر
        [Required]
        public int[] InsuranceTypes { get; set; } //حق بیمه خالص
    }
}
