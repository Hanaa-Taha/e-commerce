using ecomerce.Dtos;
using ecomerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        private readonly IMailingService _mailingService;
        public class emptyStr { }
        emptyStr emptyString = new emptyStr { };
        public MailingController(IMailingService mailingService)
        {
            _mailingService = mailingService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromBody] MailRequestDto dto)
        {
            await _mailingService.SendEmailAsync("agrigradproject2022@gmail.com", dto.Subject, dto.Body);
            return Ok(emptyString);
        }
    }
}

