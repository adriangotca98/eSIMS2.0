using eSims.Models;
using System.Collections.Generic;

namespace eSims.Services
{
	public interface IProfessorService
	{
		Professor Create(Professor professor);
		List<Professor> Get();
		Professor Get(string id);
		void Remove(Professor professor);
		void Remove(string id);
		bool Update(string id, Professor professor);
	}
}