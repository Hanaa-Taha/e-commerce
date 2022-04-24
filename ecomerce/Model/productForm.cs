using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class productForm:TblProduct
    {
        public IFormFile file { get; set; }
        public string CategoryName { get; set; }

        
    }
}
