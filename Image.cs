using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PersonalStudio.Application.Domain.Entities
{
    public class Image
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public required string ProductId { get; set; }
        public byte[] ImageContent { get; set; }
        public bool IsPrimary { get; set; }
    }
}