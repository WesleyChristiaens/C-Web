namespace WebAppMvcClientLocation_oefening4.Models
{
    public class ClientLocation
    {
        public string ClientName { get; set; }
        public string City { get; set; }

        public IEnumerable<ClientLocation> Overview()
        {
          var clientlocations = from k in Data.Database.Clients
                                  join l in Data.Database.Locations
                                  on k.LocationId equals l.LocationId
                                  select new ClientLocation{
                                      City = l.City,
                                      ClientName=k.ClientName
                                  };

            return clientlocations;
        }
    }
}
