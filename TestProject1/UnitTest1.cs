using NUnit.Framework.Constraints;
using NUnit.Framework.Legacy;
using piven.Controllers;
using piven.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestProject1
{
    public class Tests
    {
        public BD db {  get; set; }
        public AssignmentController AssignmentController {  get; set; }
        public AttendanceController AttendanceController { get; set; }
        public GroupsController GroupsController { get; set; }
        public ScoreStudentController ScoreStudentController { get; set; }
        
        [SetUp]
        public void Setup()
        {
            db = new BD();
            AssignmentController = new AssignmentController(db);
            AttendanceController = new AttendanceController(db);
            GroupsController = new GroupsController(db);
            ScoreStudentController = new ScoreStudentController(db);

        }

        [Test]
        public void Test1GetStudentsByGroup()
        {
            int groupId = 1;
            var listAct = GroupsController.GetStudentsByGroup(groupId);
            var listAllStudents = db.GetStudents();
            var listExp = new List<Student>();

            foreach(var student in listAllStudents)
            {
                if(student.GroupId == groupId)
                {
                    listExp.Add(student);
                }
            }

            CollectionAssert.AreEquivalent(listExp, listAct);
        }

        [Test]
        public void Test2GetLessonsByGroup()
        {
            int groupId = 1;
            DateTime date = new DateTime(2025, 12, 9);
            var listAct = GroupsController.GetLessonsByGroup(groupId, date);
            var listAllSched = db.GetSchedules();
            var listExp = new List<Lesson>();

            foreach(var sched in listAllSched)
            {
                if(sched.GroupId == groupId && sched.Date.Year == date.Year && sched.Date.Month == date.Month && sched.Date.Day == date.Day)
                {
                    foreach(Lesson lesson in sched.Lessons)
                    {
                        listExp.Add(lesson);
                    }
                }
            }

            CollectionAssert.AreEquivalent(listExp, listAct);
        }
        [Test]
        public void Test3CreateNewAssignment()
        {
            List<Assignment> assignments = db.GetAssignments();
            int subjId = 1; int teacherId = 1; int groupId = 1; string title = "ggg"; string description = "asd"; DateTime deadline = new DateTime(); int maxScore = 5;  string type = "lecture";
            Assignment assignment1 = new Assignment
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
            AssignmentController.CreateNewAssignment(subjId,teacherId,groupId,title,description,deadline,maxScore,type);
            var list = db.GetAssignments();
            Assignment assignment = list[list.Count-1];

            Assert.That(assignment1.Id.ToString().Equals(assignment.Id.ToString()));
            Assert.That(assignment1.SubjectId.ToString().Equals(assignment.SubjectId.ToString()));
            Assert.That(assignment1.Deadline.ToString().Equals(assignment.Deadline.ToString()));
            Assert.That(assignment1.Description.ToString().Equals(assignment.Description.ToString()));
            Assert.That(assignment1.GroupId.ToString().Equals(assignment.GroupId.ToString()));
            Assert.That(assignment1.Title.ToString().Equals(assignment.Title.ToString()));
            Assert.That(assignment1.MaxPoint.ToString().Equals(assignment.MaxPoint.ToString()));
            Assert.That(assignment1.TeacherId.ToString().Equals(assignment.TeacherId.ToString()));
            Assert.That(assignment1.Type.ToString().Equals(assignment.Type.ToString()));
            //проверка каждое ли свойство было одинаково
        }
        [Test]
        public void Test4GetFinalScoresByStudent()
        {
            int studentId = 1;
            var listAct = ScoreStudentController.GetFinalScoresByStudent(studentId);
            List<Student> list = db.GetStudents();

            var listExp = new List<FinalScore>();

            foreach (var student in list)
            {
                if(studentId == student.Id)
                {
                    foreach(var score in student.FinalScores)
                    {
                        listExp.Add(score);
                    }
                }
            }
            CollectionAssert.AreEquivalent(listExp, listAct);
        }
       
        [Test]
        public void Test5RegisterAttendance()
        {
            int groupId = 1; DateTime date = new DateTime(2025, 12, 9); int lessonNumber = 1; int studentId = 1;

            Lesson les = new Lesson();
            AttendanceController.RegisterAttendance(groupId,date,lessonNumber,studentId);
            var list = db.GetSchedules();
            foreach (var sched in list)
            {
                if(sched.GroupId == groupId && sched.Date.Year == date.Year && sched.Date.Month == date.Month && sched.Date.Day == date.Day)
                {
                    les = sched.Lessons[lessonNumber - 1];
                }
            }

            foreach(Student student in les.StudentsWere)
            {
                if(student.Id == studentId)
                {
                    Assert.Pass();
                }
            }
        }
    }
}
