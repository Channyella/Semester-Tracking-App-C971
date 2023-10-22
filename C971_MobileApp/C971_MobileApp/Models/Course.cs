using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C971_MobileApp.Models
{
    public enum Status
    {
        InProgress,
        Completed,
        Dropped,
        PlanToTake
    }
    [Table("course")]
    public class Course
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int InstructorId { get; set; }
        public string CourseNotes { get; set; }
        public int ObjectiveAssessment { get; set; }
        public int PerformanceAssessment { get; set; }
        public bool StartDateNotifications { get; set; }
        public DateTime StartDateNotifier { get; set; }
        public bool EndDateNotifications { get; set; }
        public DateTime EndDateNotifier { get; set; }


        public Course()
        { }

        public Course(int id, string name, string description, Status status, DateTime startDate, DateTime endDate, int instructorId, string notes, int objectiveAssessment, int performanceAssessment,
            bool startDateNotifications, DateTime startDateNotifier, bool endDateNotifications, DateTime endDateNotifier)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = status;
            StartDate = startDate;
            EndDate = endDate;
            InstructorId = instructorId;
            CourseNotes = notes;
            ObjectiveAssessment = objectiveAssessment;
            PerformanceAssessment = performanceAssessment;
            StartDateNotifications = startDateNotifications;
            EndDateNotifications = endDateNotifications;
            EndDateNotifier = endDateNotifier;
            StartDateNotifier = startDateNotifier;

        }
        public static string GetStatusName(Status status)
        {
            Dictionary<Status, string> CourseStatus = new Dictionary<Status, string>
                {
                    {Status.InProgress, "In Progress" }, {Status.Completed , "Completed"},
                    {Status.Dropped , "Dropped"}, {Status.PlanToTake, "Plan to Take"}
                };
            return CourseStatus[status];
        }
        public static Status GetStatusFromName(string name)
        {
            Dictionary<string, Status> CourseStatus = new Dictionary<string, Status>
            {
                {"In Progress", Status.InProgress }, {"Completed", Status.Completed },
                {"Dropped", Status.Dropped }, {"Plan to Take", Status.PlanToTake}
            };
            return CourseStatus[name];
        }
        public static ObservableCollection<string> GetStatusList()
        {
            return new ObservableCollection<string> { "In Progress", "Completed", "Dropped", "Plan to Take" };
        }
        public override string ToString()
        {
            return this.Name + " (" + GetStatusName(Status) + ")";
        }
    }
}
