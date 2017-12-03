using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Models;
using Moq;
using GraduationTracker.Interfaces;
using GraduationTracker.Concrete;

namespace GraduationTracker.Tests.Unit
{
    // Separating of concerns by using Single Responsibility pattern
    // And Interface Segregation principle plus repository pattern
    // and Dependency Injection makes unit testing and maintaing
    // application much easier. 
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasCredits()
        {
            var tracker = new StudentGraduationTracker();

            Diploma diploma = GetDiploma();
            List<Student> students = GetStudents();
            
            var graduated = new List<Tuple<bool, STANDING>>();

            foreach(var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));      
            }
            
            Assert.IsFalse(graduated.Where(r=>r.Item2 == STANDING.Remedial).Any());
            Assert.IsTrue(graduated.Where(r => r.Item2 != STANDING.Remedial).Any());
            Assert.IsTrue(graduated.Where(r => r.Item2 != STANDING.NotEnoughRequirements).Any());
            // Testing fails here because there is 1 student who has
            // at least a score less than 50. The previous logic was wrong.
            // it was checking scores more than 50 not more than and equal.
            Assert.IsFalse(graduated.Where(r => r.Item2 == STANDING.None).Any());

        }
        [TestMethod]
        public void TestCredits()
        {
            // Using Moq for testing individual components. we can repeat this test
            // for all other components.
             
            var mockCredits = new Mock<IChecks>();
            IRepository IRepository = new Repository.Repository();
            List<Requirement> requirements = IRepository.GetRequirements();
            List<Course> courses = GetCourseData();
            mockCredits.Setup(credit => credit.CheckAllCreditsPassed(It.IsAny<List<Requirement>>(), It.IsAny<List<Course>>())).Returns(true);
            IChecks check = new Checks();
            bool result = check.CheckAllCreditsPassed(requirements, courses);
            // There was a logical error to test passed or not. for example what happen if
            // average is more than 50 but one or more mourses are less than 50?
            // Here we make sure that each student has passed all credits.
            Assert.IsTrue(result);
        }
        private List<Course> GetCourseData()
        {
            List<Course> courses = new List<Course>
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   };
            return courses;
        }
        private Diploma GetDiploma()
        {
            Diploma diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new List<int> { 100, 102, 103, 104 }
            };
            return diploma;
        }
        private List<Student> GetStudents()
        {
            var students = new List<Student>
            {
               new Student
               {
                   Id = 1,
                   Courses = new List<Course>
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new List<Course>
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new List<Course>
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new List<Course>
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            }


            //tracker.HasGraduated()
            };
            return students;
        }
    }
}
