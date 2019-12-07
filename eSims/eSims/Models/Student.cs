using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace eSIMS.Models
{
	public class Student
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id;
		[BsonElement("Registration Number")]
		[JsonProperty("Registration Number")]
		public string RegistrationNumber;
		[BsonElement("First Name")]
		[JsonProperty("First Name")]
		public string FirstName;
		[BsonElement("Last Name")]
		[JsonProperty("Last Name")]
		public string LastName;
		[BsonElement("Year")]
		[JsonProperty("Year")]
		public int Year;
		[BsonElement("Group")]
		[JsonProperty("Group")]
		public string Group;
		[BsonElement("Subjects")]
		[JsonProperty("Subjects")]
		public List<string> Subjects;
		[BsonElement("GradeIDs")]
		[JsonProperty("GradeIDs")]
		public List<string> GradeIDs;
	}
}
