using piven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piven.Controllers
{
    public class ScoreStudentController(BD db)
    {
        private BD db = db;
        
        public List<FinalScore> GetFinalScoresByStudent(int studentId)
        {
            List<Student> students = db.GetStudents();
            Student targetStudent = new Student();
            List<FinalScore> scores = new List<FinalScore>();

            foreach (Student student in students)
            {
                if(studentId == student.Id)
                {
                    targetStudent = student;
                }
            }

            foreach(FinalScore finalScores in targetStudent.FinalScores)
            {
                scores.Add(finalScores);
            }

            return scores;
        }


    }
}
