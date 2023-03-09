using The_Village_of_Testing;

namespace The_Village_of_Testing_Test;

public class DayTest
{
    // Test Day()
    [Fact]
    public void NoWorker_TryDayFunction()
    {
        // given
        var village = new Village();

        // when
        village.Day();
        var actual = village.GetFood();
        var workerList = village.GetWorkers();

        // then
        Assert.Equal(10, actual);
        Assert.Empty(workerList);
    }
    
    [Fact]
    public void AddTwoWorkers_TryDayFunctionWithEnoughFood()
    {
        // given
        var village = new Village();
        var adam = new Worker("Adam", "woodcutter");
        var bob = new Worker("Bob", "woodcutter");
        village.AddWorker(adam);
        village.AddWorker(bob);

        // when
        village.Day();
        var actual = village.GetFood();

        // then
        Assert.Equal(8, actual);
        Assert.False(adam.hungry);
    }
    
    [Fact]
    public void RunDayFunction_WithoutEnoughFood()
    {
        // given 
        var village = new Village();
        var adam = new Worker("Adam", "woodcutter");
        var bob = new Worker("Bob", "woodcutter"); 
        village.AddWorker(adam);
        village.AddWorker(bob);

        // when
        for (int i = 0; i < 7; i++)
        {
            village.Day(); // 2 food will be consumed each day because of two workers 
        }
        
        var food = village.GetFood();

        // then
        Assert.True(adam.hungry);
        Assert.True(bob.hungry);
        Assert.Equal(0, food); 
    }
    
    
    // Whole test
    // TODO Starta från början. Kör alla funktioner, en kombination av AddWorker(), AddProject() och Day() tills ett slott blir klart. Lista hur många dagar det tog till slut. Testa om det tog det antal dagar som det borde ha.
}