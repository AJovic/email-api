using EmailApp.Models;
using EmailApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;

        public EmailsController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmails()
        {
            try
            {
                var emails = await _emailRepository.GetAllEmailsAsync();

                return Ok(emails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmail([FromBody] Email email)
        {
            try
            {
                if (email == null)
                {
                    return BadRequest();
                }

                Email creadedEmail = _emailRepository.CreateEmail(email);

                if (!await _emailRepository.SaveAsync())
                {
                    return StatusCode(500, $"Internal server error");
                }

                return Ok(creadedEmail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error  {ex}");
            }
        }
    }
}
