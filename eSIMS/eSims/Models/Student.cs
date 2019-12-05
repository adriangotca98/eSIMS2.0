using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSIMS.Models
{
	public class Student
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string RegistrationNumber;
		[BsonElement("First Name")]
		public string FirstName;
		[BsonElement("Last Name")]
		public string LastName;
		[BsonElement("Year")]
		public int Year;
		[BsonElement("Group")]
		public string Group;
		[BsonElement("Subject IDs")]
		public BsonArray SubjectIDs;
		[BsonElement("Grade IDs")]
		public BsonArray GradeIDs;
	}
}
