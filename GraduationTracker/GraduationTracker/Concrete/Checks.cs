using GraduationTracker.Interfaces;
using GraduationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Concrete
{
    public class Checks : IChecks
    {
        public List<Requirement> GetValidRequirements(List<Requirement> requirements, List<int> diplomaRequirements)
        {
            try
            {
                var requirement = new Requirement();
                foreach (var item in diplomaRequirements)
                {
                    requirement = requirements.Where(r => r.Id == item).FirstOrDefault();
                    if (requirement == null)
                    {
                        requirements.Remove(requirement);
                    }
                }
                return requirements;
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
        // for getting diploma all 4 credits must be passed. 
        // If not, I should know what is business logic. prevent of calculating average
        // because the student is failed or caclulate the average in any way. I think when a student
        // is failed, there is not requirement to have average score and standing. it's just for
        // successful students. Therefore i implemented it based on that.
        public bool CheckAllCreditsPassed(List<Requirement> requirements, List<Course> studentCourses)
        {
            try
            {
                int creditCount = 0;
                foreach (var item in studentCourses)
                {
                    var req = requirements.Where(r => r.Courses.Contains(item.Id)).FirstOrDefault();
                    creditCount += req?.MinimumMark <= item.Mark ? 1 : 0;
                }
                return creditCount == requirements.Count;
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
        public Tuple<bool, STANDING> GetResult(int average)
        {
            try
            {
                var standing = STANDING.None;
                switch (average)
                {
                    case int x when (x < 50):
                        standing = STANDING.Remedial;
                        break;
                    case int x when (x >= 50 && x < 80):
                        standing = STANDING.Average;
                        break;
                    case int x when (x >= 80 && x < 95):
                        standing = STANDING.MagnaCumLaude;
                        break;
                    default:
                        standing = STANDING.SumaCumLaude;
                        break;
                }
                switch (standing)
                {
                    case STANDING.Remedial:
                        return new Tuple<bool, STANDING>(false, standing);
                    case STANDING.Average:
                        return new Tuple<bool, STANDING>(true, standing);
                    case STANDING.SumaCumLaude:
                        return new Tuple<bool, STANDING>(true, standing);
                    case STANDING.MagnaCumLaude:
                        return new Tuple<bool, STANDING>(true, standing);

                    default:
                        return new Tuple<bool, STANDING>(false, standing);
                }
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
