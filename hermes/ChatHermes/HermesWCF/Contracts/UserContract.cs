using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ChatHermes.Contracts
{
    
        [DataContract]
        public class UserContract
        {
            [DataMember]
            public int UserId;
            [DataMember]
            public string UserName;
            [DataMember]
            public string FirstName;
            [DataMember]
            public string LastName;
            [DataMember]
            public string Password;
            [DataMember]
            public string Email;
            [DataMember]
            public string Image;
    }
    
}