﻿using SQLite;
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
            public int InstructorId { get; set; }
            public string Notes { get; set; }
            public int Assessment1 { get; set; }
            public int Assessment2 { get; set; }

            public Courses()
            { }

            public Courses(int id, string name, string description, bool status, DateTime startDate, DateTime endDate, int instructorId, string notes)
            {
                Id = id;
                Name = name;
                Description = description;
                Status = status;
                StartDate = startDate;
                EndDate = endDate;
                InstructorId = instructorId;
                Notes = notes;
            }
        }
    }
}
