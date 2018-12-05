using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseExtended
{
   public class Person
    {
        public Person(int id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public Person()
        {

        }
        public int Id { get; }
        public string Username { get; }
    }
}
