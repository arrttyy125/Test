using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Models
{
    public class Student
    {
        public int Id { get; set; }
        public List<Course> Courses { get; set; }
        public STANDING Standing { get; set; } = STANDING.None;
    }
}
