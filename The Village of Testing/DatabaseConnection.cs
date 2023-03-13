namespace The_Village_of_Testing;

public class DatabaseConnection
{
    public virtual void Save(int food, int wood, int metal, int daysGone, List<Building> buildings, List<Building> unfinishedBuildings, List<Worker> workers)
    {
        throw new NotImplementedException();
    }

    public virtual Village Load()
    {
        return null;
    }

    public virtual int GetFood()
    {
        return -1;
    }
    
    public virtual int GetWood()
    {
        return -1;
    }
    
    public virtual int GetMetal()
    {
        return -1;
    }
    
    public virtual List<Building> GetBuildings()
    {
        return null;
    }
    
    public virtual List<Building> GetUnifinishedBuildings()
    {
        return null;
    }
    
    public virtual List<Worker> GetWorkers()
    {
        return null;
    }
    
    public virtual int GetDaysGone()
    {
        return -1;
    }
}