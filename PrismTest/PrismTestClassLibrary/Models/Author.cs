using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTestClassLibrary.Models
{
    public class Author
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author() { }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
