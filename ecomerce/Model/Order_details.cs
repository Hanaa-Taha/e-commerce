using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class Order_details
    {
        public Order_details()
        {


            OrderItems = new HashSet<Order_items>();
        }
        [Key]
        public int orderDetailsId { get; set; }
        public int checkoutInfoId { get; set; }
        public decimal total { get; set; }
        public int PaymentspaymentDetailsId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }


        public virtual payment_details Payments { get; set; }
        public virtual CheckoutInfo checkoutInfo { get; set; }
        public virtual ICollection<Order_items> OrderItems { get; set; }

    }
}
