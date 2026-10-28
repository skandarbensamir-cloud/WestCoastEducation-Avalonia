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
    [ObservableProperty]
    public partial string Greeting {get; set;} ="Welcome to Avalonia";
    public ObservableCollection<Course> Courses { get; } = new();
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
}
