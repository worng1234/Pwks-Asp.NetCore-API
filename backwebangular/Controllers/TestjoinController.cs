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
    public class TestjoinController : Controller
    {
        [HttpGet("GetNewstudentm4")]
        public ActionResult<List<TestJoinTable>> Get()
        {
            var _context = new Dbcontext();
            var Newstudentm4List = (from m4 in _context.new_student_register_m4
                                    join rm4 in _context.register_major_m4 on m4.id_number equals rm4.id_number
                                    select new TestJoinTable()
                                    {
                                        id = m4.id,
                                        name = m4.prename + m4.name + m4.surname,
                                        id_number = m4.id_number,
                                        major_name = rm4.major_name
                                    }).ToList();
            
            return Newstudentm4List;       
        }
    }
}
