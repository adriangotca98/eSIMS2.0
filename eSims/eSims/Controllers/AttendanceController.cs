using eSims.Models;
using eSims.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eSims.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AttendanceController : ControllerBase
	{
		private readonly IAttendanceService _prezentService;
		public AttendanceController(IAttendanceService prezentService)
		{
			_prezentService = prezentService;
		}
		[HttpGet]
		public ActionResult<List<Attendance>> Get() =>
			_prezentService.Get();
		[HttpGet("{id:length(24)}", Name = "GetPrezenta")]
		public ActionResult<Attendance> Get(string id)
		{
			var prezent = _prezentService.Get(id);
			if (prezent == null)
			{
				return NotFound();
			}
			return prezent;
		}
		[HttpPost]
		public ActionResult<Attendance> Create(Attendance prezent)
		{
			_prezentService.Create(prezent);
			return CreatedAtRoute("GetPrezenta", new { id = prezent.Id.ToString() }, prezent);
		}
		[HttpPut]
		public IActionResult Update(Attendance prezentIn)
		{
			var prezent = _prezentService.Get(prezentIn.Id);
			if (prezent == null)
			{
				return NotFound();
			}
			_prezentService.Update(prezentIn);
			return NoContent();
		}
		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var prezent = _prezentService.Get(id);
			if (prezent == null)
			{
				return NotFound();
			}
			_prezentService.Remove(prezent.Id);
			return NoContent();
		}
	}
}