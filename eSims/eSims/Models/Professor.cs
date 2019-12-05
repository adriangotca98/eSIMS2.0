using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSims.Models
{
    public class Professor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Subjects")]
        public BsonArray SubjectsIds { get; set; }
    }
}
