using AutoMapper;
using DesafioApiFilme.Data;
using DesafioApiFilme.Data.Dtos.DtoGenero;
using DesafioApiFilme.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroController: ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public GeneroController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaGenero([FromBody] CreateGeneroDto generoDto)
        {
            Genero genero = _mapper.Map<Genero>(generoDto);
            _context.Generos.Add(genero);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGeneroPorId), new { id = genero.Id }, generoDto);
        }

        [HttpGet]
        public IEnumerable<ReadGeneroDto> RecuperaGeneros()
        {
            return _mapper.Map<List<ReadGeneroDto>>(_context.Generos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGeneroPorId(int id)
        {
            Genero genero = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if(genero == null) return NotFound();
            var generoDto = _mapper.Map<ReadGeneroDto>(genero);
            return Ok(genero);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaGenero(int id, [FromBody] UpdateGeneroDto generoDto)
        {
            Genero genero = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if(genero == null) return NotFound();
            _mapper.Map(generoDto, genero);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGenero(int id)
        {
            Genero genero = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if(genero == null) return NotFound();
            _context.Remove(genero);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
