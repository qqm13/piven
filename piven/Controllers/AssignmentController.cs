using piven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piven.Controllers
{
    public class AssignmentController(BD db)
    {
        private BD db = db;
    
        public void CreateNewAssignment(int subjId, int teacherId, int groupId, string title, string description, DateTime deadline, int maxScore,string type)
        {
            List<Assignment> assignments = db.GetAssignments();
            Assignment assignment = new Assignment
            {
                SubjectId = subjId,
                Deadline = deadline,
                Description = description,
                GroupId = groupId,
                Title = title,
                MaxPoint = maxScore,
                TeacherId = teacherId,
                Type = type,
                Id = assignments.Count + 1
            };
            assignments.Add(assignment);
            List<Subject> subjects = db.GetSubjects();
            foreach (Subject subject in subjects)
            {
                if(subject.Id == subjId)
                {
                    subject.Assignments.Add(assignment);
                }
            }

        }
    }
}
