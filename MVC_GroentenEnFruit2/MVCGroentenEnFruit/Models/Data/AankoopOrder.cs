using Microsoft.AspNetCore.Identity;

namespace MVCGroentenEnFruit.Models.Data
{
    public class AankoopOrder
    {
        public int AankoopOrderId { get; set; }
        public int ArtikelId { get; set; }        
        public int Hoeveelheid { get; set; }
        public string? IdentityUserId { get; set; }
        public Artikel? Artikel { get; set; }
        public IdentityUser? IdentityUser { get; set; }
        

    }
}
