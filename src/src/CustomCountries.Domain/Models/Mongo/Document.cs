using CustomCountries.Domain.Interfaces.Mongo;
using MongoDB.Bson;
using System;

namespace CustomCountries.Domain.Models.Mongo
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
