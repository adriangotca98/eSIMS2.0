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
		[HttpGet("{id:length(24)}", Name = "GetSubject")]
		public ActionResult<Subject> Get(string id)
		{
			var subject = _subjectsService.Get(id);
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
		[HttpPut("{id:length(24)}")]
		public IActionResult Update(string id, Subject subjectIn)
		{
			var subject = _subjectsService.Get(id);
			if (subject == null)
			{
				return NotFound();
			}
			_subjectsService.Update(id, subjectIn);
			return NoContent();
		}
		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var subject = _subjectsService.Get(id);
			if (subject == null)
			{
				return NotFound();
			}
			_subjectsService.Remove(subject.Id);
			return NoContent();
		}
	}
}
