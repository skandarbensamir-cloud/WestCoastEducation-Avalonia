using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading.Tasks;
using WestCoastEducationAvalonia.Interfaces;
using WestCoastEducationAvalonia.Models;

namespace WestCoastEducationAvalonia.Services;

public class RestDbStudentService: IStudentService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions = new ()
    {
        PropertyNameCaseInsensitive = true
    };

    public RestDbStudentService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://westcoasteducation-5593.restdb.io/rest/")
        };

        _httpClient.DefaultRequestHeaders.Add("x-apikey", Secrets.RestDbApiKey);
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        var students = await _httpClient.GetFromJsonAsync<List<Student>>("students", _jsonOptions);
        return students ?? new List<Student>();
    }

    public async Task AddStudentAsync(Student student)
    {
        var newStudent = new
        {
            firstname = student.FirstName,
            lastname = student.LastName,
            personidentitynumber = student.PersonIdentityNumber,
            phonenumber = student.PhoneNumber
        };
        
        var response = await _httpClient.PostAsJsonAsync("students", newStudent);
        response.EnsureSuccessStatusCode();
    }
}
