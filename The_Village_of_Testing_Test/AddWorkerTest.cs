using The_Village_of_Testing;

namespace The_Village_of_Testing_Test;

public class AddWorkerTest
{
    [Fact]
    public void AddOneWorker_TheNumberOfWorkersShouldBeOne()
    {
        // Given
        var village = new Village();
        var adam = new Worker("Adam", "woodcutter");

        // When
        village.AddWorker(adam);
        var actual = village.GetWorkers().Count;

        // Then
        Assert.Equal(1, actual);
    }

    [Fact]
    public void AddTwoWorkers_TheNumberOfWorkersShouldBeTwo()
    {
        // Given
        var village = new Village();
        var adam = new Worker("Adam", "woodcutter");
        var alex = new Worker("Alex", "farmer");

        // When
        village.AddWorker(adam);
        village.AddWorker(alex);
        var actual = village.GetWorkers().Count;

        // Then
        Assert.Equal(2, actual);
    }

    [Fact]
    public void AddThreeWorkers_TheNumberOfWorkersShouldBeThree()
    {
        // Given
        var village = new Village();
        var adam = new Worker("Adam", "woodcutter");
        var alex = new Worker("Alex", "farmer");
        var bob = new Worker("Bob", "miner");

        // When
        village.AddWorker(adam);
        village.AddWorker(alex);
        village.AddWorker(bob);
        int actual = village.GetWorkers().Count;

        // Then
        Assert.Equal(3, actual);
    }

    [Fact]
    public void AddSevenWorkers_WithThreeHouses_NumberOfWorkersShouldBeSix()
    {
        // Given
        var village = new Village();
        var adam = new Worker("Adam", "woodcutter");
        var axel = new Worker("Axel", "farmer");
        var bob = new Worker("Bob", "miner");
        var cindy = new Worker("Cindy", "builder");
        var mary = new Worker("Mary", "woodcutter");
        var david = new Worker("David", "farmer");
        var eva = new Worker("Eva", "miner");


        // When
        village.AddWorker(adam);
        village.AddWorker(axel);
        village.AddWorker(bob);
        village.AddWorker(cindy);
        village.AddWorker(mary);
        village.AddWorker(david);
        village.AddWorker(eva);
        var actual = village.GetWorkers().Count;

        // Then
        Assert.Equal(6, actual); // when adding the seventh worker, there is no enough house
    }

    [Fact]
    public void AddWorker_ThenCallDayFunction()
    {
        // Given
        var village = new Village();
        var adam = new Worker("Adam", "woodcutter");
        village.AddWorker(adam);

        // When
        village.Day();
        var actual = village.GetFood();
        var numOfWorkers = village.GetWorkers().Count;

        // Then
        Assert.Equal(9, actual);
        Assert.Equal(1, numOfWorkers);
    }
}