using MVCVoertuig.Models.Data;
namespace MVCVoertuig.Data.DefaultData
{
    public static class SeedData
    {
        public static void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<VoertuigDbContext>();
                if (!context.Voertuigen.Any())
                {
                    foreach (var voertuig in GetVoertuigen())
                    {
                        context.Voertuigen.Add(voertuig);
                    }
                    context.SaveChanges();
                }
            }
        }
        private static Voertuig[] GetVoertuigen()
        {
            var voertuigen = new Voertuig[5];
            voertuigen[0] = new Voertuig
            {
                Merk = "BMW",
                MerkType = "116d",
                VerkoopPrijs = 10000,
                Bouwjaar = 2020,
                Km = 19000
            };
            voertuigen[1] = new Voertuig
            {
                Merk = "BMW",
                MerkType = "220i",
                VerkoopPrijs = 11000,
                Bouwjaar = 2019,
                Km = 20000
            };
            voertuigen[2] = new Voertuig
            {
                Merk = "AUDI",
                MerkType = "A3",
                VerkoopPrijs = 12000,
                Bouwjaar = 2018,
                Km = 21000
            };
            voertuigen[3] = new Voertuig
            {
                Merk = "AUDI",
                MerkType = "A4",
                VerkoopPrijs = 13000,
                Bouwjaar = 2017,
                Km = 22000
            };
            voertuigen[4] = new Voertuig
            {
                Merk = "PORSCHE",
                MerkType = "PANAMERA",
                VerkoopPrijs = 25000,
                Bouwjaar = 2011,
                Km = 99000
            };
            return voertuigen;
        }
    }
}
