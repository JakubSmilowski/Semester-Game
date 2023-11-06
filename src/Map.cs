namespace Map
{
    class Map
    {
        //Player position, taken from main class
        static int xPos = 5;
        static int yPos = 3;

        //Warehouse position, taken from main class
        static int mxPos = 5;
        static int myPos = 4;

        //Stats, taken from... well, stats class
        static string date = "IMPORTED FROM STATS";
        static int stamina;

        static string[][] map =
        {
            new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " },
            new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " },
            new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " },
            new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " },
            new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " },
            new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " },
        };
        
        static string[] abc = { "A" , "B" , "C", "D", "E", "F"};
        static string playerCommand = "";


        static void LineSep()
        {
            Console.WriteLine("=========================================");
        }

        static void DrawText(string dmy, string ap)
        {
            LineSep();
            Console.WriteLine("Today is " + dmy);
            Console.WriteLine("You have " + ap + " moves left");
            LineSep();
            Console.WriteLine("[W]Up [A]Left [S]Down [D]Right");
            Console.Write("Enter your command... ");
            playerCommand = Console.ReadLine().ToLower();
            ReadPlayerInput();
        }

        static void DrawMap()
        {
            //Map's top frame
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
            if (stamina > 0)
            {
                map[yPos - 1][xPos - 1] = " ";
                switch (playerCommand)
                {
                    case "w":
                    case "u":
                    case "up":
                        if (yPos > 1)
                        {
                            yPos -= 1;
                            stamina -= 1;
                        }
                        break;
                    case "a":
                    case "l":
                    case "left":
                        if (xPos > 1)
                        {
                            xPos -= 1;
                            stamina -= 1;
                        }
                        break;
                    case "s":
                    case "b":
                    case "back":
                        if (yPos < 6)
                        {
                            yPos += 1;
                            stamina -= 1;
                        }
                        break;
                    case "d":
                    case "r":
                    case "right":
                        if (xPos < 9)
                        {
                            xPos += 1;
                            stamina -= 1;
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
                Console.WriteLine("TRANSFER TO WAREHOUSE CLASS");
            }
        }

        public static void OpenMap()
        {
            //Player position
            map[yPos - 1][xPos - 1] = "T";
            //Player's warehouse position
            map[myPos - 1][mxPos - 1] = "W";

            LineSep();
            DrawMap();
            DrawText(date, stamina.ToString());
        }

    }
}
