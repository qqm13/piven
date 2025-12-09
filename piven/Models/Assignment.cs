using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piven.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public DateTime Deadline { get; set; }
        public int MaxPoint { get; set; }
        public string Type { get; set; }
    }
}
