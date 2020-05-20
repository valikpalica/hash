using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        private static string path = @"C:\Users\valik\source\repos\ConsoleApp1\ConsoleApp1\name.txt";
        private static Hashtable hashtable;
        private static float load = 0.72f;
        static void Main(string[] args)
           
        {
            hashtable = new Hashtable(100000,load);
            ReadOnFile();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            see_all();
            stopwatch.Stop();
            time(stopwatch);
            Console.ReadLine();
        }

        public static void see_all() {

            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine(item.Value);
            }

        }
        public static void add(string surname,string name,string patronim)
        {
            my_add(surname, name, patronim);
        }
        public static void time(Stopwatch stopwatch)
        {
            TimeSpan timeSpan = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);
        }
        public static void sort(string str) {
            foreach (DictionaryEntry item in hashtable)
            {    
                if (item.Key.ToString().Equals(str)) {
                    Console.WriteLine(item.Value);
                }
            }
        }
        public static void ReadOnFile() {
            try {
                using (StreamReader reader = new StreamReader(path))
                {
                    string text;
                    int i = 0;
                    while (i<=250 & ((text = reader.ReadLine())!=null))
                    {
                        my_add(text.Split(' ')[0], text.Split(' ')[1], text.Split(' ')[2]);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("File error");
            }
        }
        public static void my_add(string surname, string name, string patronim) {
            Person person = new Person(surname,name,patronim);
            Random random = new Random();
            try
            {
                int hash = Convert.ToInt32(surname[0]) + Convert.ToInt32(surname[1]) + Convert.ToInt32(surname[2]);
                
                foreach (DictionaryEntry item in hashtable)//блок решения колизии
                {
                    if (hash == int.Parse(item.Key.ToString())) {
                        hash = (hash + 1) * random.Next(1, 4);
                    }
                   
                }
                hashtable.Add(hash, person);
            }
            catch (Exception e)
            {
                Console.WriteLine("Format error");
            }
        }
    }
}
