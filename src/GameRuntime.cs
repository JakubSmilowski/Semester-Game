namespace foodman
{
    class GameRuntime
    {
        //local use, actual variables will be sent to STATS file
        static string? nameRun = "";
        static string townName = "Foodtown";

        public static void Main(string[] args)
        {
            //the game functions through this file. This is the file you need to open to launch the game
            //this file keeps track of the progression and invokes the methods from other files
            Console.Clear();//to delete the console messages in the begining
            Console.WriteLine("Welcome to FOODMAN!");
            Console.WriteLine("In this whimsical text-based game, you step into the shoes of a clever and compassionate citizen on a quest to tackle the issues of food waste in his town!");
            Console.WriteLine("This game was created to raise the awaraness about the excessive food waste, with the goal to educate the player about everyday life ways to make a big global difference in the direction of more sustainable future, while also providing a great amout of fun!");
            Naming();
            //Disclaimer? If needed
            Intro();
            //SET THE STAMINA, DAY, OTHER STUFF THAT NEEDS TO BE SET
            Map.OpenMap();
        }

        static void Naming()
        {
            Console.Write("What is your name?: ");
            nameRun = Console.ReadLine();
            //LATER maybe make sure this variable cannot be null
            if (nameRun != "" && nameRun != " ")
            {
                Console.WriteLine($"Great! {nameRun}, let's start!");
                if(nameRun != null) Player.ChangeName(nameRun);
                Console.WriteLine("=========================================");
            }
            else
            {
                WentWrong();
                Naming();
            }
        }
        
        static void Intro()
        {
            Console.WriteLine($"You, {nameRun}, believe that the issue of food waste plagues the town {townName} too much for too long. Join them on a journey to various locations, each with their own unique challenge!");
            Console.WriteLine();
            Console.WriteLine("To save the day, you'll need to solve specific riddles and discover real ways of dealing with many food issues the world faces.");
            Console.WriteLine();
            Console.WriteLine("Are you ready? Let the adventure begin!");
            Console.WriteLine("[W] Begin the game");
            string? beginning = Console.ReadLine()?.ToLower();
            Console.Clear();
            if (beginning != "w")
            {
                WentWrong();
                Intro();
            }
        }
        public static void LineSep()
        {
            Console.WriteLine("=========================================");
        }

        public static void WentWrong()
        {
            Console.WriteLine("Something went wrong... Please try again");
        }
    }
}
