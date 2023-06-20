using System.ComponentModel.DataAnnotations;

namespace Reservation_Management.Models
{
 
    public class MenuWithQuantity
    {
   
        
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
    }
}
