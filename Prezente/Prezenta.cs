using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSims.Models
{
    public class Prezenta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Grupa")]
        public string Grupa { get; set; }

        [BsonElement("Profesor")]
        public string Prof { get; set; }

        [BsonElement("Numar Studenti")]
        public int NrStud { get; set; }


    }
}
