using GraduationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Interfaces
{
    public interface IChecks
    {
        List<Requirement> GetValidRequirements(List<Requirement> requirements, List<int> diplomaRequirements);
        bool CheckAllCreditsPassed(List<Requirement> req,List<Course> courses);
        Tuple<bool, STANDING> GetResult(int average);
    }
}
