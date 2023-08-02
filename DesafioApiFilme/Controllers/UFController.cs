using AutoMapper;
using DesafioApiFilme.Data;
using DesafioApiFilme.Data.Dtos.DtoUF;
using DesafioApiFilme.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UFController: ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public UFController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaUf([FromBody] CreateUfDto ufDto)
        {
            UF uf = _mapper.Map<UF>(ufDto);
            _context.Ufs.Add(uf);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaUfPorId), new { id = uf.UfId }, uf);
        }

        

        [HttpGet("{id}")]
        public IActionResult RecuperaUfPorId(string id)
        {
            var uf = _context.Ufs.FirstOrDefault(uf => uf.UfId == id);
            if(uf == null) return NotFound();
            var ufDto = _mapper.Map<ReadUfDto>(uf);
            return Ok(ufDto);
        }

    }
}
