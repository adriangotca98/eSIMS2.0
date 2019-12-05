using eSIMS.Models;
using eSIMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eSims.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;
		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}
		[HttpGet]
		public ActionResult<List<Student>> Get() =>
			_studentService.Get();
		[HttpGet("{id:length(24)}", Name = "GetStudent")]
		public ActionResult<Student> Get(string id)
		{
			var student = _studentService.Get(id);
			if (student == null)
			{
				return NotFound();
			}
			return student;
		}
		[HttpPost]
		public ActionResult<Student> Create(Student student)
		{
			_studentService.Create(student);
			return CreatedAtRoute("GetStudent", new { id = student.RegistrationNumber.ToString() }, student);
		}
		[HttpPut("{id:length(24)}")]
		public IActionResult Update(string id, Student studentIn)
		{
			var student = _studentService.Get(id);
			if (student == null)
			{
				return NotFound();
			}
			_studentService.Update(id, studentIn);
			return NoContent();
		}
		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var student = _studentService.Get(id);
			if (student == null)
			{
				return NotFound();
			}
			_studentService.Remove(student.RegistrationNumber);
			return NoContent();
		}
	}
}