using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backwebangular.Models
{
    public partial class RegisterMajorDB
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string major_name { get; set; }
        public virtual Newstudentm4DB Newstudentm4 {get; set;}
    }
}
