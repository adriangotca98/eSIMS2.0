using eSims.Models;
using eSims.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace eSims.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly GradeService _gradeService;
        public GradesController(GradeService gradeService)
        {
            _gradeService = gradeService;
        }
        [HttpGet]
        public ActionResult<List<Grade>> Get() =>
            _gradeService.Get();

        [HttpGet(Name = "GetGrade")]
        public ActionResult<Grade> Get(string idStudent, string idProfessor)
        {
            var grade = _gradeService.Get(idStudent, idProfessor);

            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }

        [HttpPost]
        public ActionResult<Grade> Create(Grade grade)
        {
            _gradeService.Create(grade);

            return CreatedAtRoute("GetGrade", new { id = grade.Student.Id.ToString() + grade.Professor.Id }, grade);
        }

        [HttpPut]
        public IActionResult Update(string idStudent, string idProfessor, Grade newGrade)
        {
            var grade = _gradeService.Get(idStudent, idProfessor);

            if (grade == null)
            {
                return NotFound();
            }

            _gradeService.Update(idStudent, idProfessor, newGrade);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(string idStudent, string idProfessor)
        {
            var grade = _gradeService.Get(idStudent, idProfessor);

            if (grade == null)
            {
                return NotFound();
            }

            _gradeService.Remove(grade.Student.Id, grade.Professor.Id);

            return NoContent();
        }

    }
}