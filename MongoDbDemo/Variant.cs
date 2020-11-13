
namespace MongoDbDemo
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Variant : Entity
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        //[BsonId] // converts the Property to _id. Auto generates Guid.
        //public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets ProductId.
        /// </summary>
        /// 
        public One<Product> Product { get; set; }
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Price.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets RequiredVariantId.
        /// </summary>
        public Guid? RequiredVariantId { get; set; }
    }
}
