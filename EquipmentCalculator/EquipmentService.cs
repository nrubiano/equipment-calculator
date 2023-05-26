using EquipmentCalculator.Models;
using LanguageExt.Common;

namespace EquipmentCalculator;

public class EquipmentService
{
    private readonly EquipmentApiClient _equipmentApiClient;
    
    public EquipmentService()
    {
        _equipmentApiClient = new EquipmentApiClient();
    }
    
    public Result<EquipmentValue> GetEquipmentValue(string year, string equipmentId)
    {
        var data = _equipmentApiClient.GetEquipments();

        if (data == null)
            return new Result<EquipmentValue>(new Exception("No data available."));
        
        if (!data.ContainsKey(equipmentId))
            return new Result<EquipmentValue>(new Exception("The equipment id doesn't exist."));
        
        if(!data[equipmentId].Schedule.Years.ContainsKey(year))
            return new Result<EquipmentValue>(new Exception("The year for the equipment id doesn't exist."));

        var equipment = data[equipmentId];
        var ratioYear = equipment.Schedule.Years[year];

        return new Result<EquipmentValue>(new EquipmentValue
        (
            AuctionValue: equipment.SaleDetails.Cost * ratioYear.AuctionRatio,
            MarketValue: equipment.SaleDetails.Cost * ratioYear.MarketRatio
        ));
    }
}