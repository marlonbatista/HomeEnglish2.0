using System;
using System.Collections.Generic;
using System.Text;
using HomeEnglish.Shared.ConfigDB;
using MongoDB.Driver;

namespace HomeEnglish.Infra.StoreContext.ConnectionDB
{
    public class HomeEnglishDataContext
    {
        public IMongoDatabase Connect()
        {
            // Connect in Server
            var client = new MongoClient(Settings.ConnectionString);

            // Connect in database
            var dataBase = client.GetDatabase("EnglishHouse");
            return dataBase;

        }
    }
}
