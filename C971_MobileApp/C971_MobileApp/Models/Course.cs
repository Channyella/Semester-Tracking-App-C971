using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C971_MobileApp.Models
{
    public class Course
    {
        [Table("course")]
        public class Courses
        {
            [PrimaryKey, AutoIncrement, Column("Id")]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool Status { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string CourseInstructor { get; set; }
            public string Notes { get; set; }

            public Courses()
            { }

            public Courses(int id, string name, string description, bool status, DateTime startDate, DateTime endDate, string courseInstructor, string notes)
            {
                Id = id;
                Name = name;
                Description = description;
                Status = status;
                StartDate = startDate;
                EndDate = endDate;
                CourseInstructor = courseInstructor;
                Notes = notes;
            }
        }
    }
}
