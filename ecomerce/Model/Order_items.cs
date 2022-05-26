using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class Order_items
    {


        [Key]
        public int orderItemsId { get; set; }
        public int orderDetailsId { get; set; }
        public int productId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual Order_details OrderDetails { get; set; }
        public virtual TblProduct TblProduct { get; set; }


    }
}
