using System.Text.Json.Serialization;

namespace IdentityManagementAPI.ModelResources;

public class GetGroupMembersByFilter
{
    [JsonPropertyName("briefRepresentation")]
    public bool? BriefRepresentation { get; set; }
    [JsonPropertyName("first")]
    public int? First { get; set; }
    [JsonPropertyName("max")]
    public int? Max { get; set; }
}