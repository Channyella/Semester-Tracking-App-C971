using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C971_MobileApp.Models;

namespace C971_MobileApp.Data
{
    public class InstructorData
    {
        public Instructor[] instructorsList = new Instructor[3];

        public InstructorData() {
            instructorsList[0] = new Instructor("John Doe", "john.doe@wgu.edu", "555-555-5555");
            instructorsList[1] = new Instructor("Jane Poe", "jpoe@wgu.edu", "555-555-5556");
            instructorsList[2] = new Instructor("Felix Melendez", "felixm@wgu.edu", "555-555-5557");
        }
    }
}
