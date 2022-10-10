using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using WebAppMvcClientLocation_oefening4.Data;

namespace WebAppMvcClientLocation_oefening4.Models
{
    public class Client
    {
        [Required(ErrorMessage = "ClientId is verplicht*")]
        public int? ClientId { get; set; }   
        
        public string? ClientName { get; set; }
        public int? LocationId { get; set; }

       

        public Client(int clientId, string clientName, int locationId)
        {
            ClientId = clientId;
            ClientName = clientName ?? throw new ArgumentNullException(nameof(clientName));
            LocationId = locationId;
        }

        public Client()
        {

        }
        
    }
}
