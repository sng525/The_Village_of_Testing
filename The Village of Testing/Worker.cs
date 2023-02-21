namespace The_Village_of_Testing;

public class Worker
{
    private string name;
    private string occupation;
    private bool hungry = false;
    private int daysHungry = 0;
    private bool alive = true;

    // TODO en delegate/functional interface som innehåller vad som händer när de arbetar.
    
    public void DoWork()
    {
        // TODO kallar på en delegate/functional interface som finns skapad som ett objekt i Worker.
        // TODO Denna skall kalla en av fyra funktioner i Village.
        
        // TODO check så att en arbetare bara arbetar ifall de inte är hungriga.
    }

    public void FeedWorker()
    {
        // TODO varje Worker subtraheras 1 mat från byns resurser
        // TODO Om de någonsin får mat, sätt daysHungry till 0 och hungry till false.
        
        // TODO om alive är false så går det varken att mata arbetaren eller få denna att arbeta.
        // TODO inte har tillräcklig mat, sätt ”hungry” till true i Worker på de som inte fick mat
        // TODO Om de blir hungriga så ökas daysHungry med 1.
        // TODO om daysHungry når 40 eller högre, sätt alive till false. 
    }
}