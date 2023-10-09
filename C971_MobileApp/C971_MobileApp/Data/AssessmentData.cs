using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C971_MobileApp.Models;
using SQLite;

namespace C971_MobileApp.Data
{
    public class AssessmentData
    {
        string dbPath;
        private SQLiteConnection conn;
        public List<Assessment> courseList = new List<Assessment>();

        public AssessmentData()
        {
        }
        public AssessmentData(string dbPath)
        {
            this.dbPath = dbPath;
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
        public void AddAssessment(Assessment assessment)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(assessment);
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
