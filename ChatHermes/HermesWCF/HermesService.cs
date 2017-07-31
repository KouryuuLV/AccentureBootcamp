using ChatHermes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HermesORM;
using HermesORM.DbEntities;

namespace HermesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class HermesService : IHermesService
    {
        public List<UserContract> GetAllUsers()
        {
            using (var context = new HermesORM.DbHermesContext())
            {
                return context.User.Select(a => new UserContract
                {
                    UserId = a.UserId,
                    UserName = a.UserName,
                    Password = a.Password,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    Image = a.Image

                }).ToList();

            }
        }
        public void AddUser(UserContract user)
        {
            using (var context = new DbHermesContext())
            {
                context.User.Add(new HermesORM.DbEntities.User
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Image = user.Image
                });
                context.SaveChanges();
            }
        }
    }
}
