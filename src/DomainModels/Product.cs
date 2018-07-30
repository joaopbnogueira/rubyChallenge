namespace Cabify.DomainModels
{
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal? PromoPrice { get; set; }
    }
}
