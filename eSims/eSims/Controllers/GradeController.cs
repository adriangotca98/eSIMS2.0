using eSims.Models;
using eSims.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace eSims.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GradeController : ControllerBase
	{
		private readonly IGradeService _gradeService;
		public GradeController(IGradeService gradeService)
		{
			_gradeService = gradeService;
		}
		[HttpGet]
		public ActionResult<List<Grade>> Get() =>
			_gradeService.Get();

		[HttpGet("{id}",Name = "GetGrade")]
		public ActionResult<Grade> Get(string id)
		{
			var grade = _gradeService.Get(id);
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
			return CreatedAtRoute("GetGrade", new { id = grade.Id.ToString() }, grade);
		}
		[HttpPut]
		public IActionResult Update(Grade newGrade)
		{
			var grade = _gradeService.Get(newGrade.Id);
			if (grade == null)
			{
				return NotFound();
			}
            if (_gradeService.Update(newGrade))
                return NoContent();
			return BadRequest();
		}
		[HttpDelete]
		public IActionResult Delete(string id)
		{
			var grade = _gradeService.Get(id);
			if (grade == null)
			{
				return NotFound();
			}
			_gradeService.Remove(grade.Id);
			return NoContent();
		}
	}
}