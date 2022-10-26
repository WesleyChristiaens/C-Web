using MVCTagHelper.Data;
using MVCTagHelper.Models;

namespace MVCTagHelper.ViewModels
{
    public class MedeWerkerCard
    {
        public MedeWerkerCard(Medewerker medewerker)
        {
            Medewerker = medewerker;
            MedeWerkerId = medewerker.MedeWerkerId;
            MedeWerkerNaam = medewerker.Naam;
            AfdelingNaam = medewerker.afdeling.AfdelingNaam;
            
        }


        public Medewerker Medewerker { get; }
        public int MedeWerkerId { get; set; }
        public string MedeWerkerNaam { get; set; }
        public string AfdelingNaam { get; set; }


       


    }
}
