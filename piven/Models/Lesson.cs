using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piven.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public List<Student> StudentsWere { get; set; } = new List<Student>();

    }
}
