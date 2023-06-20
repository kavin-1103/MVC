using System.ComponentModel.DataAnnotations;

namespace Reservation_Management.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuID { get; set; } // Primary key
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
