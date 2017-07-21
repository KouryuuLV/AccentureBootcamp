using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ACSharp.Activity.Collections
{
    public class CustomerInfoCollection
    {
        List<CustomerInfo> CustomerCollection = new List<CustomerInfo>();

        public int Count { get; }

        public const int NOT_IN_STRUCTURE = -1;

        public bool IsEmpty()
            => (this.Count <= 0);

        public int Capacity
            => this.CustomerCollection.Count;

        public int Add(CustomerInfo arg)
        //Method to add the CustomerInfoobject to the collection. This method should throw anArgumentNullExceptionif the input argument is null.It should return the index atwhich the argument was added tothe collectionor -1 if the object already is in the collection.
        {
            if (!(typeof(CustomerInfo).IsGenericParameter) && arg != null && !Contains(arg))
            {
                CustomerCollection[Count] = arg;
                return Count - 1;
            }
            if (arg == null)
            {
                throw new ArgumentNullException("argument can not be null");
            }
            else
            {
                return NOT_IN_STRUCTURE;
            }
        }
            public void Insert(int indexToInsert,CustomerInfo arg)
        //Method to insert the CustomerInfoobject at the specified index in the collection. This method should throw anArgumentNullExceptionif the input CustomerInfoobject is nulland ArgumentOutOfRangeExceptionexception if the index at which to insert the object is less than zero.If the object to be inserted already is present in the collection, do nothing.
        {
            if (!(typeof(CustomerInfo).IsGenericParameter) && arg == null)
            {
                throw new ArgumentNullException("argument can not be null");
            }

            if ((indexToInsert < 0) || (indexToInsert >= Count) || Contains(arg))
            {
                throw new ArgumentOutOfRangeException("Not correct index");
            }
            else
            {
                
                if (indexToInsert < Count)
                {
                    for (int i = Count; i > indexToInsert; i--)
                    {
                        //moving to make sppace for insert.
                        CustomerCollection[i] = CustomerCollection[i - 1];

                    }
                }
                CustomerCollection[indexToInsert] = arg;
            }
        }
            public void Remove(CustomerInfo arg)
        //Method to remove the CustomerInfoobject from the collection.This method should throw anArgumentNullExceptionif the inputargument is null.
            {
            if (!(typeof(CustomerInfo).IsGenericParameter) && arg == null)
            {
                throw new ArgumentNullException("Impossible to remove null.");
            }
            if (Contains(arg))
            {
                for (int i = IndexOf(arg); i < (Count - 1); i++)
                {
                    CustomerCollection[i] = CustomerCollection[(i + 1)];

                }
                CustomerCollection[Count - 1] = default(CustomerInfo);

            }
            else
            {
                throw new InvalidOperationException("index is outside defined range");
            }
            }
            
            public bool Contains(CustomerInfo argToCheck)
        //Method to check if the input CustomerInfoobject exists in the collection.This method should throw anArgumentNullExceptionif the input argument is null.It should return trueif the input object exists in the collection and falseotherwise.
           => (this.IndexOf(argToCheck) != NOT_IN_STRUCTURE);
        
            public int IndexOf(CustomerInfo arg)
        //Method to find the index of the input CustomerInfoobject in the collection.This method should throw anArgumentNullExceptionif the input argument is null.This should returnthe index at which the argumentcan be found in the collection or -1 if the object can’t be found in the collection.
        {
            //Loop through the array
            for (int i = 0; i < this.Count; i++)
            {
                //Check if the argument at the current index is equal to the input argument
                if (this.CustomerCollection[i].Equals(arg))
                {
                    return i;
                }
            }

            //Input argument is not found.
            return NOT_IN_STRUCTURE;
        }
        

        public CustomerInfo this[int index]
        //indexerproperty. It should get the CustomerInfoobject from the collection at the specified index or set thenewCustomerInfoobject at the specified index(by making sure the indexis within valid range, the new object is not null and doesn’ t belong to the collection already).
        {
            get
            {
                if ((index < 0) || (index >= this.Count))
                    throw new IndexOutOfRangeException("Invalid Index");

                return this.CustomerCollection[index];
            }
            protected set
            {
                this.CustomerCollection[index] = value;
            }
        }
    }
}
