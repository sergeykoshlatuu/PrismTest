using PrismTestClassLibrary.Interfaces;
using PrismTestClassLibrary.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTestClassLibrary.Services
{
    public class PublisherService : IPublisherService
    {
        private SQLiteConnection _con;

        public PublisherService(IDatabaseConnectionService con)
        {
            _con = con.GetDatebaseConnection();
            _con.CreateTable<Publisher>();
        }

        public void AddPublisher(Publisher Publisher)
        {
            if (Publisher.Id == 0)
            {
                _con.Insert(Publisher);
                return;
            }
            _con.Update(Publisher);
        }

        public void DeletePublisher(Publisher Publisher)
        {
            if (Publisher.Id != 0)
                _con.Table<Publisher>().Where(x => x.Id == Publisher.Id).Delete();
        }

        public List<Publisher> LoadListPublisher()
        {
            List<Publisher> ListFromDatabase = _con.Table<Publisher>().ToList();
            return ListFromDatabase;
        }

        public void UpdatePublisher(Publisher Publisher)
        {
            _con.Update(Publisher);
        }
    }
}
