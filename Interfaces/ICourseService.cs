using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducationAvalonia.Models;

namespace WestCoastEducationAvalonia.Interfaces;

public interface ICourseService
{
    Task<List<Course>> GetCoursesAsync();
    Task AddCourseAsync(Course course);
}

    

