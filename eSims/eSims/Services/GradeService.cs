using eSims.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace eSims.Services
{
	public class GradeService : IGradeService
	{
		private readonly IMongoCollection<Grade> _grades;
        private readonly IMongoCollection<Student> _students;
        private readonly IMongoCollection<Subject> _subjects;
        private readonly IMongoCollection<Professor> _professors;
        public GradeService(IeSimsDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_grades = database.GetCollection<Grade>(settings.GradesCollectionName);
            _students = database.GetCollection<Student>(settings.StudentsCollectionName);
            _subjects = database.GetCollection<Subject>(settings.SubjectsCollectionName);
            _professors = database.GetCollection<Professor>(settings.ProfessorsCollectionName);
        }
		public List<Grade> Get() =>
			_grades.Find(grade => true).ToList();
        public Grade Get(string id) =>
           FindGradeById(id);
		public Grade Create(Grade grade)
		{
			if (FindGradeById(grade.Id) != null || VerifyStudentAndProfessorAndSubjectExistence(grade) == false)
			{
				return null;
			}

			_grades.InsertOne(grade);
			return grade;
		}
        public bool Update(Grade newGrade)
        {
            if(FindGradeById(newGrade.Id) == null || VerifyStudentAndProfessorAndSubjectExistence(newGrade) == false)
            {
                return false;
            }
            
            _grades.ReplaceOne(grade => grade.Id == newGrade.Id, newGrade);
            return true;
        }
		public void Remove(Grade delGrade) =>
			_grades.DeleteOne(grade => grade.Id == delGrade.Id);
		public void Remove(string id) =>
			_grades.DeleteOne(grade => grade.Id == id);

        private Grade FindGradeById(string id) =>
            _grades.Find<Grade>(grade => grade.Id == id).FirstOrDefault();

        private bool VerifyStudentAndProfessorAndSubjectExistence(Grade grade)
        {
            if(_students.Find(student => student.Id == grade.StudentID).FirstOrDefault() == null)
            {
                return false;
            }

            if(_professors.Find(professor => professor.Id == grade.ProfessorID).FirstOrDefault() == null)
                {
                    return false;
                }
            
            if (_subjects.Find(subject => subject.Name == grade.SubjectName).FirstOrDefault() == null)
            {
                return false;
            }
            return true;
        }


    }
}
