using eSims.Models;
using System.Collections.Generic;

namespace eSims.Services
{
	public interface ISubjectService
	{
		Subject Create(Subject subject);
		List<Subject> Get();
		Subject Get(string id);
		void Remove(string id);
		void Remove(Subject subjectIn);
		bool Update(string id, Subject subjectIn);
	}
}