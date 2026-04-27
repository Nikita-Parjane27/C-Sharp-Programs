using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

class ApiConsumption
{
    static readonly HttpClient client = new HttpClient();

    static async Task Main()
    {
        Console.WriteLine("Fetching data from API...\n");

        // Using a free public API
        string url = "https://jsonplaceholder.typicode.com/users/1";

        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Raw JSON Response:");
            Console.WriteLine(jsonData);

            // Parse JSON
            using JsonDocument doc = JsonDocument.Parse(jsonData);
            JsonElement root = doc.RootElement;

            Console.WriteLine("\nParsed Data:");
            Console.WriteLine($"Name    : {root.GetProperty("name").GetString()}");
            Console.WriteLine($"Email   : {root.GetProperty("email").GetString()}");
            Console.WriteLine($"Phone   : {root.GetProperty("phone").GetString()}");
            Console.WriteLine($"Website : {root.GetProperty("website").GetString()}");
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
        }
    }
}