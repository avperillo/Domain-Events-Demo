using Demo.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Data
{
    public class UserContext : DbContext
    {

        public UserContext()
            : base("name=UserContext")
        {
        }

        public DbSet<User> Usuarios;
    }
}
