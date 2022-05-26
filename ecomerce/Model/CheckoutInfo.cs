using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class CheckoutInfo
    {
        public CheckoutInfo()
        {


            OrderDetails = new HashSet<Order_details>();
        }
        [Key]
        public int checkoutInfoId { get; set; }
        public string MemberId { get; set; }
        public int amount { get; set; }
        public long phone { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string district { get; set; }
        public string governorate { get; set; }
        public string specialMarque { get; set; }
        public int propertyNumber { get; set; }
        public virtual AppUser Member { get; set; }
        public virtual ICollection<Order_details> OrderDetails { get; set; }
    }
}
