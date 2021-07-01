using educacionit.cursowebapi.clase3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace educacionit.cursowebapi.clase3.Controllers
{
    [Route("api/[controller]")]
    public class ShippersController : Controller
    {
        private readonly NorthwindContext _context;

        public ShippersController(NorthwindContext context)
        {
            _context = context;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IEnumerable<Shipper>> GetAll()
        {
            var listShippers = from sh in _context.Shippers select sh;

            return await listShippers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shipper>> GetByid(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);

            if (shipper == null)
                return NotFound();
            else
                return Ok(shipper);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]Shipper shipper)
        {
            try
            {
                _context.Shippers.Add(shipper);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
