using PrismTestClassLibrary.Interfaces;
using PrismTestClassLibrary.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTestClassLibrary.Services
{
    public class AuthorsService : IAuthorService
    {
        private SQLiteConnection _con;

        public AuthorsService(IDatabaseConnectionService con)
        {
            _con = con.GetDatebaseConnection();
            _con.CreateTable<Author>();
            //_con.Insert(new Author("James", "Braun"));
            //_con.Insert(new Author("Fedor", "Dostoevskiy"));
        }

        public void AddAuthors(Author Authors)
        {
            if (Authors.Id == 0)
            {
                _con.Insert(Authors);
                return;
            }
            _con.Update(Authors);
        }

        public void DeleteAuthors(Author Authors)
        {
            if (Authors.Id != 0)
                _con.Table<Author>().Where(x => x.Id == Authors.Id).Delete();
        }

        public List<Author> LoadListAuthors()
        {
            List<Author> ListFromDatabase = _con.Table<Author>().ToList();
            return ListFromDatabase;
        }

        public void UpdateAuthors(Author Authors)
        {
            _con.Update(Authors);
        }

        public List<string> LoadListNamesAuthors()
        {
            List<Author> ListFromDatabase = _con.Table<Author>().ToList();
            List<string> tmp = new List<string>();
            for (int i = 0; i < ListFromDatabase.Count; i++)
            {
                string fullname = ListFromDatabase[i].FirstName + " " + ListFromDatabase[i].LastName;
                tmp.Add(fullname);
            }
            return tmp;
        }

        public int GetIdAuthorByFullName(string fullname)
        {
            string[] words = fullname.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstName = words[0];
            string lastName = words[1];
            List<Author> authors = _con.Table<Author>().Where(x => x.FirstName == firstName && x.LastName == lastName).ToList();
            if (authors.Count != 0)
            {
                return authors[0].Id;
            }
            return 0;
        }

        public Author GetById(int id)
        {
            if (id != 0)
            {
                return _con.Table<Author>().Where(x => x.Id == id).First();
            }
            return null;
        }
    }
}
