using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class CheckoutAllModels
    {
        //public int PaymentspaymentDetailsId { get; set; }
        public List<ProductList> productLists { get; set; }
        public int total { get; set; }
        public string userId { get; set; }
    }
}
