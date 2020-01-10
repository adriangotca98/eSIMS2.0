using eSims.Models;
using eSims.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace eSims.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfessorController : ControllerBase
	{
		private readonly IProfessorService _professorService;
		public ProfessorController(IProfessorService professorService)
		{
			_professorService = professorService;
		}
		[HttpGet]
		public ActionResult<List<Professor>> Get() =>
			_professorService.Get();

		[HttpGet("{id:length(24)}", Name = "GetProfessor")]
		public ActionResult<Professor> Get(string id)
		{
			var professor = _professorService.Get(id);
			if (professor == null)
			{
				return NotFound();
			}
			return professor;
		}
		[HttpPost]
		public ActionResult<Professor> Create(Professor professor)
		{
            if (_professorService.Create(professor) == null)
            {
                return BadRequest();
            }
        
			return CreatedAtRoute("GetProfessor", new { id = professor.Id.ToString() }, professor);
		}
		[HttpPut]
		public IActionResult Update(string id, Professor professorIn)
		{
			var professor = _professorService.Get(id);
			if (professor == null)
			{
				return NotFound();
			}
            if (_professorService.Update(professorIn))
                return NoContent();
            return BadRequest();

		}
		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var professor = _professorService.Get(id);
			if (professor == null)
			{
				return NotFound();
			}
			_professorService.Remove(professor.Id);
			return NoContent();
		}
	}
}
