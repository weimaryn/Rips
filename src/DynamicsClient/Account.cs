using System.Text.Json.Serialization;

namespace DynamicsClient;

/// <summary>
/// Información de una cuenta que se puede obtener de Dynamics 365
/// </summary>
public class Account
{
    [JsonPropertyName("accountid")]
    public Guid AccountId { get; set; }
    [JsonPropertyName("new_nit")]
    public string? AccountNumber { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("statecode")]
    public int StateCode { get; set; }
    [JsonPropertyName("new_vencesuscripcion")]
    public DateTime? Expiration { get; set; }
}
