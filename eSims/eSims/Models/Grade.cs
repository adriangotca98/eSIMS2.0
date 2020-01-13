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
		public int Value { get; set; }
		[BsonElement("StudentID")]
		public string StudentID { get; set; }
		[BsonElement("ProfessorID")]
		public string ProfessorID { get; set; }
		[BsonElement("SubjectID")]
		public string SubjectID { get; set; }
		[BsonElement("Category")]
		public string Category { get; set; }
    }
}
