using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C971_MobileApp
{
    [Table("instructor")]
    public class Instructor
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Instructor()
        {

        }
        public Instructor(int id, string name, string email, string phoneNumber) 
        { 
            Id = id;
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
