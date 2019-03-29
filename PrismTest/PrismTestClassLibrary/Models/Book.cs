using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTestClassLibrary.Models
{
    public class Book
    {
        public Book(string name, int year, int authorId, int publisherId)
        {
            Name = name;
            Year = year;
            AuthorId = authorId;
            PublisherId = publisherId;
        }

        public Book() { }
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}
