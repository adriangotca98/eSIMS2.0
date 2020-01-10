using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSims.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id;
        [BsonElement("Username")]
        public string Username;
        [BsonElement("Password")]
        public string Password;
        [BsonElement("TypeOfUser")]
        public string TypeOfUser;

    }
}
