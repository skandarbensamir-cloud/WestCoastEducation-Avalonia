using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WestCoastEducationAvalonia.Interfaces;
using WestCoastEducationAvalonia.Models;

namespace WestCoastEducationAvalonia.Services;

public class RestDbCourseService: ICourseService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions = new ()
    {
        PropertyNameCaseInsensitive = true
    };

    public RestDbCourseService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://westcoasteducation-5593.restdb.io/rest/")
        };

        _httpClient.DefaultRequestHeaders.Add("x-apikey", Secrets.RestDbApiKey);
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        var Courses = await _httpClient.GetFromJsonAsync<List<Course>>("courses", _jsonOptions);
        return Courses ?? new List<Course>();
    }

    public async Task DeleteCourseAsync(string Id)
    {
        var response = await _httpClient.DeleteAsync($"courses/{Id}");
        response.EnsureSuccessStatusCode();
    }
    public async Task AddCourseAsync(Course course)
    {
        var NewCourse = new
        {
            coursenumber = course.CourseNumber,
            coursetitle = course.CourseTitle,
            length = course.Length,
            startdate = course.StartDate,
            enddate = course.EndDate,
            coursetype = (int)course.CourseType

        };
        
        var response = await _httpClient.PostAsJsonAsync("courses", NewCourse);
        response.EnsureSuccessStatusCode();
    }
}
