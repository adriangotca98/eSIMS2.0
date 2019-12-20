using eSims.Models;
using eSims.Services;
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
		[HttpGet("{registrationNumber}", Name = "GetStudent")]
		public ActionResult<Student> Get(string registrationNumber)
		{
			var student = _studentService.Get(registrationNumber);
			if (student == null)
			{
				return NotFound();
			}
			return student;
		}
		[HttpPost]
		public ActionResult<Student> Create(Student student)
		{
			if (_studentService.Create(student) == null)
			{
				return BadRequest();
			}
			return CreatedAtRoute("GetStudent", new { registrationNumber = student.RegistrationNumber.ToString() }, student);
		}
		[HttpPut("{registrationNumber}")]
		public IActionResult Update(string registrationNumber, Student studentIn)
		{
			var student = _studentService.Get(registrationNumber);
			if (student == null)
			{
				return NotFound();
			}
			if (_studentService.Update(registrationNumber, studentIn))
				return NoContent();
			return BadRequest();
		}
		[HttpDelete("{registrationNumber}")]
		public IActionResult Delete(string registrationNumber)
		{
			var student = _studentService.Get(registrationNumber);
			if (student == null)
			{
				return NotFound();
			}
			_studentService.Remove(student.RegistrationNumber);
			return NoContent();
		}
	}
}