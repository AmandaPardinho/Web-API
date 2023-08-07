using AutoMapper;
using DesafioApiFilme.Data;
using DesafioApiFilme.Data.Dtos.DtoCliente;
using DesafioApiFilme.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public ClienteController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaCliente([FromBody] CreateClienteDto clienteDto)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDto);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaClientePorId), new { id = cliente.Id }, cliente);
        }

        [HttpGet]
        public IEnumerable<ReadClienteDto> RecuperaClientes()
        {
            return _mapper.Map<List<ReadClienteDto>>(_context.Clientes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaClientePorId(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null) return NotFound();

            var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
            return Ok(clienteDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if(cliente == null) return NotFound();
            _mapper.Map(clienteDto, cliente);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if(cliente == null) return NotFound();
            _context.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
