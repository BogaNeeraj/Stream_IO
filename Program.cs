using System;
using System.IO;
using System.Text;


namespace Stream_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Stream Implementation i c#");

            string path = @"c:\temp\MyTest.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream Fs = File.Create(path))
            {
                AddText(Fs, "I am Neeraj Kumar");
                AddText(Fs, "reading books and playing carrom in my free time");
                AddText(Fs, "\r\n\nand this is on a new Line");
                AddText(Fs, "\r\n\r\n the following is the subset of character:\r\n");

                for(int i =1;i<120;i++)
                {
                    AddText(Fs, Convert.ToChar(i).ToString());

                }
            }


            using (FileStream fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while(fs.Read(b, 0, b.Length)>0)
                {
                    Console.WriteLine(temp.GetString(b));

                }
            }
            static void AddText(FileStream fs, string value)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(value);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
