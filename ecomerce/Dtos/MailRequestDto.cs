using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Dtos
{
    public class MailRequestDto
    {
        //[Required]
        //public string ToEmail { get; set; }
        //[Required]
        public string Subject { get; set; }
        //[Required]
        public string Body { get; set; }
        //public IList Attachments { get; set; }
    }
}
