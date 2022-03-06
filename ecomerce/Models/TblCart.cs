using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ecomerce.Models
{
    
    public partial class TblCart
    {
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public string? MemberId { get; set; }
        public int? CartStatusId { get; set; }
        [ForeignKey("CartStatusId")]
        public virtual TblCartStatus CartStatus { get; set; }

        [ForeignKey("MemberId")]
        public virtual IdentityUser  Member { get; set; }
        [ForeignKey("ProductId")]
        public virtual TblProduct Product { get; set; }
    }
}
