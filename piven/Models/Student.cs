using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piven.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public int Id { get; set; }
        public int GroupId { get; set; }
        public List<FinalScore> FinalScores { get; set; }

    }
}
