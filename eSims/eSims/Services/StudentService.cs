using eSims.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace eSims.Services
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
			FindStudentByRegistrationNumber(registrationNumber);
		public Student Create(Student student)
		{
			if (FindStudentByRegistrationNumber(student.RegistrationNumber) != null || VerifySubjects(student) == false)
			{
				return null;
			}
			_students.InsertOne(student);
			return student;
		}
		public bool Update(Student student)
		{
			if (VerifySubjects(student) == false)
			{
				return false;
			}
			_students.ReplaceOne(Student => Student.RegistrationNumber == student.RegistrationNumber, student);
			return true;
		}
		public void Remove(Student student) =>
			_students.DeleteOne(individual => individual.RegistrationNumber == student.RegistrationNumber);
		public void Remove(string registrationNumber) =>
			_students.DeleteOne(student => student.RegistrationNumber == registrationNumber);
		private Student FindStudentByRegistrationNumber(string registrationNumber)=>
			_students.Find(student => student.RegistrationNumber == registrationNumber).FirstOrDefault();
		private bool VerifySubjects(Student student)
		{
			foreach (string _subject in student.Subjects.ToList())
			{
				if (_subjects.Find(subject => subject.Name == _subject).FirstOrDefault() == null)
				{
					return false;
				}
			}
			return true;
		}
	}
}
