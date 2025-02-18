﻿using C971_MobileApp.Models;
using Plugin.LocalNotification;
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
        Course course;
        InstructorData InstructorData;
        AssessmentData AssessmentData;
        private SQLiteConnection conn;
        public List<Course> courseList = new List<Course>();
        public Course defaultCourse = new Course { Id = 1, Name = "Math 1010", Description = "Beginning and Basic Algebra to help students build the fundamentals of math.", Status = Status.InProgress, StartDate = DateTime.UtcNow, EndDate = DateTime.Parse("12/31/2023") };

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
        
        public NotificationRequest SetStartNotifications(Course course)
        {
            Init();
            NotificationRequest request = new NotificationRequest
            {
                NotificationId = 1000 + course.Id,
                Subtitle = "Course Notification",
                Title = "Starting " + course.Name,
                Description = course.Name + " starts on " + course.StartDate.ToShortDateString() + ".",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = course.StartDateNotifier,
                }
            };
            return request;
        }
        public NotificationRequest SetEndNotifications(Course course)
        {
            Init();
            NotificationRequest request = new NotificationRequest
            {
                NotificationId = 2000 + course.Id,
                Subtitle = "Course Notification",
                Title = course.Name + " End Date",
                Description = course.Name + " ends on " + course.EndDate.ToShortDateString() + ".",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = course.EndDateNotifier,
                }
            };
            return request;
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
            return conn.Query<Course>("SELECT * FROM course WHERE id IN (?, ?, ?, ?, ?, ?) AND status = 0", term.Course1, term.Course2, term.Course3, term.Course4, term.Course5, term.Course6);
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
            int[] IDsToCancel = { id + 1000, id + 2000 };
            LocalNotificationCenter.Current.Cancel(IDsToCancel);
            Course currentCourse = App.CourseData.GetCourseById(id);
            if (currentCourse == null)
            {
                return;
            }
            Assessment assessmentOA = App.AssessmentData.GetAssessmentById(currentCourse.ObjectiveAssessment);
            if (assessmentOA != null)
            {
                App.AssessmentData.DeleteAssessment(currentCourse.ObjectiveAssessment);
            }
            Assessment assessmentPA = App.AssessmentData.GetAssessmentById(currentCourse.PerformanceAssessment);
            if (assessmentPA != null)
            {
                App.AssessmentData.DeleteAssessment(currentCourse.PerformanceAssessment);
            }
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
