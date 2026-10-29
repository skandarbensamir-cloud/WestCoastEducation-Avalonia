using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducationAvalonia.Models;

namespace WestCoastEducationAvalonia.Interfaces;

public interface ITeacherService
{
    Task<List<Teacher>> GetTeachersAsync();
    Task AddTeacherAsync(Teacher teacher);
}

    

