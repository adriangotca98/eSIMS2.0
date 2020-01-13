using eSims.Models;
using System.Collections.Generic;

namespace eSims.Services
{
	public interface ISubjectService
	{
		Subject Create(Subject subject);
		List<Subject> Get();
		Subject Get(string name);
		void Remove(string name);
		void Remove(Subject subjectIn);
		bool Update(Subject subjectIn);
	}
}