using System.ComponentModel.DataAnnotations;

namespace oef8_WebAppMVCClientLocationEFCore.Models
{
    public class Location
    {
        [Key]
        public int? LocationId { get; set; }

        [StringLength(15,ErrorMessage ="Maximum toegestane tekens: 15")]
        public string? PostCode { get; set; }

        [StringLength(100,ErrorMessage ="Maximum toegestane tekens: 100")]
        public string? City { get; set; }

        public Location()
        {

        }
    }
}
