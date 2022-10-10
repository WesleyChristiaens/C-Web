using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using MVCModelValidation.CustomModelValidation;


namespace MVCModelValidation.Models
{
    public class TestData
    {
        public int? TekstDataId { get; set; }
        [Required]
        [StringLength(10)]
        public string? Tekst { get; set; }
        [CustomDate]
        public DateTime? Datum { get; set; }       

    }
}
