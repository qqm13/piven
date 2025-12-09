using piven.Controllers;
using piven.Models;

namespace piven
{
    public class Program
    {
        public static BD db { get; set; }
        public static AssignmentController AssignmentController { get; set; }
        public static AttendanceController AttendanceController { get; set; }
        public static GroupsController GroupsController { get; set; }
        public static ScoreStudentController ScoreStudentController { get; set; }
        static void Main()
        {
            Setup();

            List<Assignment> assignments = db.GetAssignments();
            int subjId = 1; int teacherId = 1; int groupId = 1; string title = "ggg"; string description = "asd"; DateTime deadline = new DateTime(); int maxScore = 5; string type = "lecture";
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
            AssignmentController.CreateNewAssignment(subjId, teacherId, groupId, title, description, deadline, maxScore, type);
            var list = db.GetAssignments();
            Assignment assignment = list[list.Count - 1];

            Console.WriteLine(assignment.ToString());
            Console.WriteLine(assignment1.ToString());



        }

        public static void Setup()
        {
            db = new BD();
            AssignmentController = new AssignmentController(db);
            AttendanceController = new AttendanceController(db);
            GroupsController = new GroupsController(db);
            ScoreStudentController = new ScoreStudentController(db);

        }
    }
}
