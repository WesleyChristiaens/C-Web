namespace MyFirstRazorWebApplication.Data
{
    public class Klant
    {
        public int KlantId { get; set; }
        public string KlantNaam { get; set; }
        public bool GevalideerdeKlant => (KlantId > -1);

        public int LocatieId { get; set; }

        public Klant()
        {
            KlantId = -1;
            KlantNaam = string.Empty;
            LocatieId = -1;
        }

        public Klant(int id, string naam)
        {
            KlantId = id;
            KlantNaam = naam;                
        }

        public Klant(int id, string naam, int locatieid)
        {
            KlantId = id;
            KlantNaam = naam;
            LocatieId = locatieid;
        }

    }
}
