using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Media.TextFormatting.Unicode;
using WestCoastEducationAvalonia.Interfaces;
using WestCoastEducationAvalonia.Models;

namespace WestCoastEducationAvalonia.Services;

public class RestDbKnowledgeAreaService : IKnowledgeAreaService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
      PropertyNameCaseInsensitive = true  
    };

    public RestDbKnowledgeAreaService()
    {
        _httpClient = new HttpClient
        {
          BaseAddress = new Uri("https://westcoasteducation-5593.restdb.io/rest/")  
        };

        _httpClient.DefaultRequestHeaders.Add("x-apikey", Secrets.RestDbApiKey);
    }

    public async Task<List<KnowledgeArea>> GetKnowledgeAreasAsync()
    {
        var knowledgeAreas = await _httpClient.GetFromJsonAsync<List<KnowledgeArea>>("knowledgeareas", _jsonOptions);
        return knowledgeAreas ?? new List<KnowledgeArea>();
    }
}