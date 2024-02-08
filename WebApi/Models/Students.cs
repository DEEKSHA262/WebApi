using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoExample.Models
{
    public class StudentList
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Firstame { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [BsonElement("items")]
        public List<string> studentsID { get; set; } 
    }
}