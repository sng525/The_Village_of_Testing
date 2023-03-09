namespace The_Village_of_Testing;

public class Building
{
    public string name;
    public bool complete;
    public int daysToComplete;
    public int daysHaveSpent;
    public int woodCost;
    public int metalCost;

    public Building(string name, int daysToComplete, int woodCost, int metalCost)
    {
        this.name = name;
        this.daysToComplete = daysToComplete;
        this.woodCost = woodCost;
        this.metalCost = metalCost;
        complete = false;
        daysHaveSpent = 0;
    }
}