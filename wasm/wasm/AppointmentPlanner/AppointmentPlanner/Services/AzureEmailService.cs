using Azure.Communication.Email;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AppointmentPlanner.Services
{
    public class AzureEmailService
    {
        private readonly EmailClient _emailClient;
        private readonly string _fromAddress;

        public AzureEmailService(IConfiguration config)
        {
            var connStr = config["AzureCommunicationServices:ConnectionString"];
            _fromAddress = "DoNotReply@f0b9ab27-3e59-43f1-a003-ea39db1a7be9.azurecomm.net"; // Must be verified in ACS
            _emailClient = new EmailClient(connStr);
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var emailContent = new EmailContent(subject)
            {
                PlainText = body
            };
            var emailRecipients = new EmailRecipients(new[] { new EmailAddress(to) });
            var emailMessage = new EmailMessage(_fromAddress, emailRecipients, emailContent);

            await _emailClient.SendAsync(Azure.WaitUntil.Completed, emailMessage);
        }
    }
}