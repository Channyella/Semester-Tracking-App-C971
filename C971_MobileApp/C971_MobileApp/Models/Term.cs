using SQLite;
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

        public Term()
        {

        }
       
        public Term(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
