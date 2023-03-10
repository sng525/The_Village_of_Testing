using System.ComponentModel;

namespace The_Village_of_Testing;

public class Worker
{
    public string name;
    public string occupation;
    public bool hungry;
    public int daysHungry;
    public bool alive;

    public delegate void DoWorkHandler(Village village);

    DoWorkHandler doWorkHandler;

    public Worker(string name, string occupation)
    {
        this.name = name;
        this.occupation = occupation;
        hungry = false;
        daysHungry = 0;
        alive = true;
        switch (this.occupation)
        {
            case "woodcutter":
                doWorkHandler = village => village.AddWood();
                break;
            case "miner":
                doWorkHandler = village => village.AddMetal();
                break;
            case "farmer":
                doWorkHandler = village => village.AddFood();
                break;
            case "builder":
                doWorkHandler = village => village.Build();
                break;
            default:
                throw new ArgumentException($"Invalid occupation: {occupation}");
        }
    }

    public void DoWork(Village village)
    {
        if (hungry == false && alive)
        {
            doWorkHandler(village);
        }
    }
}