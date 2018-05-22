using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Model.Users;
using Demo.Domain.Model;

namespace Demo.Application.Services.Users
{
    public class UserServices : IUserServices
    {

        private IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User RegisterNewUser(User user)
        {
            if (_userRepository.ListAll().Any(u => u.Id == user.Id))
                throw new UserAlreadyExistException();

            var result = _userRepository.Add(user);

            DomainEvents.Raise(new UserWasRegistered(result.Id, result.Email));

            return result;
        }
    }
}
