using GraduationTracker.Models;
using System.Collections.Generic;

namespace GraduationTracker.Interfaces
{
    public interface IRepository
    {
        Student GetStudent(int id);
        Diploma GetDiploma(int id);
        Requirement GetRequirement(int id);
        List<Requirement> GetRequirements();
    }
}
