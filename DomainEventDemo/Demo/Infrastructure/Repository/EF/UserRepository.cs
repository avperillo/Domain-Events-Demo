using Demo.Domain.Model.Users;
using Demo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repository.EF
{
    public class UserRepository : IUserRepository
    {
        private UserContext context;

        public UserRepository(UserContext context)
        {
            this.context = context;
        }

        public User Add(User entity)
        {
            try
            {
                context.Usuarios.Add(entity);
                return GetById(entity.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(User entity)
        {
            try
            {
                context.Usuarios.Remove(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(User entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetById(Guid id)
        {
            User usuario = default(User);

            try
            {
                usuario = (from u in context.Usuarios
                           where u.Id == id
                           select u).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return usuario;
        }

        public IEnumerable<User> ListAll()
        {
            return context.Usuarios;
        }

    }
}
