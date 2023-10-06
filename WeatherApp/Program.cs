using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Please provide latitude and longitude as command-line arguments.\nFormat should be: =>dotnet WeatherApp.dll <latitude> <longitude>");
            return;
        }

        string lat = args[0];
        string lon = args[1];

        // Replace with your OpenWeatherMap API key
        string apiKey = "801ce3735d0fb6c7a7995b0b0657fc64";
        string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}";

        // Loop 5 times
        for (int i = 0; i < 5; i++)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        // Here, you would parse the JSON response to extract weather data.
                        // For demonstration purposes, let's just print the JSON response.
                        Console.WriteLine($"Request {i + 1}:\n{json}");
                    }
                    else
                    {
                        Console.WriteLine($"Request {i + 1}: API request failed with status code {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Request {i + 1}: An error occurred: {ex.Message}");
            }

            // Delay for 60 seconds (1 minute) before the next iteration
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }
}
