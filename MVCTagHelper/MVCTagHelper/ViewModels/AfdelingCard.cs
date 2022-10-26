using Microsoft.EntityFrameworkCore;
using MVCTagHelper.Data;
using MVCTagHelper.Models;

namespace MVCTagHelper.ViewModels
{
    public class AfdelingCard 
    {
        

        public AfdelingCard(Afdeling afdeling)
        {
            AfdelingId = afdeling.AfdelingId;
            AfdelingNaam = afdeling.AfdelingNaam;
            Locatie = afdeling.Locatie.Stad;
            Land = afdeling.Locatie.Land.LandNaam;
            LandCode = afdeling.Locatie.Land.LandCode;
            Afdeling = afdeling;
        }

        public Afdeling Afdeling { get; set; }
        public int AfdelingId { get; private set; }
        public string AfdelingNaam { get; private set; }
        public string Locatie { get; private set; }
        public string Land { get; private set; }
        public string LandCode { get; private set; }
    }
}
