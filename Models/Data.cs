using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace datApp.Models
{

    public class Data
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }

        public string startTime { get; set; }
        public string endTime { get; set; }

        public Dictionary<string, string> variableDates { get; set; }
    }
}