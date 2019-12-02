using eSims.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace eSims.Services
{
    public class PrezentaService
    {
        private readonly IMongoCollection<Prezenta> _prezente;

        public PrezentaService(IeSimsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _prezente = database.GetCollection<Prezenta>(settings.PrezentaCollectionName);
        }
        public List<Prezenta> Get() =>
                   _prezente.Find(prezent => true).ToList();

        public Prezenta Get(string id) =>
            _prezente.Find(prezent => prezent.Id == id).FirstOrDefault();

        public Prezenta Create(Prezenta prezent)
        {
            _prezente.InsertOne(prezent);
            return prezent;
        }

        public void Update(string id, Prezenta prezentIn) =>
            _prezente.ReplaceOne(prezent => prezent.Id == id, prezentIn);

        public void Remove(Prezenta prezentIn) =>
            _prezente.DeleteOne(prezent => prezent.Id == prezentIn.Id);

        public void Remove(string id) =>
            _prezente.DeleteOne(prezent => prezent.Id == id);
    }
}
