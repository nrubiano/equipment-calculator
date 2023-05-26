using System.Text.Json.Serialization;

namespace EquipmentCalculator.Models;

public class Classification
{
    public string Category { get; set; }
    
    public string Subcategory { get; set; }
    
    public string Make { get; set; }
    
    public string Model { get; set; }
}