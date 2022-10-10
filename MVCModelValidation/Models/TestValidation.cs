using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCModelValidation.Models
{
    public class TestValidation
    {
        [Key]
        public int? TestValidationId { get; set; }


        [Required]
        [StringLength(100)] 
        public string? FirstName { get; set; }


        [Required(ErrorMessage = "Please choose date of birth")]
        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }



        [Required(ErrorMessage ="Please enter address")]
        [StringLength(255)]
        public string? Address { get; set; }

    }
}
