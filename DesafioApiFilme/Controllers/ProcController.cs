using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using DesafioApiFilme.Data;
using DesafioApiFilme.Data.Dtos.DtoProc;
using DesafioApiFilme.Models;
using DesafioApiFilme.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;

namespace DesafioApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcController: ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
     
        public ProcController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[HttpGet("{nome}/{idade}/{cinema}/{filme}/{genero}")]
        //public async Task<IActionResult> RetornaVendas(string? nome, int? idade, string? cinema, string? filme, string? genero)
        //{
        //    var resultado = await (_context.Procs.FromSqlRaw($"ListaInfosVenda {nome}, {idade}, {cinema}, {filme}, {genero}").ToListAsync());
        //    return Ok(resultado);
        //}

        //[HttpGet("{nome}/{idade}/{cinema}/{filme}/{genero}")]
        //public IActionResult RetornaVendasDto(string? nome, int? idade, string? cinema, string? filme, string? genero)
        //{
        //    var resultado = _mapper.Map<ReadProcDto>(_context.Procs.FromSqlRaw($"ListaInfosVenda {nome}, {idade}, {cinema}, {filme}, {genero}").ToList());

        //    return Ok(resultado);
        //}

        [HttpGet("{nome}/{idade}/{cinema}/{filme}/{genero}")]
        public IEnumerable<ReadProcDto> RetornaVendasDto(string? nome, int? idade, string? cinema, string? filme, string? genero)
        {
            var proc = _context.Procs.FromSqlRaw($"ListaInfosVenda {nome}, {idade}, {cinema}, {filme}, {genero}").ToList();

            var resultado = _mapper.Map<List<ReadProcDto>>(proc);

            return resultado;
        }
    }
}
