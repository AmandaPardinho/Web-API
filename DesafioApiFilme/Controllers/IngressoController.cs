using AutoMapper;
using DesafioApiFilme.Data;
using DesafioApiFilme.Data.Dtos.DtoIngresso;
using DesafioApiFilme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngressoController: ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public IngressoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaIngresso([FromBody] CreateIngressoDto ingressoDto)
        {
            Ingresso ingresso = _mapper.Map<Ingresso>(ingressoDto);
            _context.Ingressos.Add(ingresso);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaIngressoPorId), new {id = ingresso.Id} , ingresso);
        }

        [HttpGet]
        public IEnumerable<ReadIngressoDto> RecuperaIngressos([FromQuery] int? ingressoSessao = null)
        {
            if(ingressoSessao == null)
            {
                return _mapper.Map<List<ReadIngressoDto>>(_context.Ingressos
                    .Include(ingresso => ingresso.ClienteId)
                    .ToList());
            }
            return _mapper.Map<List<ReadIngressoDto>>(_context.Ingressos
                .Include(ingresso => ingresso.ClienteId)
                .Where(ingresso => ingresso.SessaoId == ingressoSessao));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaIngressoPorId(int id)
        {
            var ingresso = _context.Ingressos
                .Include(ingresso => ingresso.ClienteId)
                .FirstOrDefault(ingresso => ingresso.Id == id);
            if(ingresso == null) return NotFound();

            var ingressoDto = _mapper.Map<ReadIngressoDto>(ingresso);
            return Ok(ingressoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaIngresso(int id, [FromQuery] UpdateIngressoDto ingressoDto)
        {
            var ingresso = _context.Ingressos.FirstOrDefault(ingresso => ingresso.Id == id);
            if (ingresso == null) return NotFound();
            _mapper.Map(ingressoDto, ingresso);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaIngresso(int id) 
        {
            var ingresso = _context.Ingressos.FirstOrDefault(ingresso => ingresso.Id == id);
            if (ingresso == null) return NotFound();
            _context.Remove(ingresso);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
