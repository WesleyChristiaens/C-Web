using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace oef8_WebAppMVCClientLocationEFCore.Models
{
    public class Client
    {
        [Key]
        public int? ClientId { get; set; }

        public int? LocationId { get; set; }

      
        [StringLength(50,ErrorMessage = "Maximaal 50 tekens toegestaan.")]
        public string? ClientName { get; set; }

        public Client()
        {

        }
    }
}
