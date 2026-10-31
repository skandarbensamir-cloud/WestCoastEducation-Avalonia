using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WestCoastEducationAvalonia.Interfaces;
using WestCoastEducationAvalonia.Models;

namespace WestCoastEducationAvalonia.Services;

public class RestDbTeacherService: ITeacherService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions = new ()
    {
        PropertyNameCaseInsensitive = true
    };

    public RestDbTeacherService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://westcoasteducation-5593.restdb.io/rest/")
        };

        _httpClient.DefaultRequestHeaders.Add("x-apikey", Secrets.RestDbApiKey);
    }


    public async Task<List<Teacher>> GetTeachersAsync()
    {
        var teachers = await _httpClient.GetFromJsonAsync<List<Teacher>>("teachers", _jsonOptions);
        teachers ??= new List<Teacher>();
        //Lärare som kan sakna områden i REstDb får en tom lista istället för null
        foreach (var teacher in teachers)
        {
            teacher.KnowledgeAreas??= new List<KnowledgeArea>();
        }
        return teachers;
    }

    public async Task AddTeacherAsync(Teacher teacher)
    {
        var NewTeacher = new
        {
            firstname = teacher.FirstName,
            lastname = teacher.LastName,
            personidentitynumber = teacher.PersonIdentityNumber,
            phonenumber = teacher.PhoneNumber,
            knowledgeareas = teacher.KnowledgeAreas,
        };

        var response = await _httpClient.PostAsJsonAsync("teachers", NewTeacher);
        response.EnsureSuccessStatusCode();
    }
    
    public async Task UpdateTeacherAsync(Teacher teacher)
    {
        var UpdateTeacher = new
        {
          firstname = teacher.FirstName,
          lastname = teacher.LastName,
          personidentitynumber = teacher.PersonIdentityNumber,
          phonenumber = teacher.PhoneNumber,
          knowledgeareas = teacher.KnowledgeAreas  
        };

        var response = await _httpClient.PutAsJsonAsync($"teachers/{teacher.Id}", UpdateTeacher);
        response.EnsureSuccessStatusCode();
    }

    
}
