namespace Cabify.Storefront.Models
{
    public class CartViewModel
    {
        public CartItemViewModel[] Items { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
    }
}
