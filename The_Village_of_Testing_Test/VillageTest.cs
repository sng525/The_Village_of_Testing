using The_Village_of_Testing;

namespace The_Village_of_Testing_Test;

public class VillageTest
{

    // Test AddWorker()
    // TODO 1 Tar en delegate/functional interface för vilken funktion som man kör efteråt.
    
    // 1 Testa om man lägger till en arbetare. Sedan två. Sedan tre. Assert att det finns så många som det borde. 
    [Fact]
    public void AddOneWorker_WorkerListShouldCountOne()
    {
        // given
        var village = new Village();
        var adam = new Worker("Adam", "woodmill");
        int expected = 1;
        
        // when
        village.AddWorker(adam);
        int actual = village.GetWorkers().Count;
        
        // then
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void AddTwoWorker_WorkerListShouldCountTwo()
    {
        // given
        var village = new Village();
        var adam = new Worker("Adam", "woodmill");
        var alex = new Worker("Alex", "farm");
        int expected = 2;
        
        // when
        village.AddWorker(adam);
        village.AddWorker(alex);
        int actual = village.GetWorkers().Count;
        
        // then
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void AddThreeWorker_WorkerListShouldCountThree()
    {
        // given
        var village = new Village();
        var adam = new Worker("Adam", "woodmill");
        var alex = new Worker("Alex", "farm");
        var bob = new Worker("Bob", "quarry");
        int expected = 3;
        
        // when
        village.AddWorker(adam);
        village.AddWorker(alex);
        village.AddWorker(bob);
        int actual = village.GetWorkers().Count;
        
        // then
        Assert.Equal(expected, actual);
    }
    
    // 2 Testa om man försöker lägga till en arbetare men det finns inte tillräckligt med hus.
    [Fact]
    public void AddWorkerWithoutEnoughHouses()
    {
        // given
        var village = new Village();
        var adam = new Worker("Adam", "woodmill");
        var axel = new Worker("Axel", "farm");
        var bob = new Worker("Bob", "quarry");
        var cindy = new Worker("Cindy", "builder");
        var mary = new Worker("Mary", "woodmill");
        var david = new Worker("David", "farm");
        var eva = new Worker("Eva", "quarry");

        // when
        village.AddWorker(adam);
        village.AddWorker(axel);
        village.AddWorker(bob);
        village.AddWorker(cindy);
        village.AddWorker(mary);
        village.AddWorker(david);
        var actual = village.AddWorker(eva);
        
        // then
        Assert.False(actual); // when adding the seventh worker, there is no enough house, should return false
    }

    // TODO 2 Testa om rätt sak händer om man skapar en ny arbetare med en funktion och sedan kallar Day();
    [Fact]
    public void AddWorkerThenCallDayFunction()
    {
        // given
        var village = new Village();
        var adam = new Worker("Adam", "woodmill");
        village.AddWorker(adam);
        
        // when
        village.Day();
        
        // then ?
    }
    
    
    // Test Day()
    // 1 Testa att inte ha några arbetare och köra Day()
    [Fact]
    public void NoWorker_ThenTryDay_ShouldReturnFalse()
    {
        // given
        var village = new Village();

        // when
        var actual = village.Day();

        // then
        Assert.False(actual);
    }
    
    // 2 Testa att lägga till lite arbetare och köra Day() medans man har tillräckligt med mat.
    [Fact]
    public void AddTwoWorkers_ThenTryDayWithEnoughFood_ShouldReturnTrue()
    {
        // given
        var village = new Village();
        var adam = new Worker("Adam", "woodmill");
        var bob = new Worker("Bob", "woodmill");
        village.AddWorker(adam);
        village.AddWorker(bob);

        // when
        var actual = village.Day();

        // then
        Assert.True(actual);
    }
    
    // TODO 3 Testa Day() men det inte finns tillräckligt med mat, se till att rätt saker händer.
    [Fact]
    public void RunDay_WithoutEnoughtFood()
    {
        // given 
        var village = new Village();
        var adam = new Worker("Adam", "woodmill");
        var bob = new Worker("Bob", "woodmill"); // add two workers
        village.AddWorker(adam);
        village.AddWorker(bob);

        // when
        for (int i = 0; i < 7; i++)
        {
            village.Day(); // 2 food will be consumed each day because of two workers 
        }

        var actual = adam.FeedWorker();
        var food = village.GetFood();

        // then
        Assert.Equal(0, food); // the sixth day, there is no enough food, should return false
    }
    
    
    // Test AddProject()
    // 1 Testa att lägga till en byggnad som du har råd med. Testa att det funkar och att rätt andel resurser dras.
    [Fact]
    public void AddOneProject_WithEnoughResouces()
    {
        // given 
        var village = new Village();
        var woodAmount = 5;
        var metalAmount = 1;
        village.SetWood(woodAmount);
        village.SetMetal(metalAmount);
        
        // when
        var woodmill = new Building("woodmill", 5, 5, 1);
        var actual = village.AddBuilding(woodmill);
        var currentWoodAmount = village.GetWood();
        var currentMetalAmount = village.GetMetal();

        // then
        Assert.True(actual); // test if adding the project successfully under enough resources
        Assert.Equal(currentWoodAmount, 0); // test if resources are deducted correctly
        Assert.Equal(currentMetalAmount, 0); 
    }
    
    // 2 Testa att försöka lägga till en byggnad som man inte har råd med och se till att det inte funkar.
    [Fact]
    public void AddOneProject_WithoutEnoughResources()
    {
        // given 
        var village = new Village();

        // when
        var woodmill = new Building("woodmill", 5, 5, 1);
        var actual = village.AddBuilding(woodmill);
        
        // then
        Assert.False(actual);
    }
    
    
    // Other test
    // TODO 4 Kör först Day() en dag innan en WoodMill blir klar. Se att du får 1 ved först,
    // sedan mer ved Day() efter då byggnaden blev klar. Testet behöver en arbetare som gör ved och en som bygger.
    [Fact]
    public void DayBeforeAndAfterWoodMillIsReady_CollectExtraWood()
    {
        // given
        var village = new Village();
        var woodmill = new Building("woodmill", 5, 5, 1);
        village.AddBuilding(woodmill);
        
        village.AddWorker(new Worker("Adam", "woodmill"));
        village.AddWorker(new Worker("Bob", "builder"));
        
        // when
        for (int i = 0; i < 4; i++) // run 4 days
        {
            village.Day();
        }
        
        // then
        Assert.Equal(1, village.woodPerDay); 
        Assert.Equal(4, village.GetDaysGone());
        Assert.False(village.GetUnfinishedBuildings()[0].complete);
        
        // when
        village.Day();
        var woodPerDayAfterWoodMillFinished = village.woodPerDay;

        // then
        // Assert.True(village.GetUnfinishedBuildings()[0].complete); // woodmill finished 
        Assert.Equal(2, woodPerDayAfterWoodMillFinished);
    }
    
    // 2. Gör detsamma slags tester för mat och metall.
    [Fact]
    public void DayBeforeAndAfterFarmIsReady_CollectExtraFood()
    {
        // given
        var village = new Village();
        var farm = new Building("farm", 5, 5, 2);
        
        village.AddBuilding(farm);
        village.AddWorker(new Worker("Jimmy", "farm"));

        // when
        for (int i = 0; i < 4; i++) // run 4 days
        {
            village.Day();
        }
        
        // then
        Assert.Equal(5, village.foodPerDay); 
        Assert.Equal(4, village.GetDaysGone());
        Assert.False(village.GetUnfinishedBuildings()[0].complete);
        
        // when
        village.Day();
        var woodPerDayAfterFarmFinished = village.foodPerDay;

        // then
        Assert.Equal(10, woodPerDayAfterFarmFinished);
    }
    
    [Fact]
    public void DayBeforeAndAfterQuarryIsReady_CollectExtraMetal()
    {
        // given
        var village = new Village();
        var quarry = new Building("quarry", 7, 3, 5);
        village.AddBuilding(quarry);
        
        village.AddWorker(new Worker("David", "quarry"));

        // when
        for (int i = 0; i < 6; i++) // run 6 days
        {
            village.Day();
        }
        
        // then
        Assert.Equal(1, village.metalPerDay); 
        Assert.Equal(6, village.GetDaysGone());
        Assert.False(village.GetUnfinishedBuildings()[0].complete);
        
        // when
        village.Day();
        var woodPerDayAfterQuarryFinished = village.metalPerDay;

        // then
        // Assert.True(village.GetUnfinishedBuildings()[1].complete); // quarry finished 
        Assert.Equal(2, woodPerDayAfterQuarryFinished);
    }
    
    // 3 Testa att starta byggnaden av ett hus, sedan sätta några arbetare på det,
    // och sedan att rätt antal Day() funktioner blir klart med projektet.
    [Fact]
    public void BuildAHouse()
    {
        // given
        var village = new Village();
        var daniel = new Worker("Daniel", "builder");
        var bob = new Worker("Bob", "builder");
        var house = new Building("house", 3, 5, 0);

        // when
        village.AddBuilding(house);  
        village.AddWorker(daniel);
        village.AddWorker(bob);
        
        // village.Day();
        // village.Day(); 
        // village.Day(); 

        // then
        //Assert.Contains(house, village.GetBuildings()); // check if the house is finished
    }
}