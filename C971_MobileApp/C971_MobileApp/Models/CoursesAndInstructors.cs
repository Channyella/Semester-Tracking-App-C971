using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace C971_MobileApp.Models
{
    [Table("CourseAndInstructors")]
    public class CoursesAndInstructors
    {
        public int InstructorId { get; set; }
        public string CourseId { get; set; }
    }
}
