using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class ProfilePic
    {
        public IFormFile file { get; set; } = null;
        //public byte [] image { get; set; }

    }
}
