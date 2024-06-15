using System.Text.Json.Serialization;

namespace DynamicsClient;

/// <summary>
/// Estructura de la información que retorna una solicitud GET para un servicio OData
/// </summary>
/// <typeparam name="T">Tipo de objeto que retorna la solicitud.</typeparam>
internal class ODataCollection<T>
{
    [JsonPropertyName("@odata.context")]
    public string? Context { get; set; }
    [JsonPropertyName("value")]
    public List<T>? Value { get; set; }
}