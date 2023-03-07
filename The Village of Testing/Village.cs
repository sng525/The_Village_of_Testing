namespace The_Village_of_Testing;

public class Village
{
    private int food;
    private int wood;
    private int metal;
    private List<Building> buildings;
    private List<Building> unfinishedBuildings;
    private List<Worker> workers;
    public int foodPerDay = 5;
    public int woodPerDay = 1;
    public int metalPerDay = 1;
    public int daysGone;

    public Village()
    {
        food = 10;
        wood = 0;
        metal = 0;
        buildings = new List<Building>();
        unfinishedBuildings = new List<Building>(1000);
        workers = new List<Worker>();
        daysGone = 0;
        buildings.Add(new Building("house", 3, 5, 0));
        buildings.Add(new Building("house", 3, 5, 0));
        buildings.Add(new Building("house", 3, 5, 0));
    }

    public int GetFood()
    {
        return food;
    }

    public int SetFood(int food)
    {
        this.food = food;
        return food;
    }

    public int GetWood()
    {
        return wood;
    }

    public int SetWood(int wood)
    {
        this.wood = wood;
        return wood;
    }

    public int GetMetal()
    {
        return metal;
    }

    public int SetMetal(int metal)
    {
        this.metal = metal;
        return metal;
    }

    public List<Building> GetBuildings()
    {
        return buildings;
    }

    public List<Building> GetUnfinishedBuildings()
    {
        return unfinishedBuildings;
    }

    public List<Worker> GetWorkers()
    {
        return workers;
    }

    public int GetDaysGone()
    {
        return daysGone;
    }

    public void AddFood()
    {
        food += foodPerDay;
    }

    public void AddWood()
    {
        wood += woodPerDay;
    }

    public void AddMetal()
    {
        metal += metalPerDay;
    }

    public void Build()
    {
        // TODO gå in i listan av projekt, ta den första, och lägga till 1 till antalet arbetsdagar spenderade på byggnaden.
        Building currentBuilding = unfinishedBuildings[0];
        switch (currentBuilding.name)
        {
            case "house":
                currentBuilding.daysToComplete = 3;
                currentBuilding.daysHaveSpent += 1;
                break;
            case "woodmill":
                currentBuilding.daysToComplete = 5;
                currentBuilding.daysHaveSpent += 1;
                break;
            case "quarry":
                currentBuilding.daysToComplete = 7;
                currentBuilding.daysHaveSpent += 1;
                break;
            case "farm":
                currentBuilding.daysToComplete = 5;
                currentBuilding.daysHaveSpent += 1;
                break;
            case "castle":
                currentBuilding.daysToComplete = 50;
                currentBuilding.daysHaveSpent += 1;
                Console.WriteLine("The castle is complete! You won! You took " + daysGone + " days");
                break;
        }

        if (currentBuilding.daysHaveSpent >= currentBuilding.daysToComplete)
        {
            currentBuilding.complete = true;
            unfinishedBuildings.Remove(currentBuilding);
            buildings.Add(currentBuilding);
            Console.WriteLine(currentBuilding.name + "has been completed.");
            switch (currentBuilding.name)
            {
                case "woodmill":
                    woodPerDay += 2;
                    break;
                case "quarry":
                    metalPerDay += 2;
                    break;
                case "farm":
                    foodPerDay += 10;
                    break;
            }
        }
    }

    public bool Day()
    {
        daysGone++;

        if (workers.Count == 0)
        {
            Console.WriteLine("There is no available worker.");
            return false;
        }

        foreach (Worker worker in workers)
        {
            worker.FeedWorker();
            worker.DoWork(worker);
        }

        return true;
    }

    public void BuryDead()
    {
        // TODO tar bort alla Workers som har ”alive = false” ur listan Workers
        foreach (var worker in workers)
        {
            if (worker.alive == false)
            {
                workers.Remove(worker);
            }
        }
    }

    public bool AddBuilding(Building building)
    {
        if (food > 0 && wood >= building.woodCost && metal >= building.metalCost)
        {
            unfinishedBuildings.Add(building);
            wood -= building.woodCost;
            metal -= building.metalCost;
            Console.WriteLine(building.name + " has been added.");
            return true;
        }

        Console.WriteLine("There are not enough sources.");
        return false;
    }

    public bool AddWorker(Worker worker)
    {
        // TODO lägga till en ny arbetare, men bara om det finns tillräckligt med hus för dem.
        var houseNum = buildings.Count(building => building.name == "house");
        var workerNum = workers.Count();

        if (workerNum == 0)
        {
            workers.Add(worker);
            Console.WriteLine(worker.name + " has been added.");
            return true;
        }

        if (workerNum % houseNum == 0)
        {
            Console.WriteLine("There is not enough house.");
            return false;
        }

        workers.Add(worker);
        Console.WriteLine(worker.name + "has been added.");
        return true;
    }
}