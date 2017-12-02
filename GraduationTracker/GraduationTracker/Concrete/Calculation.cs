using GraduationTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Concrete
{
    public class Calculation : ICalculation
    {
        public int GetAverageScore(List<Course> studentCourses)
        {
            try
            {
                return(int)studentCourses.Average(r => r.Mark);
            }
            catch (Exception ex)
            {

                /* 
                  Logging Exception via 3rd parties like Logentries or 
                  traditional ways like file or database 
                */
                throw;
            }
        }
    }
}
