using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbDemo
{
    public class MongoDbSetup
    {
        public IMongoDatabase mongoDb;
        public void Setup(string databaseName)
        {
            var customConventions = new ConventionPack {
                new IgnoreExtraElementsConvention(true), // Ignore the extra fields that a document has when compared to the provided DTO on Deserialization.  
                new IgnoreIfDefaultConvention(true) // Ignore the fields with default value on Serialization. Keeps the document smaller.
            };
            ConventionRegistry.Register("CustomConventions", customConventions, type => true); // how to handle different encounters during serialization & deserialization.
            var client = new MongoClient();
            this.mongoDb = client.GetDatabase(databaseName); // automatically creates a database if it doesn't exists
        }
    }
}
