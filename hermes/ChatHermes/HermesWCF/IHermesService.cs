using ChatHermes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HermesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    
        [ServiceContract]
        public interface IHermesService
        {
            [OperationContract]
            List<UserContract> GetAllUsers();

            [OperationContract]
            void AddUser(UserContract user);

            [OperationContract]
            string FindPassword(string inputEmail);

            [OperationContract]
            bool GetEmail(string inputEmail);

            [OperationContract]
            void UpdatePassword(string inputEmail, string inputPassword);

            [OperationContract]
            void RegisterUser(string UserName, string PassWord, string InputEmail, string FirstName, string LastName);

            [OperationContract]
            bool LoginQuery(string inputUsername);

            [OperationContract]
            string GetHashedPassowrd(string UserName);

    }
    

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "HermesWCF.ContractType".
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
