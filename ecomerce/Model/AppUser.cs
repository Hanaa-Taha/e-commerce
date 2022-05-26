using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
           
            TblCarts = new HashSet<TblCart>();
            TblIotUsers = new HashSet<TblIotUsers>();
            TblShippingDetails = new HashSet<TblShippingDetails>();
            TblProducts = new HashSet<TblProduct>();
            checkoutInfo = new HashSet<CheckoutInfo>();
            resetPassword = new HashSet<ResetPassword>();

        }
        public bool hasIotSystem { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string profileImage { get; set; }
        public virtual ICollection<TblProduct> TblProducts { get; set; }
        public virtual ICollection<TblCart> TblCarts { get; set; }
        public virtual ICollection<TblIotUsers> TblIotUsers { get; set; }
        public virtual ICollection<TblShippingDetails> TblShippingDetails { get; set; }
        public virtual ICollection<CheckoutInfo> checkoutInfo  { get; set; }

        public virtual ICollection<ResetPassword> resetPassword { get; set; }

    }
}
