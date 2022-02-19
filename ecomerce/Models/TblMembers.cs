using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ecomerce.Models
{
    public partial class TblMembers
    {
        public TblMembers()
        {
            TblCart = new HashSet<TblCart>();
            TblIotUsers = new HashSet<TblIotUsers>();
            TblShippingDetails = new HashSet<TblShippingDetails>();
        }

        public int MemberId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? GroupAdmin { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<TblCart> TblCart { get; set; }
        public virtual ICollection<TblIotUsers> TblIotUsers { get; set; }
        public virtual ICollection<TblShippingDetails> TblShippingDetails { get; set; }
    }
}
