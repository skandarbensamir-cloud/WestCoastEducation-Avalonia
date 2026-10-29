using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using WestCoastEducationAvalonia.Interfaces;
using WestCoastEducationAvalonia.Services;
using WestCoastEducationAvalonia.ViewModels;
using WestCoastEducationAvalonia.Views;

namespace WestCoastEducationAvalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // DI : De här allt registreras som appen behöver
        var services = new ServiceCollection();

        //Services: När någon väl ber om ett interface får de RestDb-versionen
        services.AddSingleton<ICourseService, RestDbCourseService>();
        services.AddSingleton<IStudentService, RestDbStudentService>();
        services.AddSingleton<ITeacherService, RestDbTeacherService>();

        //Här har vi ViewModels
        services.AddTransient<CoursesViewModel>();
        services.AddTransient<StudentsViewModel>();
        services.AddTransient<TeachersViewModel>();
        services.AddTransient<MainViewModel>();

        var provider = services.BuildServiceProvider();

        if(ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
              //Conatainern skapar MainViewModel och allt den behöver
              DataContext = provider.GetRequiredService<MainViewModel>(),  
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}    

