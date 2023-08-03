using AutoMapper;
using DesafioApiFilme.Data;
using DesafioApiFilme.Data.Dtos.DtoCidade;
using DesafioApiFilme.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CidadeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaCidade([FromBody] CreateCidadeDto cidadeDto)
        {
            Cidade cidade = _mapper.Map<Cidade>(cidadeDto);
            _context.Cidades.Add(cidade);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCidadePorId), new { id = cidade.CidadeId }, cidade);
        }

        [HttpGet]
        public IEnumerable<ReadCidadeDto> RecuperaCidades([FromQuery] string? enderecoCidade = null)
        {
            if (enderecoCidade == null)
            {
                return _mapper.Map<List<ReadCidadeDto>>(_context.Cidades.ToList());
            }
            return _mapper.Map<List<ReadCidadeDto>>(_context.Cidades
                .Where(cidade => cidade.Endereco
                .Any(endereco => endereco.Cidade.NomeCidade == enderecoCidade)));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCidadePorId(int id)
        {
            var cidade = _context.Cidades.FirstOrDefault(cidade => cidade.CidadeId == id);
            if (cidade == null) return NotFound();

            var cidadeDto = _mapper.Map<ReadCidadeDto>(cidade);
            return Ok(cidadeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCidade(int id, [FromBody] UpdateCidadeDto cidadeDto)
        {
            var cidade = _context.Cidades.FirstOrDefault(cidade => cidade.CidadeId == id);
            if(cidade == null) return NotFound();
            _mapper.Map(cidadeDto, cidade);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCidade(int id)
        {
            var cidade = _context.Cidades.FirstOrDefault(cidade => cidade.CidadeId == id);
            if (cidade == null) return NotFound();
            _context.Remove(cidade);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
