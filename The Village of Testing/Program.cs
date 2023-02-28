using TheVillageofTesting;

namespace The_Village_of_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO Gör så att konstruktorn till Village skapar tre hus och ger byn 10 mat.
            Village village = new Village(new List<Building>(3), 10);
            
            // TODO Om listan av Workers nu blir tom skriv ut ”Game Over”.
            if (village.GetWorkers().Count == 0)
            {
                Console.WriteLine("Game Over.");
            }
            
        }
    }
}

