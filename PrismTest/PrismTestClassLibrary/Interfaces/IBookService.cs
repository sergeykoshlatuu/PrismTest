using PrismTestClassLibrary.Models;
using System.Collections.Generic;

namespace PrismTestClassLibrary.Interfaces
{
   public interface IBookService
    {
        void AddBook(Book Book);
        List<Book> LoadListBook();
        void DeleteBook(Book Book);
        void UpdateBook(Book Book);
    }
}
