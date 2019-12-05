using System.Collections.Generic;
using eSims.Models;

namespace eSims.Services
{
	public interface IGradeService
	{
		Grade Create(Grade grade);
		List<Grade> Get();
		Grade Get(string idStudent, string idProfessor);
		void Remove(Grade delGrade);
		void Remove(string idStudent, string idProfessor);
		void Update(string idStudent, string idProfessor, Grade newGrade);
	}
}