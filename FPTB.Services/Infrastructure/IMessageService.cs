
namespace FPTB.Services.Infrastructure
{
    public interface IMessageService
    {
        bool SendMessage(string username, string email, string subject, string messagebody);
    }
}
