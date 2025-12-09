using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piven.Models
{
    public class BD
    {
        public List<Group> Groups {  get; set; } = new List<Group>();
        public List<Student> Students {  get; set; } = new List<Student>();
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
        public List<FinalScore> FinalScores { get; set; } = new List<FinalScore>();
        public BD() 
        {
            FinalScores.Add(new FinalScore
            {
                Score = 5,
                Course = 1,
                Id = 1,
                Semester = 1,
                SubjectId = 1,
            });
            Students.Add(new Student
            {
                Id = 1,
                FirstName = "TestFirstNameStudent",
                SecondName = "TestSecondNameStudent",
                LastName = "TestLastNameStudent",
                GroupId = 1,
                FinalScores = new List<FinalScore> { FinalScores[0] },
            });
            Assignments.Add(new Assignment
            {
                Id = 1,
                Deadline = new DateTime(2025,12,10),
                Description = "TestDescription",
                SubjectId = 1,
                GroupId= 1,
                MaxPoint = 5,
                TeacherId = 1,
                Title = "Контролер к апи и тесты",
                Type = "Практическое задание на компьютерах"
            });
            Subjects.Add(new Subject
            {
                Id = 1,
                Title = "TestSubj",
                Assignments = new List<Assignment> { Assignments[0] },
            });
            Lessons.Add(new Lesson
            {
                Id = 1,
                Name = "Practice1group",
            });
            Lessons.Add(new Lesson
            {
                Id = 2,
                Subject = Subjects[0],
                Name = "Practice2group"
            });
            Schedules.Add(new Schedule
            {
                Id = 1,
                Date = new DateTime(2025, 12, 9),
                GroupId = 1,
                Lessons = new List<Lesson> { Lessons[0], Lessons[1] }
            });
            Groups.Add(new Group
            {
                Id = 1,
                CodeSpeciality = "22.22.2222",
                Name = "GroupT",
                Students = new List<Student> { Students[0] },
                Schedules = new List<Schedule> {Schedules[0] }

            });
        }

        public List<Group> GetGroups()
        {
            return Groups;
        }
        public List<Student> GetStudents() 
        {
            return Students;
        }
        public List<Lesson> GetLessons() 
        {
            return Lessons; 
        }
        public List<Schedule> GetSchedules() 
        { 
            return Schedules; 
        }
        public List<Teacher> GetTeachers() 
        { 
            return Teachers; 
        }
        public List<Subject> GetSubjects()
        { 
            return Subjects; 
        }
        public List<Assignment> GetAssignments()
        {
            return Assignments; 
        }
        public List<FinalScore> GetFinalScores()
        {
            return FinalScores;
        }
    }
}
