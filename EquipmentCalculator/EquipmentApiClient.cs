using System.Reflection;
using System.Text.Json;
using EquipmentCalculator.Models;

namespace EquipmentCalculator;

public class EquipmentApiClient
{
    public IDictionary<string, Equipment>? GetEquipments()
    {
        var fileName = "data.json";
        var filePath = Path.Combine(GetExecutableFolder() ?? string.Empty, fileName);
        var jsonData = File.ReadAllText(filePath);
        
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };
        
        //TODO: probably this will require some kind of caching.
        return JsonSerializer.Deserialize<IDictionary<string, Equipment>>(jsonData, options);
    }
    
    private static string? GetExecutableFolder()
    {
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        return Path.GetDirectoryName(assemblyLocation);
    }
}