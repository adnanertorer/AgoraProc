using System.Text.Json.Serialization;

namespace AuthService.Models;

public class ResetPasswordModel
{
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Type { get; set; } = "password";
    [JsonPropertyName("temporary")]
    public bool Temporary { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; } = null!;
}