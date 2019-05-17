using System.Collections.Generic;
using System.IO;
using Medioptimise.Core.Model;
using Medioptimise.Services.Infrastructure;
using SocketLabs.InjectionApi;
using SocketLabs.InjectionApi.Message;
using Attachment = System.Net.Mail.Attachment;

namespace medioptimize.services.Implementation
{
    public class SocketLabEmailService : IEmailService
    {
        private readonly ILogService _logService;
        private readonly SocketLabsClient _emailClient;

        public SocketLabEmailService(int serverId, string apiKey, ILogService logService)
        {
            _logService = logService;
            _emailClient = new SocketLabsClient(serverId, apiKey);
        }

        public Result SendEmailWithAttachment(string senderEmail, string senderName, string recipientName,
            string recipientEmail, string subject, string message, List<Attachment> attachments)
        {

            var emailMessage = new BasicMessage
            {
                Subject = subject,
                HtmlBody = message,
                From = new EmailAddress(senderEmail, senderName),
                To = new List<IEmailAddress>()
                {
                    new EmailAddress(recipientEmail, recipientName)
                }
            };

            foreach (var attachment in attachments) {
                var stream = (FileStream)attachment.ContentStream;
                var attachResult = emailMessage.Attachments.Add(stream.Name);
                attachResult.CustomHeaders.Add(new CustomHeader("Color", "Orange"));
                attachResult.CustomHeaders.Add(new CustomHeader("Place", "Beach"));

            }           

            var response = _emailClient.Send(emailMessage);

            if (!response.Result.Equals("Success"))
            {
                _logService.LogItem(response.ResponseMessage, "BS");
            }

            return new Result
            {
                Success = (response.Result.Equals("Success"))
            };
        }       

        public Result SendEmail(string senderEmail, string senderName, string recipientName,
            string recipientEmail, string subject, string message)
        {
                       
            var emailMessage = new BasicMessage
            {
                Subject = subject,
                HtmlBody = message,
                From = new EmailAddress(senderEmail, senderName),
                To = new List<IEmailAddress>()
                {
                    new EmailAddress(recipientEmail, recipientName)
                }
            };

            var response = _emailClient.Send(emailMessage);

            if (!response.Result.Equals("Success"))
            {
                _logService.LogItem(response.ResponseMessage, "BS");
            }

            return new Result
            {
                Success = (response.Result.Equals("Success"))
            };
        }
    }
}
