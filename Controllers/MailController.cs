using MailSenderAPI.Infra.Services;
using MailSenderAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MailSenderAPI.Controllers
{
    [Route("api/mails")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult SendMail([FromBody] SendMailViewModel sendMailViewModel)
        {

            bool requestResult = _mailService.SendMail(sendMailViewModel.SendTo, sendMailViewModel.Subject, sendMailViewModel.Body, sendMailViewModel.IsHtml);

            if (requestResult)
            {
                return Ok();
            }
            else{
                return BadRequest();
            }

        }
    }

    [Route("api/newsletter")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly IMailService _mailService;

        public NewsletterController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IActionResult SendMail([FromBody] SendMailViewModel sendMailViewModel)
        {
            _mailService.SendMail(sendMailViewModel.SendTo, "Newsletter América Rental", sendMailViewModel.Body, sendMailViewModel.IsHtml);

            return Ok();
        }
    }

    [Route("/api")]
    [ApiController]
    public class Home
    {
        [HttpGet]
        public IResult HelloWorld()
        {
            return Results.Json("Hello World", contentType: "text-utf8", statusCode: 500, options: null);
        }
    }
}
