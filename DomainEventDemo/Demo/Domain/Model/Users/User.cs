using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Model.Users
{
    public class User
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string userName, string email, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("email");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            this.Id = new Guid();
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
        }

    }
}
