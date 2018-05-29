using Demo.Domain.Model.Users;
using System.Data.Entity;

namespace Demo.Infrastructure.Data.Users
{
    public class UserContext : DbContext, IUserContext
    {

        public UserContext()
            : base()
        {
        }

        public UserContext(string nameOrConnectionString) : base("name=UserContext")
        {
        }

        public IDbSet<User> Users { get; set; }

    }
}
