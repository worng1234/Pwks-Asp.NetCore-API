using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backwebangular.Models;

namespace backwebangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoreInformationController : Controller
    {
        private readonly Dbcontext _context;

        public StudentCoreInformationController(Dbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<StudentCoreInformationDB>> Get()
        {
            try
            {
                var studentcore = _context.student_information_core.ToList();
                return Ok(studentcore);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentCoreInformationDB>> GetStudentCoreInformation(int id)
        {
            var studentcore = await _context.student_information_core.FindAsync(id);


            if (studentcore == null)
            {
                return NotFound();
            }

            return studentcore;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutStudentCoreInformationDB(int id, [FromBody] StudentCoreInformationDB studentcoreinformationDB)
        {
            try
            {
                if (id != studentcoreinformationDB.id)
                {
                    return BadRequest();
                }
                _context.Entry(studentcoreinformationDB).State = EntityState.Modified;
                _context.Update(studentcoreinformationDB);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
