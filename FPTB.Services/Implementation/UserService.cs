using FPTB.Data.Repositories.Infrastructure;
using FPTB.Model;
using FPTB.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FPTB.Data.Model;
using CM;

namespace FPTB.Services.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepos;

        public UserService(IUserRepository userRepos)
        {
            _userRepos = userRepos;
        }

        public UserDto GetUser(int userId)
        {
            var user = _userRepos.FindBy(x => x.UserId == userId);
            if (user.Any())
            {
                return Mapper.Map<User, UserDto>(user.FirstOrDefault());
            }
            return null;
        }

        public UserDto LogUser(string password, string email)
        {
            
            var encryptedpassword = Security.Encrypt(password);

            var user = _userRepos.FindBy(x => 
                x.Email.ToLower().Trim().Equals(email.Trim().ToLower())
                && 
                x.Password == encryptedpassword
                );

            if (user.Any())
            {
                var tempuser = user.FirstOrDefault();

                return Mapper.Map<User, UserDto>(tempuser);
            }

            return null;
        }

        public UserDto CreateUser(UserDto user)
        {
            var newuser = Mapper.Map<UserDto, User>(user);
            _userRepos.Add(newuser);
            user.UserId = _userRepos.Save();
            return user;
        }
    }
}
