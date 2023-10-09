﻿using SQLite;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C971_MobileApp.Models
{
    public enum Type
    {
        ObjectiveAssessment,
        PerformanceAssessment
    }
    [Table("assessment")]
    public class Assessment
    {
        [PrimaryKey, AutoIncrement, Column("Id")]

        public int Id { get; set; }
        public Type TypeName { get; set; }
        public string Name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public Assessment()
        {

        }
        public Assessment(int id, Type typeName, string name, DateTime startDate, DateTime endDate)
        {
            Id = id;
            TypeName = typeName;
            Name = name;
            this.startDate = startDate;
            this.endDate = endDate;
        }
    }
}