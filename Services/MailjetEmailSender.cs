using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;

namespace IdentityManager.Services
{
    public class MailjetEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public MailJetOptions _mailJetOptions;
        public MailjetEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _mailJetOptions = _configuration.GetSection("MailJet").Get<MailJetOptions>();

            MailjetClient client = new MailjetClient(_mailJetOptions.ApiKey, _mailJetOptions.SecretKey);
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, _mailJetOptions.FromEmail)
            .Property(Send.FromName, _mailJetOptions.FromName)
            .Property(Send.Subject, subject)
            .Property(Send.HtmlPart, htmlMessage)
            .Property(Send.Recipients, new JArray {
                new JObject {
                    {"Email", email}
                }
            });

            MailjetResponse response = await client.PostAsync(request);

            var ddd = "sss";
            //if (response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
            //    Console.WriteLine(response.GetData());
            //}
            //else
            //{
            //    Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
            //    Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
            //    Console.WriteLine(response.GetData());
            //    Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            //}
        }


        //       static async Task RunAsync()
        //       {
        //       _mailJetOptions = _configuration.GetSection("MailJet").Get<MailJetOptions>();
        //           MailjetClient client = new MailjetClient(Environment.GetEnvironmentVariable("****************************1234"), Environment.GetEnvironmentVariable("****************************abcd"))
        //           {
        //               Version = ApiVersion.V3_1,
        //           };
        //           MailjetRequest request = new MailjetRequest
        //           {
        //               Resource = Send.Resource,
        //           }
        //            .Property(Send.Messages, new JArray {
        //new JObject {
        // {
        //  "From",
        //  new JObject {
        //   {"Email", "randihesh@gmail.com"},
        //   {"Name", "Randika"}
        //  }
        // }, {
        //  "To",
        //  new JArray {
        //   new JObject {
        //    {
        //     "Email",
        //     "randihesh@gmail.com"
        //    }, {
        //     "Name",
        //     "Randika"
        //    }
        //   }
        //  }
        // }, {
        //  "Subject",
        //  "Greetings from Mailjet."
        // }, {
        //  "TextPart",
        //  "My first Mailjet email"
        // }, {
        //  "HTMLPart",
        //  "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
        // }, {
        //  "CustomID",
        //  "AppGettingStartedTest"
        // }
        //}
        //            });
        //           MailjetResponse response = await client.PostAsync(request);
        //           if (response.IsSuccessStatusCode)
        //           {
        //               Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
        //               Console.WriteLine(response.GetData());
        //           }
        //           else
        //           {
        //               Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
        //               Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
        //               Console.WriteLine(response.GetData());
        //               Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
        //           }
        //       }

    }
}
