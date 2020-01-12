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
            FindProfessorById(id);
		public Professor Create(Professor professor)
		{

            if (FindProfessorById(professor.Id) != null || VerifySubjects(professor) == false)
            {
                return null;
            }
            _professors.InsertOne(professor);
            insertProfIdInSubjects(professor.Subjects,professor.Id);
            return professor;
		}
        public bool Update(Professor professor)
        {
            if (VerifySubjects(professor) == false)
            {
                return false;
            }
            _professors.ReplaceOne(Professor => Professor.Id == professor.Id, professor);
            insertProfIdInSubjects(professor.Subjects, professor.Id);
            return true;
        }
        public void Remove(Professor professorIn) =>
			_professors.DeleteOne(professor => professor.Id == professorIn.Id);
		public void Remove(string id) =>
			_professors.DeleteOne(professor => professor.Id == id);
        private Professor FindProfessorById(string id) =>
            _professors.Find(professor => professor.Id == id).FirstOrDefault();
        private bool VerifySubjects(Professor professor)
        {
            foreach (string _subject in professor.Subjects.ToList())
            {
                if (_subjects.Find(subject => subject.Name == _subject).FirstOrDefault() == null)
                {
                    return false;
                }
            }
            return true;
        }
        private void insertProfIdInSubjects(List <string> subjects, string id)
        {
            foreach (string s in subjects)
            {
                Subject subject = _subjects.Find(subject => subject.Name == s).FirstOrDefault();
                subject.ProfessorIds.Add(id);
                _subjects.ReplaceOne(Subject => Subject.Name == s, subject);
            }
        }
}
}
