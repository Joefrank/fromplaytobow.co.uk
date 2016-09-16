using FPTB.Services.Infrastructure;
using FPTB.Data.Model;
using FPTB.Data.Repositories.Infrastructure;
using System;
using CM;

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
            //***do emailing here.

            //var mail = new CM.Email();

            return true;
        }
    }
}
