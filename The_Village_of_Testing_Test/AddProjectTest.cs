using The_Village_of_Testing;

namespace The_Village_of_Testing_Test;

public class AddProjectTest
{
    [Fact]
    public void AddOneProject_WithEnoughResources()
    {
        // Given 
        var village = new Village();
        village.SetWood(5);
        village.SetMetal(1);
        
        // When
        var woodmill = new Building("woodmill", 5, 5, 1);
        village.AddProject(woodmill);
        var currentWoodAmount = village.GetWood();
        var currentMetalAmount = village.GetMetal();

        // then
        Assert.Single(village.GetUnfinishedBuildings());
        Assert.Equal(0, currentWoodAmount); // test if resources are deducted correctly
        Assert.Equal(0, currentMetalAmount); 
    }
    
    [Fact]
    public void AddOneProject_WithoutEnoughResources()
    {
        // Given 
        var village = new Village();

        // When
        var woodmill = new Building("woodmill", 5, 5, 1);
        village.AddProject(woodmill);
        
        // Then
        Assert.Empty(village.GetUnfinishedBuildings());
    }
}