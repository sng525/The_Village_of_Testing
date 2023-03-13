using The_Village_of_Testing;

namespace The_Village_of_Testing_Test;

public class BuildingFinishedTest
{
    [Fact]
    public void DayBeforeAndAfterWoodMillIsReady_CollectExtraWood()
    {
        // Given
        var village = new Village();
        village.SetWood(100);
        village.SetMetal(20);
        var woodmill = new Building("woodmill", 5, 5, 1);
        village.AddProject(woodmill);

        village.AddWorker(new Worker("Adam", "woodcutter"));
        village.AddWorker(new Worker("Bob", "builder"));

        // When
        for (int i = 0; i < 4; i++) // run 4 days
        {
            village.Day();
        }

        // Then
        Assert.Equal(1, village.WoodPerDay);
        Assert.Equal(4, village.GetDaysGone());
        Assert.False(woodmill.complete);

        // When
        village.Day(); // the fifth day, the woodmill is done
        var woodPerDayAfterWoodMillFinished = village.WoodPerDay;

        // Then
        Assert.True(woodmill.complete);
        Assert.Equal(3, woodPerDayAfterWoodMillFinished);
    }

    [Fact]
    public void DayBeforeAndAfterFarmIsReady_CollectExtraFood()
    {
        // Given
        var village = new Village();
        village.SetWood(100);
        village.SetMetal(20);
        var farm = new Building("farm", 5, 5, 2);

        village.AddProject(farm);
        village.AddWorker(new Worker("Jimmy", "farmer"));
        village.AddWorker(new Worker("Jessi", "builder"));

        // When
        for (int i = 0; i < 4; i++) // run 4 days
        {
            village.Day();
        }

        // Then
        Assert.Equal(5, village.FoodPerDay);
        Assert.Equal(4, village.GetDaysGone());
        Assert.False(farm.complete);

        // When
        village.Day();
        var woodPerDayAfterFarmFinished = village.FoodPerDay;

        // Then
        Assert.Equal(15, woodPerDayAfterFarmFinished);
    }

    [Fact]
    public void DayBeforeAndAfterQuarryIsReady_CollectExtraMetal()
    {
        // Given
        var village = new Village();
        village.SetWood(100);
        village.SetMetal(20);
        village.SetFood(100);
        var quarry = new Building("quarry", 7, 3, 5);
        village.AddProject(quarry);

        village.AddWorker(new Worker("Jessi", "builder"));

        // When
        for (int i = 0; i < 6; i++) // run 6 days
        {
            village.Day();
        }

        // Then
        Assert.Equal(1, village.MetalPerDay);
        Assert.Equal(6, village.GetDaysGone());
        Assert.False(quarry.complete);

        // When
        village.Day();
        var woodPerDayAfterQuarryFinished = village.MetalPerDay;

        // Then
        Assert.True(quarry.complete); // quarry finished 
        Assert.Equal(3, woodPerDayAfterQuarryFinished);
    }

    [Fact]
    public void BuildAHouse()
    {
        // Given
        var village = new Village();
        village.SetWood(100);
        var bob = new Worker("Bob", "builder");
        var house = new Building("house", 3, 5, 0);

        // When
        village.AddProject(house);
        //village.AddWorker(daniel);
        village.AddWorker(bob);

        for (int i = 0; i < 3; i++)
        {
            village.Day();
        }

        // Then
        Assert.Contains(house, village.GetBuildings()); // check if the house is finished
    }
}