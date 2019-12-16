using eSims.Models;
using System.Collections.Generic;

namespace eSims.Services
{
	public interface IGradeService
	{
		Grade Create(Grade grade);
		List<Grade> Get();
		Grade Get(string id);
		void Remove(Grade grade);
		void Remove(string id);
		void Update(string id, Grade newGrade);
	}
}