using System.Text.Json.Serialization;

namespace WestCoastEducationAvalonia.Models;

public class KnowledgeArea
{
  [JsonPropertyName("_id")]
  public string? Id {get; set;}
  public string Name {get; set;} = "";
}
