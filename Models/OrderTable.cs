using System.ComponentModel.DataAnnotations;

namespace Reservation_Management.Models
{
    public class OrderTable
    {
        [Key]
        public int TableId { get; set; }

        public bool IsBooked { get; set; }

    }
}
