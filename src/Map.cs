namespace foodman
{
    class Map
    {
        //Player position, taken from main class
        static int xPos = 5;
        static int yPos = 4;
        //Warehouse position, taken from main class
        static int mxPos = 5;
        static int myPos = 3;
        //Grocery store position
        static int gxPos = 2;
        static int gyPos = 2;
        //Restaraunt position
        static int rxPos = 3;
        static int ryPos = 5;
        //House position
        static int hxPos = 6;
        static int hyPos = 1;
        //Factory position
        static int fxPos = 7;
        static int fyPos = 3;
        //Junkyard position
        static int jxPos = 9;
        static int jyPos = 6;
        //RC position
        static int rcxPos = 1;
        static int rcyPos = 6;

        static string[][] map =
        {
            new string[] { " ", " ", " ", " ", " ", "H", " ", " ", " " },
            new string[] { " ", "G", " ", " ", " ", " ", " ", " ", " " },
            new string[] { " ", " ", " ", " ", "W", " ", "F", " ", " " },
            new string[] { " ", " ", " ", " ", "8", " ", " ", " ", " " },
            new string[] { " ", " ", "R", " ", " ", " ", " ", " ", " " },
            new string[] { "C", " ", " ", " ", " ", " ", " ", " ", "J" },
        };

        static string[] abc = { "A", "B", "C", "D", "E", "F" };
        static string? playerCommand = "";

        static void DrawText()
        {
            GameRuntime.LineSep();
            Console.WriteLine($"Today is  {Player.currentlyDate.ToShortDateString()}");
            Console.WriteLine($"You have {Player.actionPoints} action points left");
            GameRuntime.LineSep();
            Console.WriteLine("[W]Up [A]Left [S]Down [D]Right");
            Console.WriteLine("Type 'help' for more information.");
            Console.Write("Enter your command... ");
            playerCommand = Console.ReadLine()?.ToLower();
            ReadPlayerInput();
        }

        static void DrawMap()
        {
            Console.Clear();// To not douplicate the map in console while moving
            //Map's top frame
            GameRuntime.LineSep();
            for (int j = 0; j <= 9; j++)
            {
                Console.Write($"| {j} ");
            }
            //Map itself
            Console.WriteLine("|");
            for (int i = 0; i < map.Length; i++)
            {
                Console.Write($"| {abc[i]} |");
                for (int j = 0; j < map[i].Length; j++)
                {
                    Console.Write($" {map[i][j]} |");
                }
                Console.WriteLine();
            }
        }

        static void ReadPlayerInput()
        {
            //If the player asks for help with commands and meaning of symbols
            if ( playerCommand == "help" || playerCommand == "h")
            {
                HelpPlayer();
            }

            //player movement
            if (Player.IsActionPossible())
            {
            map[yPos - 1][xPos - 1] = " ";
            switch (playerCommand)
            {
                case "w":
                case "u":
                case "up":
                case "north":
                case "n":
                    if (yPos > 1)
                    {
                        yPos -= 1;
                        Player.MakeAction();
                    }
                    break;
                case "a":
                case "l":
                case "left":
                case "west":
                //case "w":
                    if (xPos > 1)
                    {
                        xPos -= 1;
                        Player.MakeAction();
                    }
                    break;
                case "s":
                case "b":
                case "back":
                case "south":
                    if (yPos < 6)
                    {
                        yPos += 1;
                        Player.MakeAction();
                    }
                    break;
                case "d":
                case "r":
                case "right":
                case "east":
                case "e":
                    if (xPos < 9)
                    {
                        xPos += 1;
                        Player.MakeAction();
                    }
                    break;
            }
            IfOnLocation();
            OpenMap();
            }

        }

        static void IfOnLocation()
        {
            if (xPos == mxPos && yPos == myPos)
            {
                //enter base
                yPos += 1;
                Console.Clear();
                Base.EnterBase();
            }
            else if (xPos == gxPos && yPos == gyPos)//don't forget to add a level check. //No need, Grocery store is available at lvl 1
            {
                //enter grocery store
                yPos += 1;
                Console.Clear();
                Location.EnterRoom("Grocery Store", 0);
            }
            else if (xPos == rxPos && yPos == ryPos)//here too
            {
                yPos -= 1;
                Console.Clear();
                Restaurant.EnterRestaurant();
            }
            else if (xPos == hxPos && yPos == hyPos)//here too
            {
                yPos += 1;
                Console.Clear();
                Location.EnterRoom("House", 2);
            }
            else if (xPos == fxPos && yPos == fyPos)//here too
            {
                Console.Clear();
                Console.Write("\n=====================");
                for (int i = 0; i < 8; i++)
                {
                    if (i == 2)
                    {
                        Console.Write("\n|   \t {M}         __");
                    }
                    else if (i == 5)
                    {
                        Console.Write("\n|   \t        {A} |");
                    }
                    Console.Write("\n|\t\t    |");
                }
                Console.Write("\n=====================\n");

                yPos += 1;
                Location.EnterRoom("Factory", 3);
            }
            else if (xPos == jxPos && yPos == jyPos)//here too
            {
                yPos -= 1;
                Console.Clear();
                Junkyard.EnterJunkyard();
            }
            else if (xPos == rcxPos && yPos == rcyPos)//here too
            {
                yPos -= 1;
                Console.Clear();
                Location.EnterRoom("Recycling Center", 5);
            }
        }

        public static void OpenMap()
        {
            //Player position
            map[yPos - 1][xPos - 1] = "8";
            //Player's warehouse position
            map[myPos - 1][mxPos - 1] = "W";
            //Grocery store position
            map[gyPos - 1][gxPos - 1] = "G";
            //Restaraunt
            map[ryPos - 1][rxPos - 1] = "R";
            //house
            map[hyPos - 1][hxPos - 1] = "H";
            //factory
            map[fyPos - 1][fxPos - 1] = "F";
            //Junk
            map[jyPos - 1][jxPos - 1] = "J";
            //RC
            map[rcyPos - 1][rcxPos - 1] = "C";
            
            DrawMap();
            DrawText();
        }

        public static void HelpPlayer()
        {
            Console.Clear();
            Console.WriteLine($"8 - {Player.name}, W - Warehouse, G - Grocery Store, R - Restaraunt, H - House, F - Factory, J - Junkyard, C - Recycling Centre");
            Console.WriteLine("Type the name of object for more specific help");
            string a = Console.ReadLine().ToLower();
            switch (a)
            {
                case "8":
                case "player":
                    Console.WriteLine("You can move in the four cardinal directions to explore different parts of the map by typing w/a/s/d or north/west/south/east. Each move costs 1 action point (AP), including talking and accepting quests/quizes. When you rest in the warehouse, you regain all your AP. When you rest outside, you regain half of AP.");
                    Console.WriteLine("[Any Key] to go back");
                    Console.ReadLine();
                    HelpPlayer();
                    break;
                case "w":
                case "warehouse":
                case "ware":
                    Console.WriteLine($"{Player.name}'s warehouse. Here you can check upgrade, your inventory, rest, complete quizes and see your progress.");
                    Console.WriteLine("[Any Key] to go back");
                    Console.ReadLine();
                    HelpPlayer();
                    break;
                case "g":
                case "grocery store":
                case "grocery":
                    Console.Write($"A grocery store. One of millions. Would your actions even matter on a larger scale? {(2 - Location.progress[0])} available quests, A quiz has");
                    if (Location.quizComp[0])
                        Console.Write("n't");
                    Console.WriteLine(" been completed.");
                    Console.WriteLine("[Any Key] to go back");
                    Console.ReadLine();
                    HelpPlayer();
                    break;
                case "r":
                case "restaraunt":
                    Console.Write($"A restaraunt. The food is good, but what really happens in their kitchen? I wonder what happens with their leftovers. {(2 - Location.progress[1])} available quests, A quiz has");
                    if (Location.quizComp[1])
                        Console.Write("n't");
                    Console.WriteLine(" been completed.");
                    Console.WriteLine("[Any Key] to go back");
                    Console.ReadLine();
                    HelpPlayer();
                    break;
                case "h":
                case "house":
                case "home":
                    Console.Write($"A home that has an unusual guest. Maybe there's something interesting you can learm there? {(2 - Location.progress[2])} available quests, A quiz has");
                    if (Location.quizComp[2])
                        Console.Write("n't");
                    Console.WriteLine(" been completed.");
                    Console.WriteLine("[Any Key] to go back");
                    Console.ReadLine();
                    HelpPlayer();
                    break;
                case "f":
                case "factory":
                case "fact":
                    Console.Write($"A small factory with a friendly and gullible manager. Something doesn't feel right about it. Maybe you can figure out what's the issue by talking to him. {(2 - Location.progress[3])} available quests, A quiz has");
                    if (Location.quizComp[3])
                        Console.Write("n't");
                    Console.WriteLine(" been completed.");
                    Console.WriteLine("[Any Key] to go back");
                    Console.ReadLine();
                    HelpPlayer();
                    break;
                case "j":
                case "junkyard":
                case "junk":
                    Console.Write($"A large, disgusting junkyard. It smells like rotting food. THere are definitely issues with it. {(2 - Location.progress[4])} available quests, A quiz has");
                    if (Location.quizComp[4])
                        Console.Write("n't");
                    Console.WriteLine(" been completed.");
                    Console.WriteLine("[Any Key] to go back");
                    Console.ReadLine();
                    HelpPlayer();
                    break;
                    /*
                case "c":
                case "rc":
                case "recyling centre":
                case "centre":
                    break;
                    */
            }
        }

    }
}
