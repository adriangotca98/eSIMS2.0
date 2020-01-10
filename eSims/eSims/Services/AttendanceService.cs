using eSims.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace eSims.Services
{
	public class AttendanceService : IAttendanceService
	{
		private readonly IMongoCollection<Attendance> _attendace;
		public AttendanceService(IeSimsDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			_attendace = database.GetCollection<Attendance>(settings.StudentsCollectionName);
		}
		public List<Attendance> Get() =>
				   _attendace.Find(prezent => true).ToList();
		public Attendance Get(string id) =>
			_attendace.Find(prezent => prezent.Id == id).FirstOrDefault();
		public Attendance Create(Attendance prezent)
		{
			_attendace.InsertOne(prezent);
			return prezent;
		}
		public void Update(Attendance prezentIn) =>
			_attendace.ReplaceOne(prezent => prezent.Id == prezentIn.Id, prezentIn);
		public void Remove(Attendance prezentIn) =>
			_attendace.DeleteOne(prezent => prezent.Id == prezentIn.Id);
		public void Remove(string id) =>
			_attendace.DeleteOne(prezent => prezent.Id == id);
	}
}
