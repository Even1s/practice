using Newtonsoft.Json;
namespace practice_8;
public class Program
{
    public static async Task Main()
    {
        while (true)
        {
            Console.WriteLine("[save city];[weather in my city];[weather in select city];[exit]");
            Console.Write("Write Command: ");
            var command = Console.ReadLine();
            switch (command)
            {
                case "save city":
                    Console.Write("Write city: ");
                    var cityName = Console.ReadLine();
                    if (cityName == null)
                    {
                        Console.WriteLine("ERROR, empty string");
                        continue;
                    }
                    var (latSave, lonSave) = await GetLocation(cityName);
                    SetCity(latSave, lonSave, cityName);
                    continue;
                case "weather in my city":
                {
                    using StreamReader reader = new StreamReader("../../../standartCity.txt");
                    var citySaved = await reader.ReadLineAsync();
                    var latSaved = float.Parse(await reader.ReadLineAsync() ?? string.Empty);
                    var lonSaved = float.Parse(await reader.ReadLineAsync() ?? string.Empty);
                    reader.Close();
                    Console.Write($"Weather in {citySaved}");
                    await GetWeatherSaved(latSaved, lonSaved);
                    continue;
                }
                case "weather in select city":
                    Console.Write("Write city: ");
                    var cityNameSelect = Console.ReadLine();
                    if (cityNameSelect == null)
                    {
                        Console.WriteLine("ERROR, empty string");
                        continue;
                    }
                    var (latSelect, lonSelect) = await GetLocation(cityNameSelect);
                    await GetWeatherSaved(latSelect, lonSelect);
                    continue;
                case "exit":
                    break;
                default:
                    Console.WriteLine("ERROR, not found command");
                    continue;
            }
            break;
        }
    }

    private static async Task GetWeatherSaved(float? lat, float? lon)
    {
        string apiUrl =
            $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&units=metric&lang=ru&cnt=8&appid=29a6c788fa4f0b5cecce85c9a92d8e16";
        HttpClient client = new HttpClient();
        HttpResponseMessage responseSaved = await client.GetAsync(apiUrl);
        responseSaved.EnsureSuccessStatusCode();
        string responseStringSaved = await responseSaved.Content.ReadAsStringAsync();
        DayWeatherItem? weatherSaved = JsonConvert.DeserializeObject<DayWeatherItem>(responseStringSaved);
        
        if (weatherSaved?.List != null)
            foreach (var hour in weatherSaved.List)
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds( hour.Dt ).ToLocalTime();
                Console.WriteLine($"{dateTime}: {hour.Main.Temp}\u00b0C, {hour.Weather[0].Description}");
            }
    }
    private static async void SetCity(float? lat, float? lon, string cityName)
    {
        await using var writer = new StreamWriter("../../../standartCity.txt", false);
        await writer.WriteLineAsync(cityName);
        await writer.WriteLineAsync(lat.ToString());
        await writer.WriteLineAsync(lon.ToString());
        writer.Close();
    }

    private static async Task<(float?, float?)> GetLocation(string cityName)
    {
        string apiUrl =
            $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&appid=29a6c788fa4f0b5cecce85c9a92d8e16";
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();
        string responseString = await response.Content.ReadAsStringAsync();
        List<CityLocationItem>? cityData = JsonConvert.DeserializeObject<List<CityLocationItem>>(responseString);
        float? lat = cityData?[0].Lat;
        float? lon = cityData?[0].Lon;
        return (lat, lon);
    }
}