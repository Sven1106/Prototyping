using MongoDB.Driver;
using System;
using System.Linq;

namespace MongoDbDemo
{
    class Program
    {
        static void Main(string[] args)
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


    }
}
