using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using FPTB.Model;
using FPTB.Services.Infrastructure;
using SocketLabs.InjectionApi;
using SocketLabs.InjectionApi.Message;
using Attachment = System.Net.Mail.Attachment;

namespace FPTB.Services.Implementation
{
    public class SocketLabEmailService : IEmailService
    {
        private readonly SocketLabsClient _emailClient;

        //public SocketLabEmailService()
        //{
        //    var serverId = CM.Security.Decrypt(ConfigurationManager.AppSettings["ServerId"]);
        //    var apiKey = CM.Security.Decrypt(ConfigurationManager.AppSettings["ApiKey"]);

        //    _emailClient = new SocketLabsClient(Convert.ToInt32(serverId), apiKey);
        //}

        public SocketLabEmailService(int serverId, string apiKey)
        {
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

            //if (!response.Result.Equals("Success"))
            //{
            //    _logService.LogItem(response.ResponseMessage, "BS");
            //}

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

            //if (!response.Result.Equals("Success"))
            //{
            //    _logService.LogItem(response.ResponseMessage, "BS");
            //}

            return new Result
            {
                Success = (response.Result.Equals("Success"))
            };
        }
    }
}
