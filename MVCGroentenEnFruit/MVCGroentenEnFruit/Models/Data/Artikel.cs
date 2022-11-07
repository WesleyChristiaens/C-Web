namespace MVCGroentenEnFruit.Models.Data
{
    public class Artikel
    {
        public int ArtikelId { get; set; }
        public string? Naam { get; set; }
        public ICollection<AankoopOrder>? AankoopOrders { get; set; }
        public ICollection<VerkoopOrder>? VerkoopOrders { get; set; }

    }
}
