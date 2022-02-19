using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ecomerce.Models
{
    public partial class TblCart
    {
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public int? MemberId { get; set; }
        public int? CartStatusId { get; set; }

        public virtual TblCartStatus CartStatus { get; set; }
        public virtual TblMembers Member { get; set; }
        public virtual TblProduct Product { get; set; }
    }
}
