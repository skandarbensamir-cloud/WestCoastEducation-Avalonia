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
        return teachers ?? new List<Teacher>();
    }
    
}
