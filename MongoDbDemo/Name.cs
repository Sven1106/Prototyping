using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDbDemo
{
    public class Name
    {
        [BsonId] //converts the Property to _id
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
