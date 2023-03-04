using TheVillageofTesting;

namespace The_Village_of_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO Gör så att konstruktorn till Village skapar tre hus och ger byn 10 mat.
            Village village = new Village();

            // TODO Om listan av Workers nu blir tom skriv ut ”Game Over”.
            if (village.GetWorkers().Count == 0)
            {
                Console.WriteLine("Game Over.");
            }

            Console.WriteLine("What building do you want to build? ");
            var building = Console.ReadLine();
            switch (building)
            {
                case "house":
                    var house = new Building("house", 3, 0, 3);
                    break;
            }

        }
    }
}

