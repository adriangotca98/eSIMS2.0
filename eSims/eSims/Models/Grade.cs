using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSims.Models
{
	public class Grade
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("Value")]
		public int Value { get; set; }
		[BsonElement("Student ID")]
		public string StudentID { get; set; }
		[BsonElement("Professor ID")]
		public string ProfessorID { get; set; }
		[BsonElement("Subject ID")]
		public string SubjectID { get; set; }
		[BsonElement("Category")]
		public string Category { get; set; }
	}
}
