using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSims.Models
{
    public class Attendance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Group")]
        public string Group { get; set; }
        [BsonElement("Professor")]
        public string Prof { get; set; }
        [BsonElement("Number of students")]
        public int NrStud { get; set; }
		[BsonElement("Students")]
		public BsonArray StudentIds { get; set; }
	}
}
