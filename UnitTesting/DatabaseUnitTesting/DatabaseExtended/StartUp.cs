using System;

namespace DatabaseExtended
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var arr = new Person[] { new Person(1, "asdas") };
            Database<Person> database = new Database<Person>();
        }
    }
}
