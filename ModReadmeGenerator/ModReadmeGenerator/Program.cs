using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModReadmeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                //print help message
                string path = Environment.CurrentDirectory;
                string path2 = Path.Combine(path, "ModProperties.txt");
                Properties properties = new Properties
                {
                    path = path2
                };

                properties.Read();
                Console.WriteLine(properties.Name);
                Console.ReadLine();
            }
        }
    }
}
