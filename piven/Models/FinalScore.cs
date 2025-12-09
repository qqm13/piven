using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piven.Models
{
    public class FinalScore
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int SubjectId { get; set; }
        public int Semester {  get; set; }
        public int Course { get; set; }

    }
}
