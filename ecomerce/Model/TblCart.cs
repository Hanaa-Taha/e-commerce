using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class TblCart
    {

        public TblCart()
        {

            CartItems = new HashSet<CartItems>();
        }
        
        //public int ProductId { get; set; }
        public string MemberId { get; set; }
        public int? CartStatusId { get; set; }
        //public int? Quantity { get; set; }

        public virtual TblCartStatus CartStatus { get; set; }
        public virtual AppUser Member { get; set; }
        //public virtual TblProduct Product { get; set; }
        public virtual ICollection<CartItems> CartItems { get; set; }
    }
}
