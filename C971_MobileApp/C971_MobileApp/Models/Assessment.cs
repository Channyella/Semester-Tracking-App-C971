using SQLite;
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
        public DateTime dueDate { get; set; }
        public bool StartDateNotifications { get; set; }
        public DateTime StartDateNotifier { get; set; }
        public bool EndDateNotifications { get; set; }
        public DateTime EndDateNotifier { get; set; }

        public Assessment()
        {

        }
        public Assessment(int id, Type typeName, string name, DateTime startDate, DateTime endDate, DateTime dueDate,
            bool startDateNotifications, DateTime startTimeNotifier, bool endDateNotifications, DateTime endTimeNotifier)
        {
            Id = id;
            TypeName = typeName;
            Name = name;
            this.startDate = startDate;
            this.endDate = endDate;
            this.dueDate = dueDate;
            StartDateNotifications = startDateNotifications;
            this.StartDateNotifier = startTimeNotifier;
            EndDateNotifications = endDateNotifications;
            EndDateNotifier = EndDateNotifier;
        }
    }
}
