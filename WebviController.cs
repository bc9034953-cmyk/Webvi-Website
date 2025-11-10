using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using WebviAPI.IServices;
using WebviAPI.Model;
using WebviAPI.Services;
using static WebviAPI.Services.WebviService;

namespace WebviAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebviController : ControllerBase
    {
        private readonly WebviService _service;

        public WebviController(WebviService service)
        {
            _service = service;
        }

        [HttpPost("contact")]
        public IActionResult Submit([FromBody] ContantFrom form)
        {
            if (form == null)
                return BadRequest("Form not submitted!");

            try
            {
                _service.SandEmail(form);
                return Ok(new { success = true, message = "Message sent successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }


    }
}

