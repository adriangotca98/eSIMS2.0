using eSims.Models;
using eSims.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace eSims.Services
{
	public class SubjectService : ISubjectService
	{
		private readonly IMongoCollection<Subject> _subjects;
        private readonly IMongoCollection<Professor> _professors;
        public SubjectService(IeSimsDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_subjects = database.GetCollection<Subject>(settings.SubjectsCollectionName);
            _professors = database.GetCollection<Professor>(settings.ProfessorsCollectionName);
        }
		public List<Subject> Get() =>
			_subjects.Find(subject => true).ToList();
        public Subject Get(string name) =>
            FindSubjectByName(name);
		public Subject Create(Subject subject)
		{
            if (FindSubjectByName(subject.Name) != null || VerifyProfessors(subject) == false)
            {
                return null;
            }
            _subjects.InsertOne(subject);
			return subject;
		}

		public bool Update(Subject subjectIn)
        {
            if(VerifyProfessors(subjectIn) == false)
            {
                return false;
            }
            _subjects.ReplaceOne(subjects => subjects.Name == subjectIn.Name, subjectIn);
            return true;
        }
			

		public void Remove(Subject subjectIn) =>
			_subjects.DeleteOne(subjects => subjects.Name == subjectIn.Name);
		public void Remove(string name) =>
			_subjects.DeleteOne(subjects => subjects.Name == name);

        private Subject FindSubjectByName(string name) =>
            _subjects.Find(subject => subject.Name == name).FirstOrDefault();

        private bool VerifyProfessors(Subject subject)
        {
            foreach (string _professor in subject.ProfessorIds.ToList())
            {
                if (_professors.Find(professor => professor.Id == _professor).FirstOrDefault() == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
