using System.Collections.Generic;
using System.Net.Mail;

namespace FPTB.Services.Infrastructure
{
    public interface IEmailService
    {
        Result SendEmailWithAttachment(string senderEmail, string senderName, string recipientName,
            string recipientEmail, string subject, string message, List<Attachment> attachments);

        Result SendEmail(string senderEmail, string senderName, string recipientName,
            string recipientEmail, string subject, string message);
    }
}
