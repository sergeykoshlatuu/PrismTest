using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTestClassLibrary.Models
{
    public class Publisher
    {

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public Publisher() { }

        public Publisher(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
