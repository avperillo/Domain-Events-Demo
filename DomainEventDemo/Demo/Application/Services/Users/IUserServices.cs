using Demo.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Services.Users
{
    public interface IUserServices
    {

        User RegisterNewUser(User user);

        IEnumerable<User> GetAll();
        User GetById(Guid id);
    }
}
