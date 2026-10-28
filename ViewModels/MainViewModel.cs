using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationAvalonia.Interfaces;
using WestCoastEducationAvalonia.Models;
using WestCoastEducationAvalonia.Services;

namespace WestCoastEducationAvalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly ICourseService _courseService = new RestDbCourseService();
    private readonly IStudentService _studentService = new RestDbStudentService();
    [ObservableProperty]
    public partial string Greeting {get; set;} ="Welcome to Avalonia";
    public ObservableCollection<Course> Courses { get; } = new();
    public ObservableCollection<Student> Students { get; } = new();
    [RelayCommand]
    private async Task LoadCoursesAsync()
    {
        Courses.Clear();
        var courses = await _courseService.GetCoursesAsync();
        foreach (var course in courses)
        {
            Courses.Add(course);
        }
    }
    [RelayCommand]
    private async Task LoadStudentsAsync()
    {
        Students.Clear();
        var students = await _studentService.GetStudentsAsync();
        foreach (var student in students)
        {
            Students.Add(student);
        }
    }
}
