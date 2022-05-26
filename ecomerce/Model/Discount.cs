using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class Discount
    {
        public Discount()
        {
            TblProducts = new HashSet<TblProduct>();
        }
        public int DiscountId { get; set; }
        public int DiscountPercnt { get; set; }
        public virtual ICollection<TblProduct> TblProducts { get; set; }

    }
}
