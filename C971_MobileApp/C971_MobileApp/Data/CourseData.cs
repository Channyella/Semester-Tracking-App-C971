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
        InstructorData InstructorData;
        AssessmentData AssessmentData;
        private SQLiteConnection conn;
        public List<Course> courseList = new List<Course>();
        public Course defaultCourse = new Course { Id = 1, Name = "Math 1010", Description = "Beginning and Basic Algebra to help students build the fundementals of math.", Status = true, StartDate = DateTime.UtcNow, EndDate = DateTime.Parse("12/31/2023") };

        public CourseData()
        {
            AddDefaultCourse(defaultCourse);
        }
        public CourseData(string dbPath, InstructorData instructorData, AssessmentData assessmentData)
        {
            this.dbPath = dbPath;
            this.InstructorData = instructorData;
            this.AssessmentData = assessmentData;
            AddDefaultCourse(defaultCourse);
        }
        public void Init()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<Course>();
        }
        public void AddDefaultCourse(Course defaultCourse)
        {
            Init();
            if (GetAllCourses().Count < 1)
            {
                int instructorId = InstructorData.GetInstructors()[0].Id;
                defaultCourse.InstructorId = instructorId;
                AssessmentData.AddAssessment(AssessmentData.defaultOA);
                AssessmentData.AddAssessment(AssessmentData.defaultPA);
                defaultCourse.ObjectiveAssessment = AssessmentData.defaultOA.Id;
                defaultCourse.PerformanceAssessment = AssessmentData.defaultPA.Id;
                AddCourse(defaultCourse);
            }
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
        public List<Course> GetActiveCoursesByActiveTerm(Term term)
        {
            Init();
            return conn.Query<Course>("SELECT * FROM course WHERE id IN (?, ?, ?, ?, ?, ?) AND status = 1", term.Course1, term.Course2, term.Course3, term.Course4, term.Course5, term.Course6);
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
