
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Services
{
    public interface IMailingService
    {

        Task SendEmailAsync(string mailTo, string subject, string body);
    }
}
