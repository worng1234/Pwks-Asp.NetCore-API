using backwebangular.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backwebangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterMajorController : Controller
    {
        private readonly Dbcontext _context;

        public RegisterMajorController(Dbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<RegisterMajorDB>> Get()
        {
            try
            {
                var registermajor = _context.register_major_m4.ToList();
                return Ok(registermajor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterMajorDB>> GetRegistermajor(int id)
        {
            var registermajor = await _context.register_major_m4.FindAsync(id);


            if (registermajor == null)
            {
                return NotFound();
            }

            return registermajor;
        }

        [HttpPost]
        public async Task<ActionResult<RegisterMajorDB>> PostRegistermajor(RegisterMajorDB registermajor)
        {
            _context.register_major_m4.Add(registermajor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegistermajor), new { id = registermajor.id }, registermajor);
        }

    }
}
