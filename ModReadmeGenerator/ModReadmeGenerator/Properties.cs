using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModReadmeGenerator
{
    interface IParser
    {
        void Read();
        void SetProperty(object obj, string target, string value);
    }

    public class Properties : IParser
    {
        public string path;
        public string Name { get; set; }

        private string[] starts = new string[] { "Name" };
        public void Read()
        {
            Console.WriteLine("Test3");
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                if (!line.StartsWith("#"))
                {
                    string[] words = line.Split('=');
                    if (starts.Contains(words[0]))
                    {
                        SetProperty(this, words[0], words[1]);
                    }
                }
            }
        }

        public void SetProperty(object obj, string target, string value)
        {
            Type type = obj.GetType();

            PropertyInfo prop = type.GetProperty(target);

            prop.SetValue(obj, value, null);
        }
    }
}
