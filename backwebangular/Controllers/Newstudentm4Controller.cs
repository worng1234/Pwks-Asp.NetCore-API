using backwebangular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backwebangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Newstudentm4Controller : Controller
    {
        private readonly Dbcontext _context;

        public Newstudentm4Controller(Dbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Newstudentm4DB>> Get()
        {
            try
            {
                var newstudentm4 = _context.new_student_register_m4.ToList();
                return Ok(newstudentm4);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Newstudentm4DB>> GetNewstudentm4(int id)
        {
            var newstudentm4 = await _context.new_student_register_m4.FindAsync(id);


            if (newstudentm4 == null)
            {
                return NotFound();
            }

            return newstudentm4;
        }

        [HttpPost]
        public async Task<ActionResult<Newstudentm4DB>> PostNewstudentm4DB(Newstudentm4DB newstudentm4DB)
        {
            _context.new_student_register_m4.Add(newstudentm4DB);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNewstudentm4), new { id = newstudentm4DB.id }, newstudentm4DB);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutNewstudentm4DB(int id, [FromBody] Newstudentm4DB newstudentm4DB)
        {
            try
            {
                if(id != newstudentm4DB.id)
                {
                    return BadRequest();
                }
                _context.Entry(newstudentm4DB).State = EntityState.Modified;
                _context.Update(newstudentm4DB);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNewstudentm4DB(int id)
        {
            var newstudentm4DB = await _context.new_student_register_m4.FindAsync(id);
            if (newstudentm4DB == null)
            {
                return BadRequest();
            }
            _context.new_student_register_m4.Remove(newstudentm4DB);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

