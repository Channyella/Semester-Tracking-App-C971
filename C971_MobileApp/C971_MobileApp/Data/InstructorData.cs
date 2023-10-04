﻿using System;
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
        public Instructor[] instructorsList = new Instructor[3];

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
        public void AddInstructor(Instructor instructor)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(instructor);
        }
        public void DeleteInstructor(int id)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new { Id = id});
        }
        //instructorsList[0] = new Instructor("John Doe", "john.doe@wgu.edu", "555-555-5555");
        //instructorsList[1] = new Instructor("Jane Poe", "jpoe@wgu.edu", "555-555-5556");
        //instructorsList[2] = new Instructor("Felix Melendez", "felixm@wgu.edu", "555-555-5557");
    }
}
