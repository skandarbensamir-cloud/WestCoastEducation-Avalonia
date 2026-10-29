# WestCoastEducationAvalonia

A cross-platform desktop app built with C# and Avalonia for the fictional education company WestCoast Education. Staff can manage courses, students and teachers. Continues from [assignment 1](https://github.com/skandarbensamir-cloud/WestCoastEducation).

## Features

- **Courses:** list, add, update, delete
- **Students:** list, add
- **Teachers:** list, add, update (including knowledge area)

## Built with

Avalonia, MVVM (CommunityToolkit.Mvvm), RestDb.io, interfaces and services for HTTP, Dependency Injection and dynamic resources for colors.

## Run

The API key is not on GitHub. Create `Services/Secrets.cs`:

```csharp
namespace WestCoastEducationAvalonia.Services;

public static class Secrets
{
    public const string RestDbApiKey = "YOUR-API-KEY";
}
```

Then press **F5** in VS Code.