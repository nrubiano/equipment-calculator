using EquipmentCalculator;

var equipmentService = new EquipmentService();

var resultFor2007And67352 = 
    equipmentService.GetEquipmentValue("2007", "67352")
                    .Match<string>(
                    r => r.ToString(), 
                    e => e.Message
                    );

Console.WriteLine($"Result: {resultFor2007And67352}");

var resultFor2011And87964 = 
    equipmentService.GetEquipmentValue("2011", "87964")
        .Match<string>(
            r => r.ToString(), 
            e => e.Message
        );

Console.WriteLine($"Result: {resultFor2011And87964}");


