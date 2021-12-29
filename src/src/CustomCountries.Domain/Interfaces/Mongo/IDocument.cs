using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CustomCountries.Domain.Interfaces.Mongo
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
