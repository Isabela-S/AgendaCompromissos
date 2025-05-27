using Microsoft.AspNetCore.Mvc;
using AgendaCompromissosApi.Models;
using System.Collections.Generic;

namespace AgendaCompromissosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompromissoController : ControllerBase
    {
        private static List<Compromisso> compromissos = new List<Compromisso>();
        private static int proximoId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Compromisso>> Get()
        {
            return compromissos;
        }

        [HttpPost]
        public ActionResult<Compromisso> Post(Compromisso compromisso)
        {
            compromisso.Id = proximoId++;
            compromissos.Add(compromisso);
            return CreatedAtAction(nameof(GetById), new { id = compromisso.Id }, compromisso);
        }

        [HttpGet("{id}")]
        public ActionResult<Compromisso> GetById(int id)
        {
            var compromisso = compromissos.Find(c => c.Id == id);
            if (compromisso == null) return NotFound();
            return compromisso;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Compromisso compromissoAtualizado)
        {
            var compromisso = compromissos.Find(c => c.Id == id);
            if (compromisso == null) return NotFound();

            compromisso.Titulo = compromissoAtualizado.Titulo;
            compromisso.Descricao = compromissoAtualizado.Descricao;
            compromisso.Data = compromissoAtualizado.Data;
            compromisso.Local = compromissoAtualizado.Local;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var compromisso = compromissos.Find(c => c.Id == id);
            if (compromisso == null) return NotFound();

            compromissos.Remove(compromisso);
            return NoContent();
        }
    }
}
