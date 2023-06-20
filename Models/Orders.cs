
using System.ComponentModel.DataAnnotations;

namespace Reservation_Management.Models
{
    public class Orders
    {

        [Key]
            public int OrderID { get; set; } // Primary key
            public int TableNumber { get; set; }

            public string CustomerName { get; set; }
            public string CustomerNumber { get; set; }
            public DateTime OrderDate { get; set; }
            public Boolean Status { get; set; }
           
     

    }
}
