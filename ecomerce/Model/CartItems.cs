using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class CartItems
    {

        public int cartItemsId { get; set; }
        public string userId { get; set; }
        public int TblProductProductId { get; set; }
        public int Quantity { get; set; }
        public virtual TblCart TblCart { get; set; }
        public virtual TblProduct TblProduct { get; set; }
    }
}
