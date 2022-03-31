using ecomerce.Model;
using System;
using System.Collections.Generic;

namespace ecomerce.Dtos
{
    public class TblCategoryDto
    {
        public TblCategoryDto()
        {
            TblProducts = new HashSet<TblProduct>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsDelete { get; set; }

        public virtual ICollection<TblProduct> TblProducts { get; set; }
    }
}