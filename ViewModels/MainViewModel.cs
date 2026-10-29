using System;
using WestCoastEducationAvalonia.Enums;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationAvalonia.Interfaces;
using WestCoastEducationAvalonia.Models;
using WestCoastEducationAvalonia.Services;
using System.Security;
using Avalonia.Metadata;
using System.Drawing;

namespace WestCoastEducationAvalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly ICourseService _courseService = new RestDbCourseService();
    private readonly IStudentService _studentService = new RestDbStudentService();
    private readonly ITeacherService _teacherService = new RestDbTeacherService();
    [ObservableProperty]
    public partial string Greeting {get; set;} ="Welcome to Avalonia";
    public ObservableCollection<Course> Courses { get; } = new();
    public ObservableCollection<Student> Students { get; } = new();
    public ObservableCollection<Teacher> Teachers { get; } = new ();
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

    [ObservableProperty]
    public partial string NewFirstName {get; set;} = "";
    [ObservableProperty]
    public partial string NewLastName {get; set;} = "";
    [ObservableProperty]
    public partial string NewPersonIdentityNumber {get; set;} = "";
    [ObservableProperty]
    public partial string NewPhoneNumber {get; set;} = "";

    [ObservableProperty]
    public partial string NewTeacherFirstName {get; set;} = "";
    [ObservableProperty]
    public partial string NewTeacherLastName {get; set;} = "";
    [ObservableProperty]
    public partial string NewTeacherPersonIdentityNumber {get; set;} = "";
    [ObservableProperty]
    public partial string NewTeacherPhoneNumber {get; set;} = "";
    [ObservableProperty]
    public partial string NewKnowledgeArea {get; set;} = "";



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
    public async Task DeleteCourseAsync()
    {
        if (SelectedCourse?.Id is null)
        {
            return;
        }
        
        await _courseService.DeleteCourseAsync(SelectedCourse.Id);
        await LoadCoursesAsync();
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

[RelayCommand]
private async Task AddStudentAsync()
    {
        var student = new Student
        {
          FirstName = NewFirstName,
          LastName = NewLastName,
          PersonIdentityNumber = NewPersonIdentityNumber,
          PhoneNumber = NewPhoneNumber 
        };

        await _studentService.AddStudentAsync(student);
        NewFirstName = "";
        NewLastName = "";
        NewPersonIdentityNumber = "";
        NewPhoneNumber = "";

        await LoadStudentsAsync();
    
    }
[RelayCommand]
private async Task LoadTeachersAsync()
    {
      Teachers.Clear();
      var teachers = await _teacherService.GetTeachersAsync();
      foreach (var teacher in teachers)
        {
            Teachers.Add(teacher);
        }
    }

[RelayCommand]
private async Task AddTeacherAsync()
    {
        var teacher =new Teacher
        {
            FirstName = NewTeacherFirstName,
            LastName = NewTeacherLastName,
            PersonIdentityNumber = NewTeacherPersonIdentityNumber,
            PhoneNumber = NewTeacherPhoneNumber,
            KnowledgeArea = NewKnowledgeArea
        };

        await _teacherService.AddTeacherAsync(teacher);
        
        NewTeacherFirstName = "";
        NewTeacherLastName = "";
        NewTeacherPersonIdentityNumber = "";
        NewTeacherPhoneNumber = "";
        NewKnowledgeArea = "";

        await LoadTeachersAsync();

    }


}
