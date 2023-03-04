using TheVillageofTesting;

namespace The_Village_of_Testing;

public class Worker
{
    public string name;
    public string occupation;
    public bool hungry = false;
    public int daysHungry = 0;
    public bool alive = true;
    Village village;

    // TODO en delegate/functional interface som innehåller vad som händer när de arbetar.

    public Worker(string name, string occupation)
    {
        this.name = name;
        this.occupation = occupation;
    }
    
    public bool DoWork(Worker worker)
    {
        // TODO kallar på en delegate/functional interface som finns skapad som ett objekt i Worker.

        // TODO check så att en arbetare bara arbetar ifall de inte är hungriga.
        // TODO om alive är false så går det varken att mata arbetaren eller få denna att arbeta.
        if (hungry || alive == false)
        {
            return false;
        }
        
        switch (worker.occupation)
        {
            // TODO Denna skall kalla en av fyra funktioner i Village.
            case "woodwill":
                village.AddWood();
                break;
            case "farm":
                village.AddFood();
                break;
            case "quarry":
                village.AddMetal();
                break;
            case "builder":
                village.Build();
                break;
        }
        
        return true;
    }

    public bool FeedWorker()
    {
        // TODO varje Worker subtraheras 1 mat från byns resurser
        var food = village.GetFood();

        // TODO inte har tillräcklig mat, sätt ”hungry” till true i Worker på de som inte fick mat
        // TODO Om de blir hungriga så ökas daysHungry med 1.
        // TODO om daysHungry når 40 eller högre, sätt alive till false. 
        if (food <= 0)
        {
            hungry = true;
            daysHungry += 1;
            if (daysHungry >= 40)
            {
                alive = false;
                return false;
            }
        }

        // TODO Om de någonsin får mat, sätt daysHungry till 0 och hungry till false.
        hungry = false;
        daysHungry = 0;

        village.SetFood(food - 1);
        return true;
    }
}