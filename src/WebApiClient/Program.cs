// See https://aka.ms/new-console-template for more information

var client = new HttpClient();

// Request
var request = new HttpRequestMessage(HttpMethod.Get, "https://fakerestapi.azurewebsites.net/api/v1/Activities");

// Enviar la solicitud y esperar la respuesta
var response = await client.SendAsync(request);

// Se lee el contenido y se muestra
response.EnsureSuccessStatusCode();
Console.WriteLine(await response.Content.ReadAsStringAsync());

//var client = new HttpClient();
//var response = await client.GetAsync("http://192.168.20.2:8001/api/v2/");
//Console.WriteLine(await response.Content.ReadAsStringAsync());
