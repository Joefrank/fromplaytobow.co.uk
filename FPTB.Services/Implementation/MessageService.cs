using FPTB.Services.Infrastructure;
using FPTB.Data.Model;
using FPTB.Data.Repositories.Infrastructure;
using System;
using CM;
using System.Configuration;

namespace FPTB.Services.Implementation
{
    public class MessageService :IMessageService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<ContactMessage> _messagerepos;

        public MessageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _messagerepos = unitOfWork.Repository<ContactMessage>();
        }

        public virtual bool SendMessage(string username, string email, string subject, string messagebody)
        {
            var message = new ContactMessage
            {
                DateCreated = DateTime.Now,
                Email = email,
                FullName = username,
                MessageBody = messagebody
            };

            _messagerepos.Insert(message);
            _unitOfWork.CommitChanges();

            SendEmail(email, username, subject, messagebody);

            return true;
        }

        public bool SendEmail(string toAddress, string toName, string subject, string body)
        {
            var serverName = ConfigurationManager.AppSettings["OutGoingSMTPServer"];
            var userName = ConfigurationManager.AppSettings["EmailUserName"];
            var pass = ConfigurationManager.AppSettings["EmailPassword"];
            var adminEmail = ConfigurationManager.AppSettings["InfoEmail"];

            var mail = new Email(serverName, userName, pass);

            var result = mail.send(adminEmail, "Admin - [FromPlayToBow]", toAddress, toName, subject, body);

            if(!string.IsNullOrEmpty(result))
            {
                throw new Exception(result);
            }

            return true;
        }
    }
}
