using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Proiect.Models
{
    public class Materie
    {
        private Materie() { }

        public static Materie Create(string id,string nume, int an, int semestru)
        {
            return new Materie
            {
                Id = id,
                Nume = nume,
                An = an,
                Semestru = semestru
            };
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set;}
       
        [BsonElement("Nume")]
        public string Nume { get; private set; }
        public int An{ get; private set; }
        public int Semestru { get; private set; }

        public ICollection<Profesor> Profesori { get; private set; }

    }
}
