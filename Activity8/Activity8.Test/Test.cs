using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSharp.Activity.Collections
{
    class Test
    {
        static void Main(string[] args)
        {
            // C: \Users\Student\Source\Repos\JurisL\Activity8\IO.Test.txt
            var myAL = new CustomerInfoCollection;
            myAL.Add(1, "Oskars", "Cesis", o@a.lv);
            myAL.Add((2, "Ojars", "Riga", o@j.lv);
            myAL.Add((3, "Anete", "Madona", a@o.lv);
            //Displays the properties and values of the List.
            Console.WriteLine( "\tCount:    {0}", myAL.Count);
            Console.WriteLine( "\tCapacity: {0}", myAL.Capacity);
            Console.Write( "\tValues:" );
            PrintValues( myAL );
            Console.Read();
        }

        public static void PrintValues(IEnumerable myList) {
            foreach (var i in myList)
                Console.Write("\t{0}", i);

            Console.WriteLine(); }
    }
    Filehandling file = new Filehandling(@.\activity8.txt);
    stringbuilder sb = new stringbuilder();

    foreach(var info.id.append(\r\n).append......)
        file.writetodisk(sbyte.tostring());
    console.writeline(FileStyleUriParser.readfromdisk());
    
}
