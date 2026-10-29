namespace WestCoastEducationAvalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public CoursesViewModel Courses {get; set;}
    public StudentsViewModel Students {get; set;}
    public TeachersViewModel Teachers {get; set;}

    public MainViewModel(CoursesViewModel courses, StudentsViewModel students, TeachersViewModel teachers)
    {
        Courses = courses;
        Students = students;
        Teachers = teachers;
    }
}
