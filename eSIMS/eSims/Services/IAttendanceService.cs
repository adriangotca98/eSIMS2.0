using System.Collections.Generic;
using eSims.Models;

namespace eSims.Services
{
	public interface IAttendanceService
	{
		Attendance Create(Attendance prezent);
		List<Attendance> Get();
		Attendance Get(string id);
		void Remove(Attendance prezentIn);
		void Remove(string id);
		void Update(string id, Attendance prezentIn);
	}
}