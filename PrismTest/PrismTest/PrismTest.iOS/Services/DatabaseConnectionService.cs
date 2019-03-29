using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using PrismTestClassLibrary.Interfaces;
using SQLite;
using UIKit;

namespace PrismTest.iOS.Services
{
    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        public DatabaseConnectionService()
        {
            var database = GetDatebaseConnection();
        }

        public SQLiteConnection GetDatebaseConnection()
        {
            var dbName = "Library.db";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder  
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder  
            var path = Path.Combine(libraryPath, dbName);
            return new SQLiteConnection(path);
        }
    }
}