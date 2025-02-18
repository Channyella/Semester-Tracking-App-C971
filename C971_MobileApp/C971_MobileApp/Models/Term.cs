﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace C971_MobileApp.Models
{
    [Table("term")]
    public class Term
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        // int in Course variables represent courseIds to fill out correct information
        public int Course1 { get; set; }
        public int Course2 { get; set; }
        public int Course3 { get; set; }
        public int Course4 { get; set; }
        public int Course5 { get; set; }
        public int Course6 { get; set; }
        public bool StartDateNotifications { get; set; }
        public DateTime StartDateNotifier { get; set; }
        public bool EndDateNotifications { get; set; }
        public DateTime EndDateNotifier { get; set; }

        public Term()
        {

        }
       
        public Term(int id, string name, int course1, int course2, int course3, int course4, int course5, int course6, DateTime startDate, DateTime endDate, bool active,
            bool startDateNotifications, DateTime startDateNotifier, bool endDateNotifications, DateTime endDateNotifier)
        {
            Id = id;
            Name = name;
            Course1 = course1;
            Course2 = course2;
            Course3 = course3;
            Course4 = course4;
            Course5 = course5;
            Course6 = course6;
            StartDate = startDate;
            EndDate = endDate;
            Active = active;
            StartDateNotifications = startDateNotifications;
            EndDateNotifications = endDateNotifications;
            EndDateNotifier = endDateNotifier;
            StartDateNotifier = startDateNotifier;
        }
    }
}
