using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C971_MobileApp.Models
{
    [Table("course")]
    public class Course
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
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

        public Course(int id, string name, string description, bool status, DateTime startDate, DateTime endDate, int instructorId, string notes, int objectiveAssessment, int performanceAssessment,
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
        public override string ToString()
        {
            if (this.Status)
            {
                return this.Name + " (Active)";
            }
            return this.Name;
        }
    }
}
