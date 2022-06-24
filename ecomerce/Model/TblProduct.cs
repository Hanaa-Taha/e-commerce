using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class TblProduct
    {
        public TblProduct()
        {
            CartItems = new HashSet<CartItems>();
            OrderItems = new HashSet<Order_items>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string VendorId { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }

        public bool? IsFeatured { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public int? DiscountId { get; set; }
        public virtual Discount discount { get; set; }
        public virtual AppUser Vendor { get; set; }
        public virtual TblCategory Category { get; set; }
        public virtual ICollection<CartItems> CartItems { get; set; }
        public virtual ICollection<Order_items> OrderItems { get; set; }

    }
}
