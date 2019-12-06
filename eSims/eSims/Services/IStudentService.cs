using eSIMS.Models;
using System.Collections.Generic;

namespace eSIMS.Services
{
	public interface IStudentService
	{
		Student Create(Student student);
		List<Student> Get();
		Student Get(string registrationNumber);
		void Remove(string registrationNumber);
		void Remove(Student student);
		void Update(string registrationNumber, Student student);
	}
}