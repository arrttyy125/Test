using GraduationTracker.Interfaces;
using GraduationTracker.Models;
using System.Collections.Generic;

namespace GraduationTracker.Repository
{
    public class Repository : IRepository
    {
        public Student GetStudent(int id)
        {
            var students = GetStudents();
            Student student = null;

            for (int i = 0; i < students.Count; i++)
            {
                if (id == students[i].Id)
                {
                    student = students[i];
                }
            }
            return student;
        }

        public Diploma GetDiploma(int id)
        {
            var diplomas = GetDiplomas();
            Diploma diploma = null;

            for (int i = 0; i < diplomas.Count; i++)
            {
                if (id == diplomas[i].Id)
                {
                    diploma = diplomas[i];
                }
            }
            return diploma;

        }

        public Requirement GetRequirement(int id)
        {
            var requirements = GetRequirements();
            Requirement requirement = null;

            for (int i = 0; i < requirements.Count; i++)
            {
                if (id == requirements[i].Id)
                {
                    requirement = requirements[i];
                }
            }
            return requirement;
        }
        public List<Requirement> GetRequirements()
        {   
                return new List<Requirement>
                {
                    new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new List<int>{1}, Credits=1 },
                    new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new List<int>{2}, Credits=1 },
                    new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new List<int>{3}, Credits=1},
                    new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new List<int>{4}, Credits=1 }
                };
        }
        private List<Diploma> GetDiplomas()
        {
            return new List<Diploma>
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new List<int>(){100,102,103,104}
                }
            };
        }
        private List<Student> GetStudents()
        {
            return new List<Student>
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

            };
        }
    }


}
