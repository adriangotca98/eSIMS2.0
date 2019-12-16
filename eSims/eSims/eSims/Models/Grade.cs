using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace eSims.Models
{
	public class Grade
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("Value")]
		[JsonProperty("Value")]
		public int Value { get; set; }
		[BsonElement("Student ID")]
		[JsonProperty("Student ID")]
		public string StudentID { get; set; }
		[BsonElement("Professor ID")]
		[JsonProperty("Professor ID")]
		public string ProfessorID { get; set; }
		[BsonElement("Subject ID")]
		[JsonProperty("Subject ID")]
		public string SubjectID { get; set; }
		[BsonElement("Category")]
		[JsonProperty("Category")]
		public string Category { get; set; }
	}
}
