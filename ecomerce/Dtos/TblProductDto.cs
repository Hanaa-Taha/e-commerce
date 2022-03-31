using ecomerce.Model;
using System;
using System.Collections.Generic;

namespace ecomerce.Dtos
{
    public class TblProductDto
    {
        public TblProductDto()
        {
            TblCarts = new HashSet<TblCart>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        //public string VendorId { get; set; }

        public int? CategoryId { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public bool? IsFeatured { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }

       // public virtual AppUser Vendor { get; set; }

        public virtual TblCategory Category { get; set; }
        public virtual ICollection<TblCart> TblCarts { get; set; }
    }
}