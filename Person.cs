using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        private string _name;
        private string _surname;
        private string _otchestvo;


        public Person(string name, string surname,string otchestvo)
        {
            _name = name;
            _surname = surname;
           
            _otchestvo = otchestvo;
        }

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Otchestvo { get => _otchestvo; set => _otchestvo = value; }




        


        public override string ToString()
        {
            return $"{Name} {Surname} {Otchestvo}";
        }
    }
}
