using System;

namespace ACSharp.Activity.Collections
{
    public class CustomerInfo
    {
        int ID { get; set; }                  //–Property to get or set the customerID
        string Name { get; set; }             //–Property to get or set the customer name
        string Address { get; set; }          //–Property to get orset the customer address.
        string Email { get; set; }            //–Property to get or set the email address of the customer.
            
            //–Constructor to initialize the member variables.
            public void customerInfo(int id, string name, string address, string email)
        {
            ID = id;
            Name = name;
            Address = address;
            Email = email;
        }   
        

    }
}
