namespace MVC_sportstore.Data
{
    public class DefaultData
    {
        public static IEnumerable<string> Products => GetProductList();

        private static IEnumerable<string> GetProductList()
        {
            List<string> products = new List<string>();

            products.Add("Kayak;A boat for one person;Watersports;275");
            products.Add("Lifejacket;Protective and fashionable;Watersports;48,95");
            products.Add("Soccer Ball;FIFA-approved size and weight;Soccer;19,5");
            products.Add("Corner Flags;Give your playing field a professional touch;Soccer;34,95");
            products.Add("Stadium;Flat-packed 35,000-seat stadium;Soccer;79500");
            products.Add("Thinking Cap;Improve brain efficiency by 75%;Chess;16");
            products.Add("Unsteady Chair;Secretly give your opponent a disadvantage;Chess;29,95");
            products.Add("Human Chess Board;A fun game for the family;Chess;75");
            products.Add("Bling-Bling King;Gold-plated, diamond-studded King;Chess;1200");

            return products;
        }
    }
}
