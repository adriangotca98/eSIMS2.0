using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace eSims.Models
{
	public class Student
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id;
		[BsonElement("RegistrationNumber")]
		public string RegistrationNumber;
		[BsonElement("First Name")]
		public string FirstName;
		[BsonElement("Last Name")]
		public string LastName;
		[BsonElement("Year")]
		public int Year;
		[BsonElement("Group")]
		public string Group;
		[BsonElement("Subjects")]
		public List<string> Subjects;
		[BsonElement("GradeIDs")]
		public List<string> GradeIDs;
	}
}
