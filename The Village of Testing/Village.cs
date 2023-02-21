namespace The_Village_of_Testing;

public class Village
{
    private int _food = 10;
    private int _wood = 0;
    private int _metal = 0;
    private List<Building> _buildings = new List<Building>();
    private List<Building> _unfinishedBuildings = new List<Building>();
    private List<Worker> _workers = new List<Worker>();
    private int _daysGone = 0;

    public Village(int food, int wood, int metal)
    {
        _food = food;
        _wood = wood;
        _metal = metal;
    }

    public int GetFood()
    {
        return _food;
    }

    public int Wood()
    {
        return _wood;
    }

    public int Metal()
    {
        return _metal;
    }

    public List<Building> Buildings()
    {
        return _buildings;
    }

    public List<Building> UnfinishedBuildings()
    {
        return _unfinishedBuildings;
    }

    public List<Worker> Workers()
    { 
        return _workers;
    }

    public int DaysGone()
    {
        return _daysGone;
    }

    public void AddWood()
    {
        _wood++;
    }
    
    public void AddMetal()
    {
        _metal++;
    }
    
    public void AddFood()
    {
        _food += 5;
    }

    public void Build()
    {
        
    }

    public void Day()
    {
        // TODO kalla DoWork() på alla Workers.
        // TODO mata alla arbetare.
    }

    public void BuryDead()
    {
        // TODO tar bort alla Workers som har ”alive = false” ur listan Workers
        // TODO Om listan av Workers nu blir tom skriv ut ”Game Over”.
    }

    public void AddProject()
    {
        
    }
}