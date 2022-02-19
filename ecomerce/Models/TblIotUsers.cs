using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ecomerce.Models
{
    public partial class TblIotUsers
    {
        public int IotId { get; set; }
        public int? MembersId { get; set; }
        public string SerialNumber { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblMembers Members { get; set; }
    }
}
