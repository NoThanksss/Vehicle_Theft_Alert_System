using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Net;

using System.Threading.Tasks;

namespace Vehicle_Theft_Alert_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AllertController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendAlert(string userName, string trakerName)
        {
            try
            {

                var mailMessage = new MimeMessage();
                mailMessage.From.Add(new MailboxAddress("alertsystemwork@gmail.com", "alertsystemwork@gmail.com"));
                mailMessage.To.Add(new MailboxAddress("Test", userName));
                mailMessage.Subject = "Підозріла активність";
                mailMessage.Body = new TextPart("plain")
                {
                    Text = $"Підозріла активність транспорту {trakerName}"
                };
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtp.gmail.com", 465, true);
                    smtpClient.Authenticate("alertsystemwork@gmail.com", "ugkwvwfyyjapofns");
                    smtpClient.Send(mailMessage);
                    smtpClient.Disconnect(true);
                }
                return Ok();
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
