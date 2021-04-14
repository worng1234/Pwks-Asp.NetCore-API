using backwebangular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//
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
        public ActionResult<List<Newstudentm1DB>> Get()
        {
            try
            {
                var listNewstudentm1 = _context.new_student_register_m1.ToList();
                return Ok(listNewstudentm1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Newstudentm1DB> Get(int id)
        {
            try
            {
                var Newstudentm1 = _context.new_student_register_m1.Find(id);
                if (Newstudentm1 == null)
                {
                    return NotFound();
                }
                return Ok(Newstudentm1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Newstudentm1DB Newstudentm1)
        {
            try
            {
                _context.Add(Newstudentm1);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Newstudentm1DB Newstudentm1)
        {
            try
            {
               if (id != Newstudentm1.id)
                {
                    return BadRequest();
                }
                _context.Entry(Newstudentm1).State = EntityState.Modified;
                _context.Update(Newstudentm1);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNewstudentm1DB(int id)
        {
            var newstudentm1DB = await _context.new_student_register_m1.FindAsync(id);
            if (newstudentm1DB == null)
            {
                return BadRequest();
            }
            _context.new_student_register_m1.Remove(newstudentm1DB);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
