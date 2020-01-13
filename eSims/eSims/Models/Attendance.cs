using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace eSims.Models
{
	public class Attendance
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("Code")]
		public string Code { get; set; }
		[BsonElement("Group")]
		public string Group { get; set; }
		[BsonElement("Professor")]
		public string ProfId { get; set; }
        [BsonElement("SubjectName")]
        public string SubjectName { get; set; }
        [BsonElement("NumberOfStudents")]
		public int NrStud { get; set; }
		[BsonElement("StudentIDs")]
		public List<string> StudentIds { get; set; }
	}
}
