using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HermesORM.DbEntities
{
    public class User
    {
        public int UserId { get; set; } // Id (Primary key)
        public string UserName { get; set; } // User Name
        public string FirstName { get; set; } // Users FirstName
        public string LastName { get; set; } // User LastName
        public string Password { get; set; } // User Password
        public string Email { get; set; } // User Email
        public string Image { get; set; } // URL to user profile Picture
        public int DisplayName { get; set; } // ID ContactList

        // Reverse navigation
        //public virtual System.Collections.Generic.ICollection<Comment> Comments { get; set; } // blgComment.FK_Commented_Article
        // public virtual System.Collections.Generic.ICollection<Tag> Tags { get; set; } // Many to many mapping

        // Foreign keys
        //public virtual Author Author { get; set; } // FK_Article_ToAuthor

        public User()
        {
            Console.Write("3");
            //Tags = new System.Collections.Generic.List<Tag>();
        }
    }
}