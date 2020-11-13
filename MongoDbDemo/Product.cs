namespace MongoDbDemo
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Product : Entity
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        //[BsonId] // converts the Property to _id. Auto generates Guid.
        //public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        //public Many<Variant>  Variants { get; set; }

        //public Product()
        //{
        //    this.InitOneToMany(() => Variants);
        //}

    }
}
