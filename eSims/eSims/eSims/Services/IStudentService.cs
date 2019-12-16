using eSims.Models;
using System.Collections.Generic;

namespace eSims.Services
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