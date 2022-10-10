using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace MVCPartyInvites.Models
{
    public class Gast
    {
        [Required]
        public string Naam { get; set; }

        
        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        [Phone]
        [Required(ErrorMessage ="Vul je tel.nr. in!")]        
        public string? Telefoon { get; set; }

        
        [Required(ErrorMessage ="Laat weten of je aanwezig zal zijn!")]        
        public bool? Aanwezig { get; set; }

        
        // [Required] bevat een standaard error message, indien je deze wil personaliseren
        // gebruik dan [Required(ErrorMessage ="...")
         



    }
}
