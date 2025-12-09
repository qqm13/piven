using piven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piven.Controllers
{
    public class AttendanceController(BD db)
    {
        private BD db = db;

        public void RegisterAttendance(int groupId, DateTime date, int lessonNumber, int studentId)
        {
            List<Group> groups = db.GetGroups();
            Group targetGroup = new Group();
            Schedule targetSchedule = new Schedule();
            Lesson targetLesson = new Lesson();
            Student targetStudent = new Student();

            foreach (Group group in groups)
            {
               if (group.Id == groupId)
               {
                    targetGroup = group;
               }
            }

            foreach (Student student in targetGroup.Students)
            {
                if (student.Id == studentId)
                {
                    targetStudent = student;
                }
            }

            foreach (Schedule schedule in targetGroup.Schedules)
            {
                if (schedule.Date == date)
                {
                    targetSchedule = schedule;
                }
            }

            for (int i = 0; i < targetSchedule.Lessons.Count; i++)
            {
                if(i == lessonNumber - 1)
                {
                    targetSchedule.Lessons[i].StudentsWere.Add(targetStudent);
                }
            }

            //логика смотрят группу->расписание за нужный день->нужный урок->список присутствующих
        }
    }
}
