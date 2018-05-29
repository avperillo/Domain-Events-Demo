using Demo.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Data.Users
{
    public interface IUserContext
    {
        IDbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
