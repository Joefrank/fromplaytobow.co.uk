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
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<User> _userRepos;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepos = _unitOfWork.Repository<User>();
        }

        public UserDto GetUser(int userId)
        {
            var user = _userRepos.FindFirst(x => x.UserId == userId);

            if (user != null)
            {
                return Mapper.Map<User, UserDto>(user);
            }
            return null;
        }

        public UserDto LogUser(string password, string email)
        {
            
            var encryptedpassword = Security.Encrypt(password);

            var user = _userRepos.FindFirst(x => 
                x.Email.ToLower().Trim().Equals(email.Trim().ToLower())
                && 
                x.Password == encryptedpassword
                );

            if (user != null)
            {
                var tempuser = user;

                return Mapper.Map<User, UserDto>(tempuser);
            }

            return null;
        }

        public UserDto CreateUser(UserDto user)
        {
            var newuser = Mapper.Map<UserDto, User>(user);
            _userRepos.Insert(newuser);
            _unitOfWork.CommitChanges();
            user.UserId = newuser.UserId;
            return user;
        }
    }
}
