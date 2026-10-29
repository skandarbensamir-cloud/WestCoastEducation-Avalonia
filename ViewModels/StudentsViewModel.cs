using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationAvalonia.Interfaces;
using WestCoastEducationAvalonia.Models;

namespace WestCoastEducationAvalonia.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    private readonly IStudentService _studentService;

    public StudentsViewModel(IStudentService studentService)
    {
        _studentService = studentService;
    }
    public ObservableCollection<Student> Students { get; } = new();

    [ObservableProperty]
    public partial string NewFirstName {get; set;} = "";
    [ObservableProperty]
    public partial string NewLastName {get; set;} = "";
    [ObservableProperty]
    public partial string NewPersonIdentityNumber {get; set;} = "";
    [ObservableProperty]
    public partial string NewPhoneNumber {get; set;} = "";   

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

}    