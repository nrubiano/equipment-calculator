namespace EquipmentCalculator.Models;

public class Schedule {
    public IDictionary<string, Ratios> Years { get; set; }
    public decimal DefaultMarketRatio { get; set; }
    public decimal DefaultAuctionRation { get; set; }
};