using System;
using WestCoastEducationAvalonia.Enums;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationAvalonia.Interfaces;
using WestCoastEducationAvalonia.Models;

namespace WestCoastEducationAvalonia.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
  private readonly ICourseService _courseService;
  
  public CoursesViewModel(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public ObservableCollection<Course> Courses { get; } = new();
    
    [ObservableProperty]
    public partial string NewCourseNumber {get; set;} = "";
    [ObservableProperty]
    public partial string NewCourseTitle {get; set;} = "";
    [ObservableProperty]
    public partial decimal? NewLength {get; set;} = 1;
    [ObservableProperty]
    public partial DateTime? NewStartDate {get; set;} = DateTime.Today;
    [ObservableProperty]
    public partial DateTime? NewEndDate {get; set;} = DateTime.Today;
    [ObservableProperty]
    public partial CourseType NewCourseType {get; set;} = CourseType.Classroom;
    public CourseType[] CourseTypes {get;} = Enum.GetValues<CourseType>();

    [ObservableProperty]
    public partial Course? SelectedCourse {get; set;}


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
    private async Task AddCourseAsync()
    {
        var course = new Course(
            NewCourseTitle,
            (int)(NewLength ?? 0),
            NewStartDate ?? DateTime.Today,
            NewEndDate ?? DateTime.Today,
            NewCourseType,
            NewCourseNumber);

        await _courseService.AddCourseAsync(course);

        NewCourseNumber = "";
        NewCourseTitle = "";
        NewLength = 1;

        await LoadCoursesAsync();
    }
    [RelayCommand]
    private async Task DeleteCourseAsync()
    {
        if (SelectedCourse?.Id is null)
        {
            return;
        }
        
        await _courseService.DeleteCourseAsync(SelectedCourse.Id);
        await LoadCoursesAsync();
    }
}