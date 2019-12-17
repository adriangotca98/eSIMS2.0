using eSims.Models;
using MongoDB.Driver;
using eSims.Services;
using System.Collections.Generic;
using System.Linq;
namespace eSims.Services
{
	public class ProfessorService : IProfessorService
	{
		private readonly IMongoCollection<Professor> _professors;
        private readonly IMongoCollection<Subject> _subjects;
        public ProfessorService(IeSimsDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_professors = database.GetCollection<Professor>(settings.ProfessorsCollectionName);
            _subjects = database.GetCollection<Subject>(settings.SubjectsCollectionName);
        }
        
		public List<Professor> Get() =>
			_professors.Find(professor => true).ToList();
		public Professor Get(string id) =>
		   _professors.Find<Professor>(profesor => profesor.Id == id).FirstOrDefault();
		public Professor Create(Professor professor)
		{
            if (Get(professor.Id) != null)
            {
                return null;
            }
            foreach (string _subject in professor.SubjectsIds.ToList())
            {
                if (_subjects.Find(subject => subject.Name == _subject).FirstOrDefault() == null)
                {
                    return null;
                }
            }
            _professors.InsertOne(professor);
			return professor;
		}
		public void Update(string id, Professor professorIn) =>
			_professors.ReplaceOne(professor => professor.Id == id, professorIn);
		public void Remove(Professor professorIn) =>
			_professors.DeleteOne(professor => professor.Id == professorIn.Id);
		public void Remove(string id) =>
			_professors.DeleteOne(professor => professor.Id == id);
	}
}
