using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorServerDemo.Data.Infrastructure
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string? Id { get; set; }
    }
    public interface IIdentifiable:IDocument
    {

    }
}