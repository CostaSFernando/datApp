using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace datApp.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }
        [BsonElement("Price")]
        public decimal preco { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}