using The_Village_of_Testing;

namespace The_Village_of_Testing_Test;

public class BuildACastleTEst
{
    [Fact]
    public void BuildACastleTest()
    {
        // Given
        var village = new Village();
        village.SetWood(100);
        village.SetMetal(100);
        village.SetFood(100);
        var castle = new Building("castle", 50, 50, 50);
        village.AddProject(castle);

        //village.AddWorker(new Worker("David", "builder"));
        village.AddWorker(new Worker("Jessi", "builder"));

        // When
        while (castle.complete == false)
        {
            village.Day();
        }

        // Then
        Assert.Equal(50, village.GetDaysGone());
        Assert.True(castle.complete);
    }
}