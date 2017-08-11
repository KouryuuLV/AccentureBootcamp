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
            public string UserId;
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
            public string SecurityStamp;
            [DataMember]
            public bool EmailConfirmed;
            [DataMember]
            public string PhoneNumber;
            [DataMember]
            public bool PhoneNumberConfirmed;
            [DataMember]
            public bool TwoFactorEnable;
            [DataMember]
            public DateTime LockoutEndDateUtc;
            [DataMember]
            public bool LockoutEnabled;
            [DataMember]
            public int AccessFailedCount;

    }
    
}