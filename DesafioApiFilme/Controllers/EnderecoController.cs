using AutoMapper;
using DesafioApiFilme.Data;
using DesafioApiFilme.Data.Dtos.DtoEndereco;
using DesafioApiFilme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController: ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RecuperaEnderecos([FromQuery] string? nomeCidade = null)
        {
            if(nomeCidade == null)
            {
                return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos
                    .Include(endereco => endereco.Cidade)
                    .ToList());
            }
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos
                .Include(endereco => endereco.Cidade)
                .Where(endereco => endereco.Cidade.Equals(nomeCidade)));                
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(enderecoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco == null) return NotFound();
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Endereco endereco =_context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco == null) return NotFound();
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}