using educacionit.cursowebapi.clase3.EFCore;
using educacionit.cursowebapi.clase3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace educacionit.cursowebapi.clase3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : BaseController<Shipper, ShipperRepository>
    {
        public EnviosController(ShipperRepository repository) : base(repository)
        {
        }
    }
}
