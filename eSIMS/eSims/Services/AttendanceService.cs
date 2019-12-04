using eSims.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace eSims.Services
{
	public class AttendanceService : IAttendanceService
	{
		private readonly IMongoCollection<Attendance> _prezente;

		public AttendanceService(IeSimsDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_prezente = database.GetCollection<Attendance>(settings.PrezentaCollectionName);
		}
		public List<Attendance> Get() =>
				   _prezente.Find(prezent => true).ToList();

		public Attendance Get(string id) =>
			_prezente.Find(prezent => prezent.Id == id).FirstOrDefault();

		public Attendance Create(Attendance prezent)
		{
			_prezente.InsertOne(prezent);
			return prezent;
		}

		public void Update(string id, Attendance prezentIn) =>
			_prezente.ReplaceOne(prezent => prezent.Id == id, prezentIn);

		public void Remove(Attendance prezentIn) =>
			_prezente.DeleteOne(prezent => prezent.Id == prezentIn.Id);

		public void Remove(string id) =>
			_prezente.DeleteOne(prezent => prezent.Id == id);
	}
}
