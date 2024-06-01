// ***********************************************************************************************************
// Se ponen en uso de los componentes necesarios para consumir el API de Dynamics 365
// ***********************************************************************************************************
using System.Net;
using System.Text.Json;
using WebApiClient;

// ***********************************************************************************************************
// Se declaran las variables necesarias para realizar la conexión a los servicios de Dynamics 365
// ***********************************************************************************************************
Uri uri = new("http://190.249.146.250:81/OftalvisionLtda/api/data/v8.2/");
string domain = "oftalvision";
string user = "<nombre de usuario>";
string password = "<Contraseña>";

// ***********************************************************************************************************
// Se crea el objeto que administra las credenciales con las cuales se autenticará el servicio de Dynamics 365
// ***********************************************************************************************************
CredentialCache credentialsCache = new()
{
    { uri, "Negotiate", new NetworkCredential(user, password, domain) }
};
HttpClientHandler handler = new() { Credentials = credentialsCache, PreAuthenticate = true };

// ***********************************************************************************************************
// Se crea el cliente de conexión Http con los valores necesario para consumir el servicio de Dynamics 365
// ***********************************************************************************************************
HttpClient httpClient = new(handler) { BaseAddress = uri, Timeout = new TimeSpan(0, 0, 60) };

// ***********************************************************************************************************
// Se realiza una solicitudo GET al servicio de Dynamics 365 y se obtiene su respuesta
// ***********************************************************************************************************
string query = $"accounts?$select=new_nit,name,new_vencesuscripcion,statecode&$filter=new_nit eq '811007246-9'";
var response = await httpClient.GetAsync(query);

// ***********************************************************************************************************
// Si la respuesta a la solicitud no es correcta (o sea no está entre el rango 200), se termina el proceso.
// ***********************************************************************************************************
if (!response.IsSuccessStatusCode)
{
    if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden) 
    {
        Console.WriteLine("No está autorizado para consultar la información de Dynamics 365.");
        return -1;
    }

    if (response.StatusCode == HttpStatusCode.NotFound) 
    {
        Console.WriteLine("No fue encontrado el recurso consultando la información de Dynamics 365.");
        return -1;
    }
        
    Console.WriteLine("Ocurrió un error consultado la información de Dynamics 365.");
    return -1;    
}

// ***********************************************************************************************************
// Si trata de obtener el contenido de la respuesta, y si está vacío se termina el proceso.
// ***********************************************************************************************************
string content = await response.Content.ReadAsStringAsync();
ODataCollection<Account>? data = JsonSerializer.Deserialize<ODataCollection<Account>>(content);
if (data?.Value == null)
{
    Console.WriteLine("No se obtuvieron resultados de la consulta a Dynamics 365.");
    return 0;
}

// ***********************************************************************************************************
// Se recorre la colección de datos que retornó la solicitud y se muestra la información.
// ***********************************************************************************************************
foreach (var account in data.Value)
    Console.WriteLine($"ID: {account.AccountId}, Número: {account.AccountNumber}, Nombre: {account.Name}");

return 0;