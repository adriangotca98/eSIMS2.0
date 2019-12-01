using Proiect.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Proiect.Services
{
    public class MaterieService
    {
        private readonly IMongoCollection<Materie> _materii;

        public MaterieService(IMateriiDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _materii = database.GetCollection<Materie>(settings.MateriiCollectionName);
        }
        public List<Materie> Get() =>
            _materii.Find(materie => true).ToList();

        public Materie Get(string id) =>
            _materii.Find<Materie>(materie => materie.Id == id).FirstOrDefault();

        public Materie Create(Materie materie)
        {
            _materii.InsertOne(materie);
            return materie;
        }

        public void Update(string id, Materie materieIn) =>
            _materii.ReplaceOne(m => m.Id == id, materieIn);

        public void Remove(Materie materie) =>
            _materii.DeleteOne(m => m.Id == materie.Id);

        public void Remove(string id) =>
            _materii.DeleteOne(m => m.Id == id);
    }
}
