using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSims.Models
{
    public class Subjects
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        //[BsonElement("Year")]
        public string Year { get; set; }

       // [BsonElement("Tearm")]
        public string Tearm { get; set; }

        //[BsonElement("Professors")]
        public string Professors { get; set; }



    }
}
