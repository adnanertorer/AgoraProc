using System.Text.Json.Serialization;

namespace AuthService.Models;

public class AuthErrorModel
{
    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; set; }
    [JsonPropertyName("error")]
    public string Error { get; set; }
}