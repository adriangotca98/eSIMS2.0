using eSims.Models;
using eSims.Services;
using eSIMS.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace eSIMS.Services
{
	public class StudentService : IStudentService
	{
		private readonly IMongoCollection<Student> _students;
		private readonly IMongoCollection<Subject> _subjects;
		private readonly IMongoCollection<Grade> _grades;
		public StudentService(IeSimsDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_students = database.GetCollection<Student>(settings.StudentsCollectionName);
			_subjects = database.GetCollection<Subject>(settings.SubjectsCollectionName);
			_grades = database.GetCollection<Grade>(settings.GradesCollectionName);
		}
		public List<Student> Get() =>
				   _students.Find(prezent => true).ToList();
		public Student Get(string registrationNumber) =>
			_students.Find(student => student.RegistrationNumber == registrationNumber).FirstOrDefault();
		public Student Create(Student student)
		{
			if (Get(student.RegistrationNumber) != null)
			{
				return null;
			}
			foreach (string _subject in student.Subjects.ToList())
			{
				if (_subjects.Find(subject => subject.Name == _subject).FirstOrDefault() == null)
				{
					return null;
				}
			}
			foreach(string gradeID in student.GradeIDs.ToList())
			{
				if (_grades.Find(grade => grade.Id == gradeID).FirstOrDefault() == null)
				{
					return null;
				}
			}
			_students.InsertOne(student);
			return student;
		}
		public void Update(string registrationNumber, Student student) =>
			_students.ReplaceOne(student => student.RegistrationNumber == registrationNumber, student);
		public void Remove(Student student) =>
			_students.DeleteOne(individual => individual.RegistrationNumber == student.RegistrationNumber);
		public void Remove(string registrationNumber) =>
			_students.DeleteOne(student => student.RegistrationNumber == registrationNumber);
	}
}
