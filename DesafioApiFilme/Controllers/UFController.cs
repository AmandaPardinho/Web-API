using AutoMapper;
using DesafioApiFilme.Data;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApiFilme.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class UFController: ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;


    }
}
