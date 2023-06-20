using System.ComponentModel.DataAnnotations;

namespace Reservation_Management.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; } // Primary key
        public int TableNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public TimeSpan ReservationTime { get; set; }
    }

}
