using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MongoDbDemo
{
    public class MongoCRUD : MongoDbSetup
    {
        public MongoCRUD(string databaseName)
        {
            Setup(databaseName); // automatically creates a database if it doesn't exists
        }

        public void InsertDocument<T>(string collectionName, T document)
        {
            var collection = this.mongoDb.GetCollection<T>(collectionName);
            collection.InsertOne(document);
        }

        public List<T> GetDocuments<T>(string collectionName)
        {
            var collection = mongoDb.GetCollection<T>(collectionName);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T GetDocumentById<T>(string collectionName, Guid id)
        {
            var collection = mongoDb.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).FirstOrDefault();
        }

        public void UpdateDocument<T>(string collectionName, Guid id, T document)
        {
            var collection = mongoDb.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = collection.ReplaceOne(
                filter,
                document
            );
        }

        public void DeleteDocument<T>(string collectionName, Guid id)
        {
            var collection = mongoDb.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }
    }
}
