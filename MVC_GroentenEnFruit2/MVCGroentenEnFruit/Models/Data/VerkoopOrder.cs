namespace MVCGroentenEnFruit.Models.Data
{
    public class VerkoopOrder
    {
        public int VerkoopOrderId { get; set; }
        public int ArtikelId { get; set; }        
        public int Hoeveelheid { get; set; }
        public Artikel? Artikel { get; set; }
        
    }
}
