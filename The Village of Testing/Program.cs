namespace The_Village_of_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Village village = new Village();
            
            Console.WriteLine("What building do you want to build? ");
            var building = Console.ReadLine();
            
            switch (building)
            {
                case "house":
                    var house = new Building("house", 3, 0, 0);
                    village.AddBuilding(house);
                    break;
            }

            Worker adam = new Worker("Adam", "builder");
            village.AddWorker(adam);
            
            village.Day();
            var leftFood = village.GetFood();
            Console.WriteLine(leftFood);


            if (village.GetWorkers().Count == 0)
            {
                Console.WriteLine("Game Over.");
            }
        }
    }
}

