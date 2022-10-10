using Microsoft.AspNetCore.Mvc;
using WebAppMvcClientLocation_oefening4.Models;


namespace WebAppMvcClientLocation_oefening4.Data
{
    public class Database
    {
       
        public static List<Client> Clients = new List<Client>();
        public static List<Location> Locations = new List<Location>();

        public static void StartDatabase()
        {     
            Clients.Add(new Client { ClientId = 1, ClientName = "Klant A", LocationId = 1 });
            Clients.Add(new Client { ClientId = 2, ClientName = "Klant B", LocationId = 2 });

            Locations.Add(new Location { LocationId = 1, PostCode = "3500", City = "Hasselt" });
            Locations.Add(new Location { LocationId = 2, PostCode = "3600", City = "Genk" });
        }

       
       public static InsertResult AddClient(Client c)
        {
            InsertResult result = new InsertResult();

            if (c.ClientId != null)
            {
                var rows = Clients.Where(x => x.ClientId == c.ClientId).Count();
                
                if (rows > 0)
                {
                    result.Errors.Add("ClientID is al in gebruik*");
                    result.succeeded = false;                    
                }
                else
                {
                    Clients.Add(c);
                    result.succeeded = true;
                }
            }
            
            
            return result;

        }

        public static InsertResult AddLocation(Location l)
        {
            InsertResult result = new InsertResult();

            if (l.LocationId != null)
            {
                var idexists = Locations.Where(x => x.LocationId == l.LocationId).Count();

                if (idexists > -1)
                {
                    result.Errors.Add("LocatieId is al in gebruik");
                    result.succeeded = false;
                }
            }
            else
            {
                result.Errors.Add("LocatieId niet ingevuld");
                result.succeeded = false;
            }


            Locations.Add(l);
            result.succeeded = true;
            return result;

        }

        

    }
}
