namespace MVCGroentenEnFruit.Models.Data
{
    public class AankoopOrder
    {
        public int AankoopOrderId { get; set; }
        public int ArtikelId { get; set; }        
        public int Hoeveelheid { get; set; }
        public Artikel? Artikel { get; set; }
        
    }
}
