using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace eSims.Models
{
	public class Professor
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("First Name")]
		public string FirstName { get; set; }

		[BsonElement("Last Name")]
		public string LastName { get; set; }

		[BsonElement("Subject IDs")]
		public List<string> SubjectsIds { get; set; }
	}
}
