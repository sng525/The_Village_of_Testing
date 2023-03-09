namespace The_Village_of_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameIsOn = true;
            Console.WriteLine("Welcome to the village building game!");
            Console.WriteLine("Note: there are 3 houses in the village and you add at most six workers before you build more houses.");
            
            while (gameIsOn)
            {
                Village village = new Village();
                Console.WriteLine("What do you want to do now?");
                Console.WriteLine("1. Add a new worker ");
                Console.WriteLine("2. Add a new project ");
                Console.WriteLine("3.  ");
                
                var task = Console.ReadLine();

                switch (task)
                {
                    case "1":
                        Console.WriteLine("What's the worker's name?");
                        var workerName = Console.ReadLine();
                        Console.WriteLine("What's do you want this worker to do? wood");
                        break;
                }

                switch (task)
                {
                    case "house":
                        var house = new Building("house", 3, 0, 0);
                        village.AddProject(house);
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
}

