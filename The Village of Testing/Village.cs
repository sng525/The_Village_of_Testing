using System.Threading.Channels;
using static The_Village_of_Testing.Building;

namespace The_Village_of_Testing;

public class Village
{
    private int _food;
    private int _wood;
    private int _metal;
    private List<Building> _buildings;
    private List<Building> _unfinishedBuildings;
    private List<Worker> _workers;
    public int FoodPerDay = 5;
    public int WoodPerDay = 1;
    public int MetalPerDay = 1;
    private int _daysGone;

    DatabaseConnection dbConnection;
    RandomClass random = new RandomClass();

    public Village(DatabaseConnection dbConnection, RandomClass random)
    {
        _food = 10;
        _wood = 0;
        _metal = 0;
        _buildings = new List<Building>();
        _unfinishedBuildings = new List<Building>();
        _workers = new List<Worker>();
        _daysGone = 0;
        this.dbConnection = dbConnection;
        this.random = random;
    }

    public Village()
    {
        _food = 10;
        _wood = 0;
        _metal = 0;
        _buildings = new List<Building>();
        _unfinishedBuildings = new List<Building>();
        _workers = new List<Worker>();
        _daysGone = 0;
        _buildings.Add(new Building("house", 3, 5, 0));
        _buildings.Add(new Building("house", 3, 5, 0));
        _buildings.Add(new Building("house", 3, 5, 0));
        dbConnection = new DatabaseConnection();
        random = new RandomClass();
    }

    public int GetFood()
    {
        return _food;
    }

    public void SetFood(int food)
    {
        _food = food;
    }

    public int GetWood()
    {
        return _wood;
    }

    public void SetWood(int wood)
    {
        _wood = wood;
    }

    public int GetMetal()
    {
        return _metal;
    }

    public void SetMetal(int metal)
    {
        _metal = metal;
    }

    public List<Building> GetBuildings()
    {
        return _buildings;
    }
    
    public void SetBuildings(List<Building> buildings)
    {
        _buildings = buildings;
    }

    public List<Building> GetUnfinishedBuildings()
    {
        return _unfinishedBuildings;
    }
    
    public void SetUnfinishedBuildings(List<Building> unfinishedBuildings)
    {
        _unfinishedBuildings = unfinishedBuildings;
    }

    public List<Worker> GetWorkers()
    {
        return _workers;
    }
    
    public void SetWorkers(List<Worker> workers)
    {
        _workers = workers;
    }

    public void SetWorkers(Worker worker)
    {
        _workers.Add(worker);
    }

    public int GetDaysGone()
    {
        return _daysGone;
    }
    
    public void SetDaysGone(int daysGone)
    {
        _daysGone = daysGone;
    }

    public void AddFood()
    {
        _food += FoodPerDay;
    }

    public void AddWood()
    {
        _wood += WoodPerDay;
    }

    public void AddMetal()
    {
        _metal += MetalPerDay;
    }

    public void Build()
    {
        var currentBuilding = _unfinishedBuildings[0];
        currentBuilding.daysHaveSpent++;

        if (currentBuilding.daysHaveSpent >= currentBuilding.daysToComplete)
        {
            currentBuilding.complete = true;
            _unfinishedBuildings.Remove(currentBuilding);
            _buildings.Add(currentBuilding);
            Console.WriteLine($"{currentBuilding.name} has been completed.");

            switch (currentBuilding.name)
            {
                case "woodmill":
                    WoodPerDay += 2;
                    break;
                case "quarry":
                    MetalPerDay += 2;
                    break;
                case "farm":
                    FoodPerDay += 10;
                    break;
                case "castle":
                    Console.WriteLine("The castle is complete! You won! You took " + _daysGone + " days");
                    break;
            }
        }
    }

    public void Day()
    {
        _daysGone++;

        if (_workers.Count == 0)
        {
            Console.WriteLine("There is no available worker.");
        }

        FeedWorkers();

        foreach (Worker worker in _workers)
        {
            worker.DoWork(this);
        }
    }

    public void FeedWorkers()
    {
        foreach (var worker in _workers)
        {
            if (worker.daysHungry >= 40)
            {
                worker.alive = false;
                Console.WriteLine($"{worker.name} is not alive. It's not available to feed.");
            }
            else if (_food <= 0)
            {
                worker.hungry = true;
                worker.daysHungry++;
            }
            else
            {
                _food--;
                worker.hungry = false;
                worker.daysHungry = 0;
            }
        }
    }

    public void BuryDead()
    {
        for (int i = 0; i < _workers.Count; i++)
        {
            if (_workers[i].alive == false)
            {
                _workers.Remove(_workers[i]);
            }
        }
    }

    public void AddProject(Building building)
    {
        if (_food > 0 && _wood >= building.woodCost && _metal >= building.metalCost)
        {
            _unfinishedBuildings.Add(building);
            _wood -= building.woodCost;
            _metal -= building.metalCost;
            Console.WriteLine(building.name + " has been added.");
        }
        else
        {
            Console.WriteLine("There are not enough sources.");
        }
    }

    public void AddWorker(Worker worker)
    {
        var houseNum = _buildings.Count(building => building.name == "house");
        var workerNum = _workers.Count;

        if (workerNum / houseNum >= 2)
        {
            Console.WriteLine("There is not enough house.");
        }
        else
        {
            _workers.Add(worker);
            Console.WriteLine(worker.name + " has been added.");
        }
    }

    public void SaveProgress()
    {
        dbConnection.Save(_food, _wood, _metal,  _daysGone, _buildings, _unfinishedBuildings, _workers);
    }

    public void LoadProgress()
    {
        dbConnection.Load();
        SetFood(dbConnection.GetFood());
        SetMetal(dbConnection.GetMetal());
        SetWood(dbConnection.GetWood());
        SetBuildings(dbConnection.GetBuildings());
        SetUnfinishedBuildings(dbConnection.GetUnifinishedBuildings());
        SetWorkers(dbConnection.GetWorkers());
        SetDaysGone(dbConnection.GetDaysGone());
    }

        public void AddRandomWorker(int nameLength)
    {
        var worker = random.ReturnRandomWorker(nameLength);
        _workers.Add(worker);
    }
}