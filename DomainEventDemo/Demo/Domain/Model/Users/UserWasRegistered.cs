using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Model.Users
{
    public class UserWasRegistered : IDomainEvent
    {
        public DateTime OcurredOn { get; }

        public Guid UserId { get; private set; }
        public string UserEmail { get; private set; }

        public UserWasRegistered (Guid idUser, string email)
        {
            UserId = idUser;
            UserEmail = email;
            OcurredOn = DateTime.Now.ToUniversalTime();
        }

        // No paso como argumento el usuario para controlar la info que publico.
        // En este caso, no quiero propagar la pass
        //public User User { get; private set; }
        //public UserCreated(User user)
        //{
        //    User = user;
        //    OcurredOn = DateTime.Now;
        //}
    }
}
