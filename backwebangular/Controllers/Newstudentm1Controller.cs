using backwebangular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;

namespace backwebangular.Controllers
{ 
        [Route("api/[controller]")]
        [ApiController]
        public class Newstudentm1Controller : Controller
        {
            private readonly Dbcontext _context;

            public Newstudentm1Controller(Dbcontext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Newstudentm1DB>>> GetNewstudentm1()
            {
                return await _context.new_student_register_m1.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Newstudentm1DB>> GetNewstudentm1(int id)
            {
                var newstudentm1 = await _context.new_student_register_m1.FindAsync(id);
                if (newstudentm1 == null)
                {
                    return NotFound();
                }
                return newstudentm1;
            }

            [HttpPost]
            public async Task<ActionResult<Newstudentm1DB>> PostNewstudentm1(Newstudentm1DB newstudentm1)
            {
                _context.new_student_register_m1.Add(newstudentm1);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetNewstudentm1), new { id = newstudentm1.id }, newstudentm1);
            }

           

            [HttpPut("{id}")]
            public async Task<IActionResult> PutNewstudentm1(int id, Newstudentm1DB newstudentm1)
            {
                if (id != newstudentm1.id)
                {
                    return BadRequest();
                }

                _context.Entry(newstudentm1).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Newstudentm1Exists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteNewstudentm1DB(int id)
            {
                var newstudentm1DB = await _context.new_student_register_m1.FindAsync(id);
                if (newstudentm1DB == null)
                {
                    return NotFound();
                }
                _context.new_student_register_m1.Remove(newstudentm1DB);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool Newstudentm1Exists(int id)
            {
                return _context.new_student_register_m1.Any(e => e.id == id);
            }

        }
}



