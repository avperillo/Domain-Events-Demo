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

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(Guid id)
        {
            var user = _userRepository.GetAll()
                        .Where(usr => usr.Id == id)
                        .FirstOrDefault();

            if (user == null)
                throw new UserNotExistException();

            return user;
        }

        public User RegisterNewUser(User user)
        {
            if (_userRepository.GetAll().Any(u => u.Email == user.Email))
                throw new EmailAlreadyExistException();

            user.Id = Guid.NewGuid();

            var result = _userRepository.Add(user);

            DomainEvents.Raise(new UserWasRegistered(result.Id, result.Email));

            return result;
        }
    }
}
