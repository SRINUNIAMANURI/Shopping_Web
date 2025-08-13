namespace Shopping.Models.DTO_s
{
    public class OrderItemDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; } // ProductPrice * Quantity
    }
}
