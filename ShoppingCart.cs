namespace ShoppingCartList.Api
{
    public class ShoppingCart
    {
        public int Id { get; set; } 
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public bool isPickedUp { get; set; }
    }
}