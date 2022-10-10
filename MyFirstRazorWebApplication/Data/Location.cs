namespace MyFirstRazorWebApplication.Data
{
    public class Location
    {
        public int LocationID { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }

        public Location()
        {
              
        }

        public Location(int locationID, int postCode, string city)
        {
            LocationID = locationID;
            PostCode = postCode;
            City = city;
        }

        
    }
}
