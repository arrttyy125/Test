using GraduationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Interfaces
{
    public interface IStudentGraduationTracker
    {
        Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student);
        int GetAverageScore(Student student);
        int GetTotalCredit(int average);
        bool IsPrerequisitCoursePassed();
        
    }
}
