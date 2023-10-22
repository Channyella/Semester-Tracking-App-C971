using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C971_MobileApp.Models;
using Plugin.LocalNotification;
using SQLite;

namespace C971_MobileApp.Data
{
    public class TermData
    {
        string dbPath;
        CourseData CourseData;
        private SQLiteConnection conn;
        public Term defaultTerm = new() { Name = "Term 1", StartDate = DateTime.Now, EndDate = DateTime.Parse("12/31/2023"), Active = true};
        public TermData(string dbPath, CourseData courseData)
        {
            this.dbPath = dbPath;
            this.CourseData = courseData;
            AddDefaultTerm(defaultTerm);
        }

        public TermData()
        {
            AddDefaultTerm(defaultTerm);
        }

        public void Init()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<Term>();
        }
        public NotificationRequest SetStartNotifications(Term term)
        {
            Init();
            NotificationRequest request = new NotificationRequest
            {
                NotificationId = 3000 + term.Id,
                Subtitle = "Term Notification",
                Title = term.Name + " Start Notification",
                Description = term.Name + " starts on " + term.StartDate.ToShortDateString() + ".",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = term.StartDateNotifier,
                }
            };
            return request;
        }
        public NotificationRequest SetEndNotifications(Term term)
        {
            Init();
            NotificationRequest request = new NotificationRequest
            {
                NotificationId = 4000 + term.Id,
                Subtitle = "Term Notification",
                Title = term.Name + "End Notification",
                Description = term.Name + " ends on " + term.EndDate.ToShortDateString() + ".",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = term.EndDateNotifier,
                }
            };
            return request;
        }
        public void AddDefaultTerm(Term defaultTerm)
        {
            Init();
            if (GetAllTerms().Count < 1)
            {
                int courseId = CourseData.GetAllCourses()[0].Id;
                defaultTerm.Course1 = courseId;
                AddTerm(defaultTerm);
            }
        }
        public List<Term> GetAllTerms()
        {
            Init();
            return conn.Table<Term>().ToList();
        }
        public Term GetTermById(int id)
        {
            Init();
            return conn.FindWithQuery<Term>("SELECT * FROM term WHERE Id = ?", id);
        }
        public Term GetActiveTerm() 
        { 
            Init();
            return conn.FindWithQuery<Term>("SELECT * FROM term WHERE active = 1");
        }
        public Term AddTerm(Term term)
        {
            if (term.Active)
            {
                DeactivateAllTerms();
            }
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(term);
            return term;
        }
        public void DeleteTerm(int id)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new Term { Id = id });
        }
        public void EditTerm(Term term)
        {
            if(term.Active)
            {
                DeactivateAllTerms();
            }
            conn = new SQLiteConnection(this.dbPath);
            conn.Update(term);
        }
        private void DeactivateAllTerms()
        {
            Init();
            Term activeTerm = conn.FindWithQuery<Term>("SELECT * FROM term WHERE active = 1");
            if (activeTerm != null)
            {
                activeTerm.Active = false;
                conn.Update(activeTerm);
            }
        }
        public void ActivateTerm(Term term)
        {
            Init();
            DeactivateAllTerms();
            term.Active = true;
            conn.Update(term);
        }
    }
}
