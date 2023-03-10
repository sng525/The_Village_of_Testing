using The_Village_of_Testing;

namespace The_Village_of_Testing_Test;

public class DayTest
{
    [Fact]
    public void NoWorker_TryDayFunction()
    {
        // Given
        var village = new Village();

        // When
        village.Day();
        var actual = village.GetFood();
        var workerList = village.GetWorkers();

        // Then
        Assert.Equal(10, actual);
        Assert.Empty(workerList);
    }

    [Fact]
    public void AddTwoWorkers_TryDayFunctionWithEnoughFood()
    {
        // Given
        var village = new Village();
        var adam = new Worker("Adam", "woodcutter");
        var bob = new Worker("Bob", "woodcutter");
        village.AddWorker(adam);
        village.AddWorker(bob);

        // When
        village.Day();
        var actual = village.GetFood();

        // Then
        Assert.Equal(8, actual);
        Assert.False(adam.hungry);
    }

    [Fact]
    public void RunDayFunction_WithoutEnoughFood()
    {
        // Given 
        var village = new Village();
        var adam = new Worker("Adam", "woodcutter");
        var bob = new Worker("Bob", "woodcutter");
        village.AddWorker(adam);
        village.AddWorker(bob);

        // When
        for (int i = 0; i < 7; i++)
        {
            village.Day(); // feeding two workers two food each day
        }

        var food = village.GetFood();

        // then
        Assert.True(adam.hungry);
        Assert.True(bob.hungry);
        Assert.Equal(0, food);
    }
}