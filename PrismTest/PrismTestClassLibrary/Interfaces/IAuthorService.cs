using PrismTestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTestClassLibrary.Interfaces
{
    public interface IAuthorService
    {
        void AddAuthors(Author author);
        List<Author> LoadListAuthors();
        void DeleteAuthors(Author author);
        void UpdateAuthors(Author author);
        List<string> LoadListNamesAuthors();
        int GetIdAuthorByFullName(string fullname);
        Author GetById(int id);
    }
}
