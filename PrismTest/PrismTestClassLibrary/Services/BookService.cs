using PrismTestClassLibrary.Interfaces;
using PrismTestClassLibrary.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTestClassLibrary.Services
{
    public class BookService : IBookService
    {
        private SQLiteConnection _con;

        public BookService(IDatabaseConnectionService con)
        {
            _con = con.GetDatebaseConnection();
            _con.CreateTable<Book>();
            //AddBook(new Book("name", 1992, 1, 1));
        }

        public void AddBook(Book book)
        {
            if (book.Id == 0)
            {
                _con.Insert(book);
                return;
            }
            _con.Update(book);
        }

        public void DeleteBook(Book book)
        {
            if (book.Id != 0)
                _con.Table<Book>().Where(x => x.Id == book.Id).Delete();
        }

        public List<Book> LoadListBook()
        {
            List<Book> ListFromDatabase = _con.Table<Book>().ToList();
            return ListFromDatabase;
        }

        public void UpdateBook(Book book)
        {
            _con.Update(book);
        }
    }
}
