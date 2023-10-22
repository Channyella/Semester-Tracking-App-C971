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
    public class AssessmentData
    {
        string dbPath;
        private SQLiteConnection conn;
        public List<Assessment> courseList = new List<Assessment>();
        public Assessment defaultOA = new Assessment { Id = 1, TypeName = Models.Type.ObjectiveAssessment, Name = "Math 1010 OA", startDate = DateTime.UtcNow, endDate = DateTime.Parse("12/31/2023"), dueDate = DateTime.Parse("12/31/2023") };
        public Assessment defaultPA = new Assessment { Id = 2, TypeName = Models.Type.PerformanceAssessment, Name = "Math 1010 PA", startDate = DateTime.UtcNow, endDate = DateTime.Parse("12/31/2023"), dueDate = DateTime.Parse("12/31/2023") };

        public AssessmentData()
        {
        }
        public AssessmentData(string dbPath)
        {
            this.dbPath = dbPath;
        }
        public NotificationRequest SetStartNotifications(Assessment assessment)
        {
            Init();
            NotificationRequest request = new NotificationRequest
            {
                NotificationId = 3000 + assessment.Id,
                Subtitle = "Assessment Notification",
                Title = assessment.Name + " Start Notification",
                Description = assessment.Name + " starts on " + assessment.startDate.ToShortDateString() + ".",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = assessment.StartDateNotifier,
                }
            };
            return request;
        }
        public NotificationRequest SetEndNotifications(Assessment assessment)
        {
            Init();
            NotificationRequest request = new NotificationRequest
            {
                NotificationId = 4000 + assessment.Id,
                Subtitle = "Assessment Notification",
                Title = assessment.Name + "End Date",
                Description = assessment.Name + " ends on " + assessment.endDate.ToShortDateString() + ".",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = assessment.EndDateNotifier,
                }
            };
            return request;
        }
        public void Init()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<Assessment>();
        }
        public List<Assessment> GetAllAssessments()
        {
            Init();
            return conn.Table<Assessment>().ToList();
        }
        public Assessment GetAssessmentById(int id)
        {
            Init();
            return conn.FindWithQuery<Assessment>("SELECT * FROM assessment WHERE Id = ?", id);
        }
        public Assessment AddAssessment(Assessment assessment)
        {
            Init();
            conn.Insert(assessment);
            return assessment;
        }
        public void DeleteAssessment(int id)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new Assessment { Id = id });
        }
        public void EditAssessment(Assessment assessment)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Update(assessment);
        }
    }
}
