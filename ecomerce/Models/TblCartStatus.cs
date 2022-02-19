using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ecomerce.Models
{
    public partial class TblCartStatus
    {
        public TblCartStatus()
        {
            TblCart = new HashSet<TblCart>();
        }

        public int CartStatusId { get; set; }
        public string CartStatus { get; set; }

        public virtual ICollection<TblCart> TblCart { get; set; }
    }
}
