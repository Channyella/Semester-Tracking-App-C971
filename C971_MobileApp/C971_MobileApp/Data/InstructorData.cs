using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C971_MobileApp.Models;
using SQLite;

namespace C971_MobileApp.Data
{
    public class InstructorData
    {
        string dbPath;
        private SQLiteConnection conn;
        public List<Instructor> instructorsList = new List<Instructor>();
        //public Instructor[] instructorsList = new Instructor[3];

        public InstructorData(string dbPath) {
            this.dbPath = dbPath;
        }

        public InstructorData()
        {
        }

        public void Init()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<Instructor>();
        }
        public List<Instructor> GetInstructors()
        {
            Init();
            return conn.Table<Instructor>().ToList();
        }
        public Instructor GetInstructorById(int id)
        {
            Init();
            return conn.FindWithQuery<Instructor>("SELECT * FROM instructor WHERE Id = ?", id);
        }
        public void AddInstructor(Instructor instructor)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(instructor);
        }
        public void DeleteInstructor(int id)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new Instructor{ Id = id});
        }
        public void EditInstructor(Instructor instructor)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Update(instructor);
        }
    }
}
