namespace practice_8;

public class DayWeatherItem
{
    public string Cod;
    public string Message;
    public string Cnt;
    public List<WeatherItem>? List { get; set; }
    public CityItem City;

    public DayWeatherItem(string cod, string message, string cnt, List<WeatherItem> list, CityItem city)
    {
        Cod = cod;
        Message = message;
        Cnt = cnt;
        List = list;
        City = city;
    }
}

public class WeatherItem
{
    public int Dt { get; }
    public WeatherMain Main { get; }
    public List<WeatherDescription> Weather { get; }
    public CloudsItem Clouds;
    public WindItem Wind;
    public string Visibility;
    public string Pop;
    public RainItem Rain;
    public SysItem Sys;
    public DateTime DtTxt;

    public WeatherItem(int dt, 
        WeatherMain main, 
        List<WeatherDescription> weather, 
        CloudsItem clouds, 
        WindItem wind, 
        string visibility, 
        string pop, 
        RainItem rain, 
        SysItem sys, 
        DateTime dtTxt)
    {
        Dt = dt;
        Main = main;
        Weather = weather;
        Clouds = clouds;
        Wind = wind;
        Visibility = visibility;
        Pop = pop;
        Rain = rain;
        Sys = sys;
        DtTxt = dtTxt;
    }
}

public class WeatherMain
{
    public float Temp { get; }
    public string FeelsLike;
    public string TempMin;
    public string TempMax;
    public string Pressure;
    public string SeaLevel;
    public string GrndLevel;
    public string Humidity;
    public string TempKf;
    
    public WeatherMain(
        float temp, 
        string feelsLike,
        string tempMin, 
        string tempMax, 
        string pressure, 
        string seaLevel, 
        string grndLevel, 
        string humidity, 
        string tempKf)
    {
        Temp = temp;
        FeelsLike = feelsLike;
        TempMin = tempMin;
        TempMax = tempMax;
        Pressure = pressure;
        SeaLevel = seaLevel;
        GrndLevel = grndLevel;
        Humidity = humidity;
        TempKf = tempKf;
    }
}

public class WeatherDescription
{
    public int Id;
    public string Main;
    public string Description { get; }
    public string Icon;

    public WeatherDescription(int id, string main, string description, string icon)
    {
        Id = id;
        Main = main;
        Description = description;
        Icon = icon;
    }
}

public class CloudsItem
{
    public string All;

    public CloudsItem(string all)
    {
        All = all;
    }
}
public class WindItem
{
    public float Speed;
    public float Deg;
    public float Gust;

    public WindItem(float speed, float deg, float gust)
    {
        Speed = speed;
        Deg = deg;
        Gust = gust;
    }
}
public class SysItem
{
    public string Pod;

    public SysItem(string pod)
    {
        Pod = pod;
    }
}

public class CityItem
{
    public int Id;
    public string Name;
    public CityCoordinationItem Coord;
    public string Country;
    public int Population;
    public int Timezone;
    public int Sunrise;
    public int Sunset;

    public CityItem(
        int id,
        string name,
        CityCoordinationItem coord, 
        string country, 
        int population, 
        int timezone, 
        int sunrise, 
        int sunset)
    {
        Id = id;
        Name = name;
        Coord = coord;
        Country = country;
        Population = population;
        Timezone = timezone;
        Sunrise = sunrise;
        Sunset = sunset;
    }
}

public class CityCoordinationItem
{
    public float Lat;
    public float Lon;

    public CityCoordinationItem(float lat, float lon)
    {
        Lat = lat;
        Lon = lon;
    }
}

public class RainItem
{
    public float Chance;

    public RainItem(float chance)
    {
        Chance = chance;
    }
}