using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace eSims.Models
{
	public class Professor
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id;
        [BsonElement("FirstName")]
        public string FirstName;
        [BsonElement("LastName")]
        public string LastName;
        [BsonElement("Subjects")]
        public List<string> Subjects;
    }
}
