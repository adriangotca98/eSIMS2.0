﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

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
		[BsonElement("ProfessorIDs")]
		public List<string> ProfessorIds { get; set; }
    }
}
