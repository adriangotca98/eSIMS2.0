using eSims.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace eSims.Services
{
	public class AttendanceService : IAttendanceService
	{
		private readonly IMongoCollection<Attendance> _attendance;
		private readonly IMongoCollection<Professor> _professors;
		private readonly IMongoCollection<Student> _students;
		public AttendanceService(IeSimsDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			_attendance = database.GetCollection<Attendance>(settings.AttendanceCollectionName);
			_professors = database.GetCollection<Professor>(settings.ProfessorsCollectionName);
			_students = database.GetCollection<Student>(settings.StudentsCollectionName);
		}
		public List<Attendance> Get() =>
				   _attendance.Find(prezent => true).ToList();
		public Attendance Get(string id) =>
			FindAttendanceById(id);
		public Attendance Create(Attendance prezent)
		{
			if (FindAttendanceById(prezent.Id) != null)
			{
				return null;
			}
			_attendance.InsertOne(prezent);
			return prezent;
		}
		public bool Update(Attendance prezentIn)
		{
			if (VerifyProfAndStudentIDsExistence(prezentIn)==false|| FindAttendanceById(prezentIn.Id) == null)
			{
				return false;
			}
			_attendance.ReplaceOne(prezent => prezent.Id == prezentIn.Id, prezentIn);
			return true;
		}
		public void Remove(Attendance prezentIn) =>
			_attendance.DeleteOne(prezent => prezent.Id == prezentIn.Id);
		public void Remove(string id) =>
			_attendance.DeleteOne(prezent => prezent.Id == id);

		private Attendance FindAttendanceById(string id) =>
			_attendance.Find(prezent => prezent.Id == id).FirstOrDefault();

		private bool VerifyProfAndStudentIDsExistence(Attendance prezentIn)
		{
			if (_professors.Find(prof => prof.Id == prezentIn.Prof).FirstOrDefault() == null)
			{
				return false;
			}
			foreach (var studentId in prezentIn.StudentIds)
			{
				if (_students.Find(student => student.Id == studentId).FirstOrDefault() == null)
				{
					return false;
				}
			}
			return true;
		}
	}
}
