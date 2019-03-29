using PrismTestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTestClassLibrary.Interfaces
{
    public interface IPublisherService
    {
        void AddPublisher(Publisher Publisher);
        List<Publisher> LoadListPublisher();
        void DeletePublisher(Publisher Publisher);
        void UpdatePublisher(Publisher Publisher);
    }
}
