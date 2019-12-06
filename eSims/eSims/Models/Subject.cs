using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSims.Models
{
	public class Subject
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("Name")]
		public string Name { get; set; }
		[BsonElement("Year")]
		public string Year { get; set; }
		[BsonElement("Term")]
		public string Term { get; set; }
		[BsonElement("Professor IDs")]
		public BsonArray ProfessorIds { get; set; }
	}
}
