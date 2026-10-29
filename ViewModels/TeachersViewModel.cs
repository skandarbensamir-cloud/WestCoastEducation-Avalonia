using System;
using WestCoastEducationAvalonia.Enums;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationAvalonia.Interfaces;
using WestCoastEducationAvalonia.Models;

namespace WestCoastEducationAvalonia.ViewModels;

public partial class TeachersViewModel : ViewModelBase
{
    private readonly ITeacherService _teacherService;

    public TeachersViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }
    public ObservableCollection<Teacher> Teachers { get; } = new ();

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