namespace Basket.API.Entities
{
    public class ShopingCartItem
    {
        public int Quatity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
