using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HermesORM;
using HermesORM.DbEntities;
using ChatHermes.Contracts;
using System.Security.Cryptography;

namespace HermesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class HermesService : IHermesService
    {
        public List<ChatHermes.Contracts.UserContract> GetAllUsers()
        {
            using (var context = new DbHermesContext())
            {
                return context.User.Select(a => new ChatHermes.Contracts.UserContract
                {
                    UserId = a.UserId,
                    UserName = a.UserName,
                    Password = a.Password,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    SecurityStamp = a.SecurityStamp,
                    EmailConfirmed = a.EmailConfirmed,
                    PhoneNumber = a.PhoneNumber,
                    PhoneNumberConfirmed = a.PhoneNumberConfirmed,
                    TwoFactorEnable = a.TwoFactorEnable,
                    LockoutEnabled = a.LockoutEnabled,
                    AccessFailedCount = a.AccessFailedCount

                }).ToList();

            }
        }
        public void AddUser(ChatHermes.Contracts.UserContract user)
        {
            using (var context = new DbHermesContext())
            {
                context.User.Add(new HermesORM.DbEntities.UserContract
                {
                    UserId = Guid.NewGuid().ToString(),
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    SecurityStamp = user.SecurityStamp,
                    EmailConfirmed = user.EmailConfirmed,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    TwoFactorEnable = user.TwoFactorEnable,
                    LockoutEndDateUtc = user.LockoutEndDateUtc,
                    LockoutEnabled = user.LockoutEnabled,
                    AccessFailedCount = user.AccessFailedCount
                });
                context.SaveChanges();
            }
        }

        public string FindPassword(string inputEmail)
        {
            string getPass = null;
            if (inputEmail != null)
            {
                using (var context = new DbHermesContext())
                {
                    var query = from u in context.User
                                where u.Email == inputEmail
                                select u;
                    foreach (var item in query)
                    { 
                        getPass = item.Password;
                    }
                    return getPass;
                }
            }
            throw new ArgumentNullException("Input can't be null!");
        }

        public bool GetEmail(string inputEmail)
        {
            using (var context = new DbHermesContext())
            { 
                var query = context.User.Where(a => a.Email == inputEmail).FirstOrDefault();
                if(query != null) return true;
                return false;
            }
        }

        public void UpdatePassword(string inputEmail, string newPassword)
        {
            using (var context = new DbHermesContext())
            {
                var query = (from u in context.User
                            where u.Email == inputEmail
                            select u).Single();
                query.Password = newPassword;
                context.SaveChanges();
            }
        }

        public void RegisterUser(string inputUserName, string PassWord, string InputEmail, string inputFirstName, string inputLastName)
        {
            using (var context = new DbHermesContext())
            {
                context.User.Add(new HermesORM.DbEntities.UserContract
                {
                    UserId = Guid.NewGuid().ToString(),
                    UserName = inputUserName,
                    Password = PassWord,
                    Email = InputEmail,
                    FirstName = inputFirstName,
                    LastName = inputLastName,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    LockoutEnabled = true
                    
                });
                context.SaveChanges();
            }
        }
        public bool LoginQuery(string inputUsername)
        {
            using (var context = new DbHermesContext())
            {
                var query = context.User.Where(a => a.UserName == inputUsername).FirstOrDefault();
                if (query != null) return true;
                return false;
            }
        }

        public string GetHashedPassowrd(string UserName)
        {
            using (var context = new DbHermesContext())
            {
                var query = context.User.Where(a => a.UserName == UserName).FirstOrDefault();
                if (query != null) return query.Password;
                return null;
            }
        }
    }
}
