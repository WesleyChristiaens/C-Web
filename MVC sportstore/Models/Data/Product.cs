using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_sportstore.Models.Data
{
    public class Product
    {
        public long? ProductId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? Price { get; set; }

        [Required]
        public string? Category { get; set; }

        // Get property voor de prijs, omdat deze nullable is, indien null wordt 0 ingegeven in de tabel en anders de prijs.
        public decimal ProductPrice => 
            (Price == null) ? 0 : (decimal)Price;

        public Product()
        {
        }

        public Product(string[] data)
        {
            Name = data[0];
            Description = data[1];
            Category = data[2];
            Price = decimal.Parse(data[3]);

        }

    }
}
