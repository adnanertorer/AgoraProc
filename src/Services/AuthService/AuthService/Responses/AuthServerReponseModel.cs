using System.Text.Json.Serialization;

namespace AuthService.Responses;

public class AuthServerReponseModel<T> where T : class
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    [JsonPropertyName("message")]
    public string Message { get; set; }
    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }
}