namespace practice_8;

public class CityLocationItem
{
    public string Name;
    public string LocalNames;
    public float Lat { get; }
    public float Lon { get; }
    public string Country;
    public string State;

    public CityLocationItem(string name, string localNames, float lat, float lon, string country, string state)
    {
        Name = name;
        LocalNames = localNames;
        Lat = lat;
        Lon = lon;
        Country = country;
        State = state;
    }
}