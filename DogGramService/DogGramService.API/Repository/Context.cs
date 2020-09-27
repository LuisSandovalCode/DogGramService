using DogGramService.API.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGramService.API.Repository
{
    public class Context
    {
        readonly IMongoDatabase _dataBase = null;
        public Context(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);

            if (mongoClient != null)
                _dataBase = mongoClient.GetDatabase(settings.Value.DataBase);
        }

        public IMongoCollection<T> GetCollection<T>(string nameCollection)
        {
            return _dataBase.GetCollection<T>(nameCollection);
        }
    }
}
