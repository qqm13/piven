using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piven.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeSpeciality { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Schedule> Schedules { get; set; } = new List<Schedule> ();
    }
}
