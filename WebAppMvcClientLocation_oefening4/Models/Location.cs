using System.ComponentModel.DataAnnotations;

namespace WebAppMvcClientLocation_oefening4.Models
{
    public class Location
    {
        [CustomId]
        public int LocationId { get; set; }

        [Required]
        public string PostCode  { get; set; }

        [Required]
        public string City  { get; set; }


        public Location()
        {

        }

    }
}
