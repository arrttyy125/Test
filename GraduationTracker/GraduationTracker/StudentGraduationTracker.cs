using GraduationTracker.Models;
using System;
using System.Linq;
using GraduationTracker.Interfaces;
using System.Collections.Generic;
using GraduationTracker.Concrete;

namespace GraduationTracker
{
    public partial class StudentGraduationTracker
    {
        private readonly IRepository _repository;
        private readonly IChecks _checks;
        private readonly ICalculation _calculation;
        public StudentGraduationTracker()
        {
             /* 
               It should be done via Dependency Injection. Usually I use autofac library. 
               But because we don't have global.asax file here, I created a new instance.
               */
            _repository = new Repository.Repository();
            _checks = new Checks();
            _calculation = new Calculation();
        }

        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            try
            {
                bool allCreditsPassed = false;
                var average = 0;
                var requirement = new Requirement();
                var requirements = _repository.GetRequirements();
                requirements = _checks.GetValidRequirements(requirements, diploma.Requirements);
                // Another logic which I supposed we need it but we can ignore it based
                // business logic. I supposed we should have all requirements otherwise
                // calculation returns wrong answer. 
                if (requirements?.Count == 0 || requirements.Count < diploma.Requirements.Count)
                {
                    return new Tuple<bool, STANDING>(false, STANDING.NotEnoughRequirements);
                }
                else
                {
                    allCreditsPassed = _checks.CheckAllCreditsPassed(requirements, student.Courses);
                    if (allCreditsPassed == false)
                    {
                        return new Tuple<bool, STANDING>(false, STANDING.None);
                    }
                    else
                    {
                        average = _calculation.GetAverageScore(student.Courses);
                        return _checks.GetResult(average);
                    }
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
