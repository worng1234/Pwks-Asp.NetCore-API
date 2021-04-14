using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backwebangular.Models
{
    public class TestJoinTable
    {
        public int id { get; set; }
        public string name { get; set; }
        public string id_number { get; set; }
        public string major_name { get; set; }
        public ICollection<RegisterMajorDB> register_major_m4 { get; set; }

    }
}
