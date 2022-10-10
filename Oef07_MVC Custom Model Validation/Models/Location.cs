using Oef07_MVC_Custom_Model_Validation.CustomModelValidation;

namespace Oef07_MVC_Custom_Model_Validation.Models
{
    public class Location
    {

        public int? LocationId { get; set; }

        [CustomPostCode]
        public int? PostCode { get; set; }
    }
}
