using Microsoft.AspNetCore.Mvc;
using EleicaoBrasilApi.Data;
using EleicaoBrasilApi.Models;
using System.Linq;

namespace EleicaoBrasilApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CandidatosController(AppDbContext context)
        {
            _context = context;
        }

        // GET todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Candidatos.ToList());
        }

        // GET por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var candidato = _context.Candidatos.Find(id);

            if (candidato == null)
                return NotFound();

            return Ok(candidato);
        }

        // 🔎 GET por partido (atividade 5)
        [HttpGet("partido/{nomeDoPartido}")]
        public IActionResult GetPorPartido(string nomeDoPartido)
        {
            var candidatos = _context.Candidatos
                .Where(c => c.Partido == nomeDoPartido)
                .ToList();

            return Ok(candidatos);
        }

        // ➕ POST com validação (atividade 4)
        [HttpPost]
        public IActionResult Post(Candidato novoCandidato)
        {
            if (_context.Candidatos.Any(c => c.Numero == novoCandidato.Numero))
            {
                return BadRequest("Número já cadastrado");
            }

            _context.Candidatos.Add(novoCandidato);
            _context.SaveChanges();

            return Ok(novoCandidato);
        }

        // ✏️ PUT (atividade 3 - atualizar ViceNome)
        [HttpPut("{id}")]
        public IActionResult Put(int id, Candidato candidatoAtualizado)
        {
            var candidato = _context.Candidatos.Find(id);

            if (candidato == null)
                return NotFound();

            candidato.Nome = candidatoAtualizado.Nome;
            candidato.Partido = candidatoAtualizado.Partido;
            candidato.Numero = candidatoAtualizado.Numero;
            candidato.ViceNome = candidatoAtualizado.ViceNome;

            _context.SaveChanges();

            return NoContent();
        }

        // ❌ DELETE (atividade 6)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var candidato = _context.Candidatos.Find(id);

            if (candidato == null)
                return NotFound();

            _context.Candidatos.Remove(candidato);
            _context.SaveChanges();

            return NoContent();
        }
    }
}