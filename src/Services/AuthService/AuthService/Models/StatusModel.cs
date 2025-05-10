using System.Text.Json.Serialization;

namespace AuthService.Models;

public class StatusModel
{
    [JsonPropertyName("status")]
    public int Status { get; set; }
}