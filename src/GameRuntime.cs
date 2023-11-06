using Map;

namespace GameRuntime
{
    class GameRuntime
    {
        //local use, actual variables will be sent to STATS file
        static string name = "";
        static string townName = "NAME LATER PLS";

        static void Main(string[] args)
        {
            //the game functions through this file. This is the file you need to open to launch the game
            //this file keeps track of the progression and invokes the methods from other files
            Console.WriteLine("Welcome to FOODMAN!");
            Console.WriteLine("In this whimsical text-based game, you step into the shoes of a clever and compassionate citizen on a quest to tackle the issues of food waste in his town!");
            Naming();
            //Disclaimer? If needed
            Intro();
            //SET THE STAMINA, DAY, OTHER STUFF THAT NEEDS TO BE SET
            //Launch the Map, if that's what we start with. This would probably work but I'm not sure
            Map mapClass = new Map();
            mapClass.OpenMap();
        }

        static void Naming()
        {
            Console.Write("What is your name?: ");
            name = Console.ReadLine();
            //make sure this variable cannot be null, set the name in the stats file
            if (name != "" && name != " ")
            {
                Console.WriteLine($"Great! {name}, let's start!");
                Console.WriteLine("=======================================");
            }
            else
            {
                Console.WriteLine("Something went wrong... Please try again");
                Naming();
            }
        }

        static void Intro()
        {
            Console.WriteLine($"You, {name}, believe that the issue of food waste plagues the town {townName} too much for too long. Join them on a journey to various locations, each with their own unique challenge!");
            Console.WriteLine();
            Console.WriteLine("To save the day, you'll need to solve specific riddles and discover real ways of dealing with many food issues the world faces.");
            Console.WriteLine();
            Console.WriteLine("Are you ready? Let the adventure begin!");
            Console.WriteLine("=======================================");
        }
    }
}
