using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSims.Models
{
    public class Grade
    {
        
        [BsonElement("Value")]
        public int Value { get; set; }

        public Student Student { get; set; }

        public Professor Professor { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }
    }
}
