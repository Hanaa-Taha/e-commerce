using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class payment_details
    {
        public payment_details()
        {

            
            OrderDetails = new HashSet<Order_details>();
        }

        [Key]
        public int paymentDetailsId { get; set; }
        
        public int amount { get; set; }
        public string provider { get; set; }
        public string status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual ICollection<Order_details> OrderDetails { get; set; }
    }
}
