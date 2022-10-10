using Microsoft.Build.Framework;
using Oef07_MVC_Custom_Model_Validation.CustomModelValidation;

namespace Oef07_MVC_Custom_Model_Validation.Models
{
    public class Client
    {

        public int? ClientId { get; set; }

        
        [CustomNoNumbers]
        public string? ClientName { get; set; }


    }
}
