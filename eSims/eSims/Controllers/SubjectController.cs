using eSims.Models;
using eSims.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eSims.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubjectController : ControllerBase
	{
		private readonly ISubjectService _subjectsService;
		public SubjectController(ISubjectService subjectsService)
		{
			_subjectsService = subjectsService;
		}
		[HttpGet]
		public ActionResult<List<Subject>> Get() =>
			_subjectsService.Get();

		[HttpGet("{name}", Name = "GetSubject")]
		public ActionResult<Subject> Get(string name)
		{
			var subject = _subjectsService.Get(name);
			if (subject == null)
			{
				return NotFound();
			}
			return subject;
		}

		[HttpPost]
		public ActionResult<Subject> Create(Subject subject)
		{
			
            if (_subjectsService.Create(subject) == null)
            {
                return BadRequest();
            }

            return CreatedAtRoute("GetSubject", new { id = subject.Id.ToString() }, subject);
		}

		[HttpPut]
		public IActionResult Update(Subject subjectIn)
		{
			var subject = _subjectsService.Get(subjectIn.Name);
			if (subject == null)
			{
				return NotFound();
			}
			if(_subjectsService.Update(subjectIn))
			    return NoContent();
            return BadRequest();
		}
		[HttpDelete("{Name}")]
		public IActionResult Delete(string name)
		{
			var subject = _subjectsService.Get(name);
			if (subject == null)
			{
				return NotFound();
			}
			_subjectsService.Remove(subject.Name);
			return NoContent();
		}
	}
}
