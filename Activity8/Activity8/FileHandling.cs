using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace CSharp.Activity.CoreUtilities
{
    public class FileHandling
    {
        public FileHandling(string)             //Constructor to initialize with the file name and path.
        {
            this.path = path;
            //var path = Path.Combine(@"C:\Work", "testfile.txt");
            //Console.WriteLine(Path.GetDirectoryName(path)); // C:\Work
            //Console.WriteLine(Path.GetExtension(path));     // .txt
            //Console.WriteLine(Path.GetFileName(path));      // testfile.txt
            //Console.WriteLine(Path.GetPathRoot(path));      // C:\FileInfo
            //fileInfo = new FileInfo(path);
            //if (!fileInfo.Exists) //Alternatively:
            //    !File.Exists(path)
            //    {
            //    using (FileStream fileStream = File.Create(path))
            //    {
            //        byte[] data = Encoding.UTF8.GetBytes("SomeData");
            //        fileStream.Write(data, 0, data.Length);
            //    }
            //    Console.WriteLine(File.ReadAllText(path, Encoding.UTF8));
            //    //:::
            //    if (File.Exists(path)) File.Delete(path);
            //}
        }
            public void WriteToDisk(string info)     //Method to write the input contents to the file. 
            {
            try
            {
                //using (FileStream fileStream = File.Create(path))
                //using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                //using (StreamWriter sw = new StreamWriter(bufferedStream))
                {
                    sw.writeLine(info);
                }
            }
            catch
            {
                Console.WriteLine("File could not be written!");
            }
            
        }
        public string ReadFromDisk()        //Method to read the contents of the file from the disk.It returns the contents of the file as a string.
        {
            try
            {


                using (FileStream fileStream = File.OpenRead(path))
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                using (StreamReader sr = new StreamReader(bufferedStream))
                {
                    while (sr.EndOfStream)
                    {
                        sb.append(sr.ReadLine()).append("\n");
                        return sr.ReadToEnd;
                        Console.WriteLine(sr.ReadLine());
                        Console.WriteLine(sr.ReadToEnd());
                    }
                }
            }
            catch

            {

            }

        }


        }
    }
}
