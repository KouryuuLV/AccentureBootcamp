using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter an integer between 1 and 3: ");

            string data = Console.ReadLine();

            int myInt;

            if (!int.TryParse(data, out myInt))
            {
                data = "you did not enter an integer!";
            }
            else
            {
                switch (myInt)
                {
                    case 1:
                    case 2:
                    case 3:
                        data = string.Format("Your number is {0}.", myInt);
                        break;
                    default:
                        data = string.Format("Your number is {0} is not between 1 and 3!", myInt);
                        break;
                }
            }
            System.Console.WriteLine("{0}\nPress Enter to exit...", data);
            //System.Console.WriteLine("Hello World");
            Console.ReadKey();
        }
    }
}
