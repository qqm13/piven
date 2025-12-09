using piven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piven.Controllers
{
    public class GroupsController(BD db)
    {
        private BD db = db;
        public List<Student> GetStudentsByGroup(int groupId)
        {
            List<Group> groups = db.GetGroups();
            List<Student> students = new List<Student>();
            Group tagetGroup = new Group();
            foreach(Group group in groups)
            {
                if(groupId == group.Id)
                {
                    tagetGroup = group;
                }
            }

            foreach(Student student in tagetGroup.Students)
            {
                students.Add(student);
            }
            
            return students;
        }

        public List<Lesson> GetLessonsByGroup(int groupId, DateTime date)
        {
            List<Group> groups = db.GetGroups();
            List<Lesson> lessons = new List<Lesson>();
            Group tagetGroup = new Group();
            Schedule targetSchedule = new Schedule();
            foreach (Group group in groups)
            {
                if (groupId == group.Id)
                {
                    tagetGroup = group;
                }
            }

            foreach (Schedule schedule in tagetGroup.Schedules)
            {
                if(date.Year == schedule.Date.Year && date.Month == schedule.Date.Month && date.Day == schedule.Date.Day)
                {
                    targetSchedule = schedule;
                }
            }

            foreach(Lesson lesson in targetSchedule.Lessons)
            {
                lessons.Add(lesson);
            }
            //уроки содержаться в списке по порядку
            return lessons;
        }
    }
}
