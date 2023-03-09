using The_Village_of_Testing;

namespace The_Village_of_Testing_Test;

public class WorkerHungryTest
{
    [Fact]
    public void HungryWorker_DontWork()
    {
        // Given
        var adam = new Worker("Adam", "woodcutter");
        var village = new Village();
        village.AddWorker(adam);

        // When
        village.SetFood(0); // there is no enough food
        village.Day();
        
        // Then
        Assert.True(adam.hungry);
    }
    
    [Fact]
    public void HungryFortyDays_ShouldBeNotAlive()
    {
        // Given
        var adam = new Worker("Adam", "woodcutter");
        adam.daysHungry = 40;

        var village = new Village();
        village.AddWorker(adam);
        
        // When
        village.Day();
        
        // Then 
        Assert.False(adam.alive);
    }
    
    // 3 Det skall inte gå att mata en arbetare med ”alive = false”.
    [Fact]
    public void CantFeedNotAliveWorker()
    {
        // Given
        var adam = new Worker("Adam", "woodcutter");
        adam.daysHungry = 40;

        var village = new Village();
        village.AddWorker(adam);
        
        // When
        village.Day();
        var actual = village.GetFood(); // There is 10 initialized food
        
        // Then 
        Assert.Equal(10, actual);
    }
    
    // 4 Kolla att ”BuryDead()” funktionen tar bort de som har ”alive = false”.
    [Fact]
    public void BuryDead_RemoveNotAliveWorkers()
    {
        // Given
        var village = new Village();
        var adam = new Worker("Adam", "woodcutter");
        var bob = new Worker("Bob", "farmer");
        var cindy = new Worker("Cindy", "builder");
        village.AddWorker(adam);
        village.AddWorker(bob);
        village.AddWorker(cindy);
        
        // When
        adam.daysHungry = 40;
        village.BuryDead();
        var actual = village.GetWorkers().Count;
        
        // Then
        Assert.Equal(2, actual);
    }
}