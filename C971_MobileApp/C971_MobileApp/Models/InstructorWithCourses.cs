using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C971_MobileApp.Models
{
    public class InstructorWithCourses
    {
        public Instructor Instructor { get; set; }
        public ObservableCollection<Course> CourseList = new ObservableCollection<Course>(); 

        public InstructorWithCourses()
        { }

        public InstructorWithCourses(Instructor instructor)
        {
            Instructor = instructor;
            List<Course> courses = App.CourseData.GetCoursesByInstructorId(instructor.Id);
            foreach (Course course in courses)
            {
                CourseList.Add(course);
            }
        }
    }
}
