using C971_MobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C971_MobileApp.Models.Course;

namespace C971_MobileApp.Data
{
    public class CourseData
    {
        string dbPath;
        private SQLiteConnection conn;
        public List<Course> courseList = new List<Course>();

        public CourseData()
        {
        }
        public CourseData(string dbPath)
        {
            this.dbPath = dbPath;
        }
        public void Init()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<Course>();
        }
        public List<Course> GetAllCourses()
        {
            Init();
            return conn.Table<Course>().ToList();
        }
        public Course GetCourseById(int id)
        {
            Init();
            return conn.FindWithQuery<Course>("SELECT * FROM course WHERE Id = ?", id);
        }
        public Course GetActiveCoursesByActiveTerm(int id)
        {
            Init();
            return conn.FindWithQuery<Course>("SELECT course.id FROM course JOIN term AS t ON course.id IN (t.course1, t.course2, t.course3, t.course4, t.course5, t.course6) WHERE t.active = 1 AND course.status = 1");
        }
        public Course AddCourse(Course course)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(course);
            return course;
        }
        public void DeleteCourse(int id)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new Course { Id = id });
        }
        public void EditCourse(Course course)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Update(course);
        }
        public List<Course> GetCoursesByInstructorId(int id)
        {
            Init();
            return conn.Query<Course>("SELECT * FROM course WHERE InstructorId = ?", id);
        }
    }
}
