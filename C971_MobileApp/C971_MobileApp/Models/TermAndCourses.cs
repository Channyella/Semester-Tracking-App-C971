using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C971_MobileApp.Models
{
    [Table("TermsAndCourses")]
    public class TermAndCourses
    {
        public int TermId { get; set; }
        public int Courses { get; set; }
        public bool Active { get; set; }
    }
}
