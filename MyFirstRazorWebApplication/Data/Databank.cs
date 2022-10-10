namespace MyFirstRazorWebApplication.Data
{
    public class Databank
    {
        public static List<Klant> klanten = new List<Klant>();
        public static List<Location> locaties = new List<Location>();

        public static void StartDataBank()
        {
            klanten.Clear();
            klanten.Add(new Klant(1, "Klant A",1));
            klanten.Add(new Klant(2, "Klant B",2));

            locaties.Clear();
            locaties.Add(new Location(1,3500,"Hasselt"));
            locaties.Add(new Location(2,3600,"Genk"));
        }

        public static void AddLocation(int postcode,string city)
        {
            int id = locaties.Max(x => x.LocationID) + 1;
            locaties.Add(new Location() { 
                LocationID = id, 
                City = city, 
                PostCode = postcode });
        }

        public static void AddClient(string klantnaam,string locatieid)
        {
            int id = klanten.Max(x => x.KlantId) + 1;
            
            klanten.Add(new Klant()
            {
                KlantId = id,
                KlantNaam = klantnaam, 
                LocatieId = int.Parse(locatieid) 
            });
        }
    }

    
}
