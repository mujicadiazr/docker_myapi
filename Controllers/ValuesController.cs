using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace myapi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public const string MAIL_HOST = "mail";
        public const int MAIL_PORT = 1025;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // POST api/values
        [HttpPost]
        public void Post(){
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("MyAPI", "myapi@myapi.com"));
            message.To.Add(new MailboxAddress("", "test@fake.com"));
            message.Subject = "Here your test email from Microservices!";

            message.Body = new TextPart("plain")
            {
                Text = "This is your test email content"
            };

            using(var mailClient = new SmtpClient())
            {
                mailClient.Connect(MAIL_HOST, MAIL_PORT, MailKit.Security.SecureSocketOptions.None);
                mailClient.Send(message);
                mailClient.Disconnect(true);
            }
        }
    }
}
