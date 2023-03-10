namespace The_Village_of_Testing;

public class RunGame
{
    Village village = new Village();

    public void Run()
    {
        var running = true;
        Console.WriteLine("Welcome to the village building game!");

        while (running)
        {
            village.Day();
            Console.WriteLine("What would you like to do now?");
            Console.WriteLine("1. Add a new worker");
            Console.WriteLine("2. Add a new project");
            Console.WriteLine("3. Bury dead workers");
            Console.WriteLine("4. Check resources");
            Console.WriteLine("5. Check finished buildings");
            Console.WriteLine("6. Check ongoing buildings");
            Console.WriteLine("7. Print workers.");
            Console.WriteLine("Write \"quit\" to exit.");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddWorker();
                    break;
                case "2":
                    AddProject();
                    break;
                case "3":
                    Bury();
                    break;
                case "4":
                    CheckResources();
                    break;
                case "5":
                    CheckFinishedBuildings();
                    break;
                case "6":
                    CheckUnfinishedBuildings();
                    break;
                case "7":
                    PrintWorkers();
                    break;
                case "quit":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Not applicable option.");
                    break;
            }

            if (village.GetWorkers().Count == 0)
            {
                Console.WriteLine("Game Over.");
                running = false;
            }
        }
    }

    private void PrintWorkers()
    {
        var workerList = village.GetWorkers();
        foreach (var worker in workerList)
        {
            Console.WriteLine($"Name: {worker.name}, Occupation: {worker.occupation}");
        }
    }

    private void CheckUnfinishedBuildings()
    {
        var unfinishedBuildings = village.GetUnfinishedBuildings();
        foreach (var building in unfinishedBuildings)
        {
            Console.WriteLine(building.name);
        }
    }

    private void CheckFinishedBuildings()
    {
        var buildings = village.GetBuildings();
        foreach (var building in buildings)
        {
            Console.WriteLine(building.name);
        }
    }

    private void CheckResources()
    {
        var food = village.GetFood();
        var wood = village.GetWood();
        var metal = village.GetMetal();
        Console.WriteLine($"You have {food} food, {wood} wood and {metal} metal.");
    }

    private void Bury()
    {
        village.BuryDead();
    }

    private void AddProject()
    {
        Console.WriteLine("What project do you want to add? House, woodmill, quarry, farm, castle.");
        var buildingName = Console.ReadLine();
        Building building = null;
        switch (buildingName.ToLower())
        {
            case "house":
                building = new Building("house", 3, 5, 0);
                break;
            case "woodmill":
                building = new Building("woodmill", 5, 5, 1);
                break;
            case "quarry":
                building = new Building("quarry", 7, 3, 5);
                break;
            case "farm":
                building = new Building("farm", 5, 5, 2);
                break;
            case "castle":
                building = new Building("castle", 50, 50, 50);
                break;
            default:
                Console.WriteLine("Not valid building.");
                break;
        }

        village.AddProject(building);
    }

    private void AddWorker()
    {
        Console.WriteLine("What's the name?");
        var name = Console.ReadLine();
        Console.WriteLine("What's the occupation? Woodcutter, miner, farmer or builder?");
        var occupation = Console.ReadLine();
        if (occupation.ToLower() == "woodcutter" ||
            occupation.ToLower() == "miner" ||
            occupation.ToLower() == "farmer" ||
            occupation.ToLower() == "builder")
        {
            var worker = new Worker(name, occupation);
            village.AddWorker(worker);
        }
        else
        {
            Console.WriteLine("The occupation is not valid.");
        }
    }
}