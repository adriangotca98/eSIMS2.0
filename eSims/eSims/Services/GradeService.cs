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
		public Grade Get(string idStudent, string idProfessor) =>
		   _grades.Find<Grade>(grade => grade.ProfessorID == idProfessor && grade.StudentID == idStudent).FirstOrDefault();
		public Grade Create(Grade grade)
		{
			if (Get(grade.StudentID, grade.ProfessorID) != null)
			{
				return null;
			}
			_grades.InsertOne(grade);
			return grade;
		}
		public void Update(string idStudent, string idProfessor, Grade newGrade) =>
			_grades.ReplaceOne(grad => grad.ProfessorID == idProfessor && grade.StudentID == idStudent, newGrade);
		public void Remove(Grade delGrade) =>
			_grades.DeleteOne(grade => grade.ProfessorID == delGrade.ProfessorID && grade.StudentID == delGrade.StudentID);
		public void Remove(string idStudent, string idProfessor) =>
			_grades.DeleteOne(grade => grade.ProfessorID == idProfessor && grade.StudentID == idStudent);
	}
}
