using Moq;
using The_Village_of_Testing;

namespace The_Village_of_Testing_Test;

public class LoadProgressTest
{
    [Fact]
    public void LoadTest()
    {
        // Given
        var miniHouse = new Building("house", 3, 5, 0);
        List<Building> buildingList = new List<Building>();
        buildingList.Add(miniHouse);
        
        var judy = new Worker("Judy", "woodcutter");
        List<Worker> workerList = new List<Worker>();
        workerList.Add(judy);
        
        var theSecondQuarry = new Building("quarry", 5, 5, 2);
        List<Building> unfinishedBuildingList = new List<Building>();
        unfinishedBuildingList.Add(theSecondQuarry);
        
        // Mock
        Mock<DatabaseConnection> mock = new Mock<DatabaseConnection>();
        Village village = new Village(mock.Object, null);

        // Set up the values
        mock.Setup(mock => mock.Load()).Returns(village);
        mock.Setup(mock => mock.GetFood()).Returns(100);
        mock.Setup(mock => mock.GetWood()).Returns(10000);
        mock.Setup(mock => mock.GetMetal()).Returns(238);
        mock.Setup(mock => mock.GetBuildings()).Returns(buildingList); // house
        mock.Setup(mock => mock.GetUnifinishedBuildings()).Returns(unfinishedBuildingList); // quarry
        mock.Setup(mock => mock.GetWorkers()).Returns(workerList); // judy
        mock.Setup(mock => mock.GetDaysGone()).Returns(2380);

        // When
        village.LoadProgress();
        
        // Then
        Assert.Equal(100, village.GetFood());
        Assert.Equal(10000, village.GetWood());
        Assert.Contains(miniHouse, village.GetBuildings());
        Assert.Contains(theSecondQuarry, village.GetUnfinishedBuildings());
        Assert.Contains(judy, village.GetWorkers());
        Assert.Equal(2380, village.GetDaysGone());
    }
    
    [Fact]
    public void AddRandomWorker_DoRightJobTest()
    {
        // Given
        Mock<RandomClass> mock = new Mock<RandomClass>();
        var village = new Village(null, mock.Object);
        var adam = new Worker("Adam", "farmer");

        mock.Setup((mock) => mock.ReturnRandomWorker(It.IsAny<int>())).Returns(adam);

        // When
        village.AddRandomWorker(10);

        // Then
        Assert.Equal(adam, village.GetWorkers()[0]);
        Assert.Equal("Adam", village.GetWorkers()[0].name);
        Assert.Equal("farmer", village.GetWorkers()[0].occupation);

        // When
        village.Day();
        
        // Then
        Assert.Equal(14, village.GetFood()); // villages starts with 10 food, and Adam collected 5 food that day, consumed 1 food, food should be 14 left
    }
}