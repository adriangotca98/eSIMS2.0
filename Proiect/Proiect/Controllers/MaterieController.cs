using Proiect.Models;
using Proiect.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterieController : ControllerBase
    {
        private readonly MaterieService materieService;

        public MaterieController(MaterieService materieService)
        {
            this.materieService = materieService;
        }

        [HttpGet]
        public ActionResult<List<Materie>> Get() =>
            materieService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMaterie")]
        public ActionResult<Materie> Get(string id)
        {
            var materie = materieService.Get(id);

            if (materie == null)
            {
                return NotFound();
            }

            return materie;
        }

        [HttpPost]
        public ActionResult<Materie> Create(Materie materie)
        {
            materieService.Create(materie);

            return CreatedAtRoute("GetMaterie", new { id = materie.Id.ToString() }, materie);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Materie materieIn)
        {
            var materie = materieService.Get(id);

            if (materie == null)
            {
                return NotFound();
            }

            materieService.Update(id, materieIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var materie = materieService.Get(id);

            if (materie == null)
            {
                return NotFound();
            }

            materieService.Remove(materie.Id);

            return NoContent();
        }

    }
}
