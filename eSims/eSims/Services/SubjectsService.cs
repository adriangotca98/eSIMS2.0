using eSims.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace eSims.Services
{
    public class SubjectsService
    {
        private readonly IMongoCollection<Subjects> _subjects;

        public SubjectsService(IeSimsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _subjects = database.GetCollection<Subjects>(settings.SubjectsCollectionName);
        }

        public List<Subjects> Get() =>
            _subjects.Find(subject => true).ToList();

        public Subjects Get(string id) =>
            _subjects.Find<Subjects>(subject => subject.Id == id).FirstOrDefault();

        public Subjects Create(Subjects subject)
        {
            _subjects.InsertOne(subject);
            return subject;
        }

        public void Update(string id, Subjects subjectIn) =>
            _subjects.ReplaceOne(subjects => subjects.Id == id, subjectIn);

        public void Remove(Subjects subjectIn) =>
            _subjects.DeleteOne(subjects => subjects.Id == subjectIn.Id);

        public void Remove(string id) =>
            _subjects.DeleteOne(subjects => subjects.Id == id);



    }
}
