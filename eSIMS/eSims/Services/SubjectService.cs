using eSims.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace eSims.Services
{
	public class SubjectService : ISubjectService
	{
		private readonly IMongoCollection<Subject> _subjects;

		public SubjectService(IeSimsDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_subjects = database.GetCollection<Subject>(settings.SubjectsCollectionName);
		}

		public List<Subject> Get() =>
			_subjects.Find(subject => true).ToList();

		public Subject Get(string id) =>
			_subjects.Find<Subject>(subject => subject.Id == id).FirstOrDefault();

		public Subject Create(Subject subject)
		{
			_subjects.InsertOne(subject);
			return subject;
		}

		public void Update(string id, Subject subjectIn) =>
			_subjects.ReplaceOne(subjects => subjects.Id == id, subjectIn);

		public void Remove(Subject subjectIn) =>
			_subjects.DeleteOne(subjects => subjects.Id == subjectIn.Id);

		public void Remove(string id) =>
			_subjects.DeleteOne(subjects => subjects.Id == id);



	}
}
