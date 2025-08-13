namespace Shopping.Models.DTO_s
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; } // Formatted Date
        public decimal Amount { get; set; } // Total amount of the order
        public string CustomerName { get; set; } // Full Name of the customer
        public string CustomerEmail { get; set; }  // Email of the customer
        public string CustomerPhoneNumber { get; set; }  // Contact number
        public AddressDto Address { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
