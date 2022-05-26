using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class checkInfoWithCart
    {
        public List<TblCart> carts { get; set; }
        public CheckoutInfo checkoutInfo { get; set; }
    }
}
