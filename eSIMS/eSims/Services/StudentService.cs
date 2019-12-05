using eSims.Models;
using eSIMS.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace eSIMS.Services
{
	public class StudentService : IStudentService
	{
		private readonly IMongoCollection<Student> _students;
		public StudentService(IeSimsDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_students = database.GetCollection<Student>(settings.StudentsCollectionName);
		}
		public List<Student> Get() =>
				   _students.Find(prezent => true).ToList();
		public Student Get(string registrationNumber) =>
			_students.Find(student => student.RegistrationNumber == registrationNumber).FirstOrDefault();
		public Student Create(Student student)
		{
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
