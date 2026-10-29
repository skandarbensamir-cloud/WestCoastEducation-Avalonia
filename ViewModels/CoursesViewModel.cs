using System;
using WestCoastEducationAvalonia.Enums;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationAvalonia.Interfaces;
using WestCoastEducationAvalonia.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

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
    //körs automatiskt när man markerar en kurs i listan.
    //Fyller formuläret med kursens uppgifter så att man kan ändra dom.
    partial  void OnSelectedCourseChanged(Course? value)
    {
        if (value is null)
        {
            return;
        }

        NewCourseNumber = value.CourseNumber;
        NewCourseTitle = value.CourseTitle;
        NewLength = value.Length;
        NewStartDate = value.StartDate;
        NewEndDate = value.EndDate;
        NewCourseType = value.CourseType;
    }

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

    [RelayCommand]
    private async Task UpdatecourseAsync()
    {
        if (SelectedCourse?.Id is null)
        {
            return;
        }

        SelectedCourse.CourseNumber = NewCourseNumber;
        SelectedCourse.CourseTitle = NewCourseTitle;
        SelectedCourse.Length = (int)(NewLength ?? 0);
        SelectedCourse.StartDate = NewStartDate ?? DateTime.Today;
        SelectedCourse.EndDate = NewEndDate ?? DateTime.Today;
        SelectedCourse.CourseType = NewCourseType;

        await _courseService.UpdateCourseAsync(SelectedCourse);
        await LoadCoursesAsync();
    }
}