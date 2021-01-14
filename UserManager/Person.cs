using System;

namespace UserManager
{
    class Person
    {
        private string Name{ get; set; }
        private string Surname { get; set; }
        private int Age { get; set; }

        public Person(string name, string surname, int age) {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public static string writePerson(Person p) {
            return p.Name + " " + p.Surname + " " + p.Age;
        }

    }
}
