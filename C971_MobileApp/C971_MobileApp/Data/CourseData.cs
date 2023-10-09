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
        public List<Courses> courseList = new List<Courses>();

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
        public void AddCourse(Course course)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(course);
        }
        public void DeleteCourse(int id)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new Courses { Id = id });
        }
        public void EditCourse(Course course)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Update(course);
        }
    }
}
