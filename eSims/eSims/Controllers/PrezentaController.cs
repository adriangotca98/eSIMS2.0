using eSims.Models;
using eSims.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eSims.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrezentaController : ControllerBase
    {
        private readonly PrezentaService _prezentService;

        public PrezentaController(PrezentaService prezentService)
        {
            _prezentService = prezentService;
        }

        [HttpGet]
        public ActionResult<List<Prezenta>> Get() =>
            _prezentService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPrezenta")]
        public ActionResult<Prezenta> Get(string id)
        {
            var prezent = _prezentService.Get(id);

            if (prezent == null)
            {
                return NotFound();
            }

            return prezent;
        }

        [HttpPost]
        public ActionResult<Prezenta> Create(Prezenta prezent)
        {
            _prezentService.Create(prezent);

            return CreatedAtRoute("GetPrezenta", new { id = prezent.Id.ToString() }, prezent);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Prezenta prezentIn)
        {
            var prezent = _prezentService.Get(id);

            if (prezent == null)
            {
                return NotFound();
            }

            _prezentService.Update(id, prezentIn);

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