using The_Village_of_Testing;

namespace TheVillageofTesting;

public class Village
{
    private int food = 0;
    private int wood = 0;
    private int metal = 0;
    private List<Building> buildings = new List<Building>();
    private List<Building> unfinishedBuildings = new List<Building>();
    private List<Worker> workers = new List<Worker>();
    private int foodPerDay = 0;
    private int woodPerDay = 0;
    private int metalPerDay = 0;
    private int daysGone = 0;

    public Village(List<Building> unfinishedBuildings, int food)
    {
        unfinishedBuildings = unfinishedBuildings;
        food = food;
    }

    public Village()
    {
        
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

    public int GetMetal()
    {
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

    public void AddWood()
    {
        wood++;
    }

    public void AddMetal()
    {
        metal++;
    }

    public void AddFood()
    {
        food += 5;
    }

    public void Build()
    {
        // TODO gå in i listan av projekt, ta den första, och lägga till 1 till antalet arbetsdagar spenderade på byggnaden.
        var onGoingBuilding  = unfinishedBuildings[0];
        onGoingBuilding.daysHaveSpent += 1;
        switch (onGoingBuilding.name)
        {
            case "house":
                onGoingBuilding.daysToComplete = 3;
                onGoingBuilding.woodCost = 5;
                break;
            case "woodmill":
                onGoingBuilding.daysToComplete = 5;
                onGoingBuilding.woodCost = 5;
                onGoingBuilding.metalCost = 1;
                break;
            case "quarry":
                onGoingBuilding.daysToComplete = 7;
                onGoingBuilding.woodCost = 3;
                onGoingBuilding.metalCost = 5;
                break;
            case "farm":
                onGoingBuilding.daysToComplete = 5;
                onGoingBuilding.woodCost = 5;
                onGoingBuilding.metalCost = 2;
                break;
            case "castle":
                onGoingBuilding.daysToComplete = 50;
                onGoingBuilding.woodCost = 50;
                onGoingBuilding.metalCost = 50;
                break;
        }
        
        // TODO daysHaveSpent > daysToComplete så är byggnaden klar.
        // Flytta den från listan av pågående projekt till listan av klara byggnader.

        if (onGoingBuilding.daysHaveSpent > onGoingBuilding.daysToComplete)
        {
            unfinishedBuildings.Remove(onGoingBuilding);
            buildings.Add(onGoingBuilding);
        }
    }

    public void Day()
    {
        // TODO kalla DoWork() på alla Workers.
        // TODO mata alla arbetare.
        // TODO loopa igenom alla dina arbetare, mata dem och sedan kalla på DoWork() på varje.

        foreach (var worker in workers)
        {
            worker.FeedWorker();
            worker.DoWork();
        }
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

    public bool AddProject(Building building)
    {
        // TODO ifall man har tillräckligt med resurser
        if (food > 0 && wood > 0 && metal > 0)
        {
            unfinishedBuildings.Add(building);
            return true;
        }
        return false;
    }

    public bool AddWorker(Worker worker)
    {
        // TODO lägga till en ny arbetare, men bara om det finns tillräckligt med hus för dem.
        if (unfinishedBuildings.Count > 0)
        {
            workers.Add(worker);
            return true;
        }

        return false;
    }
}