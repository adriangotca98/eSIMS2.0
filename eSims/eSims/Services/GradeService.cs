using eSims.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace eSims.Services
{
	public class GradeService : IGradeService
	{
		private readonly IMongoCollection<Grade> _grades;
		public GradeService(IeSimsDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_grades = database.GetCollection<Grade>(settings.GradesCollectionName);
		}
		public List<Grade> Get() =>
			_grades.Find(grade => true).ToList();
		public Grade Get(string id) =>
		   _grades.Find<Grade>(grade => grade.Id == id).FirstOrDefault();
		public Grade Create(Grade grade)
		{
			if (_grades.Find<Grade>(g => g.Id == grade.Id).FirstOrDefault() != null)
			{
				return null;
			}

			_grades.InsertOne(grade);
			return grade;
		}
		public void Update(string id, Grade newGrade) =>
			_grades.ReplaceOne(grade => grade.Id == id, newGrade);
		public void Remove(Grade delGrade) =>
			_grades.DeleteOne(grade => grade.Id == delGrade.Id);
		public void Remove(string id) =>
			_grades.DeleteOne(grade => grade.Id == id);
	}
}
