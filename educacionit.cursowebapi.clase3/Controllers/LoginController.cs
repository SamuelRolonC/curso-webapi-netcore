using educacionit.cursowebapi.clase3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace educacionit.cursowebapi.clase3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly NorthwindContext _context;

        public LoginController(IConfiguration configuration
            , NorthwindContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            var usuarioAutenticado = FuncionesToken.AutenticarUsuario(usuario, _context);

            if (usuarioAutenticado != null)
            {

                return Ok(new { token = FuncionesToken.GenerarToken(usuario, _configuration) });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
