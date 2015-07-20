using FPTB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTB.Services.Infrastructure
{
    public interface IUserService
    {
        UserDto GetUser(int userId);

        UserDto LogUser(string password, string email);

        UserDto CreateUser(UserDto user);
    }
}
