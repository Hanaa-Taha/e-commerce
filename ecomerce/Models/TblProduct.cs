using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ecomerce.Models
{
    public partial class TblProduct
    {
        

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? Description { get; set; }
        public string ProductImage { get; set; }
        public bool? IsFeatured { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        [ForeignKey("CategoryId")]
        public virtual TblCategory Category { get; set; }
        
        
    }
}
