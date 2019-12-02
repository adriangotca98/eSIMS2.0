using eSims.Models;
using eSims.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace eSims.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {

       private readonly SubjectsService _subjectsService;

       public SubjectsController(SubjectsService subjectsService)
        {
            _subjectsService = subjectsService;
        }

        [HttpGet]
        public ActionResult<List<Subjects>> Get() =>
            _subjectsService.Get();


        [HttpGet("{id:length(24)}", Name = "GetSubject")]
        public ActionResult<Subjects> Get(string id)
        {
            var subject = _subjectsService.Get(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }

        [HttpPost]
        public ActionResult<Subjects> Create(Subjects subject)
        {
            _subjectsService.Create(subject);

            return CreatedAtRoute("GetSubject", new { id = subject.Id.ToString() }, subject);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Subjects subjectIn)
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
