using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Entities;
using System;
using System.Linq;

namespace MongoDbDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            OneToMany();
        }

        private static void NewMethod()
        {
            MongoCRUD db = new MongoCRUD("AddressBook");

            Person insert = new Person()
            {
                FirstName = "John",
                LastName = "Doe",
                PrimaryAddress = new Address()
                {
                    StreetAddress = "A",
                    City = "B",
                    State = "C",
                    ZipCode = "D"
                }
            };
            db.InsertDocument("Users", insert);
            var names = db.GetDocuments<Name>("Users");
            var documents = db.GetDocuments<Person>("Users");


            var documentForUpdate = db.GetDocumentById<Person>("Users", documents.FirstOrDefault().Id);
            documentForUpdate.PrimaryAddress = new Address()
            {
                StreetAddress = "UpsertA",
                City = "UpsertB",
                State = "UpsertC",
                ZipCode = "UpsertD"
            };
            db.UpdateDocument("Users", documentForUpdate.Id, documentForUpdate);




            db.DeleteDocument<Person>("Users", documentForUpdate.Id);

            Console.ReadLine();
        }

        private static void OneToMany()
        {
            new DB("OneToMany");
            //MongoDbSetup mongoDbSetup = new MongoDbSetup();
            //mongoDbSetup.Setup("OneToMany");
            Product product = new Product() { Description = "Cool t-shirt", Name = "T-shirt"};
            product.Save();
            var variant = new Variant() { Name = "Red", Price = 20 };
            variant.Product = product;
            variant.Save();
            //productCollection.InsertOne(product);
            //Variant variant = new Variant() { Id = Guid.NewGuid(), ProductId = product.Id, Name = "Red", Price = 20 };
            //variantCollection.InsertOne(variant);

        }
        public static void RegisterMapIfNeeded<TClass>()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TClass)))
                BsonClassMap.RegisterClassMap<TClass>(cm =>
                {
                    cm.AutoMap();
                });
        }
    }
}
