using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ecomerce.Models
{
    public partial class TblIotUsers
    {
        public int IotId { get; set; }
        public string? MembersId { get; set; }
        public string SerialNumber { get; set; }
        public bool? IsActive { get; set; }
        [ForeignKey("MemberId")]
        public virtual IdentityUser Members { get; set; }
    }
}
