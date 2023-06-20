using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Reservation_Management.Models.Orders;

namespace Reservation_Management.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; } // Primary key

        public string ItemName { get; set; } // Foreign key for MenuItem model
        public decimal Price { get; set; } // Foreign key for Order model

        public int Quantity { get; set; }
        public int TableId { get; set; }
    }

}
