using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Model.Users
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        IEnumerable<User> ListAll();
        User Add(User entity);
        void Update(User entity);
        void Delete(User entity);
    }
}
