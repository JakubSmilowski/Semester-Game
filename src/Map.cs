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
            new string[] { " ", " ", " ", " ", "T", " ", " ", " ", " " },
            new string[] { " ", " ", "R", " ", " ", " ", " ", " ", " " },
            new string[] { "C", " ", " ", " ", " ", " ", " ", " ", "J" },
        };

        static string[] abc = { "A", "B", "C", "D", "E", "F" };
        static string? playerCommand = "";

        static void DrawText()
        {
            GameRuntime.LineSep();
            Console.WriteLine($"Today is  {Player.currentlyDate.ToShortDateString()}");
            Console.WriteLine($"You have {Player.actionPoints} moves left");
            GameRuntime.LineSep();
            Console.WriteLine("[W]Up [A]Left [S]Down [D]Right");
            Console.Write("Enter your command... ");
            playerCommand = Console.ReadLine()?.ToLower();
            ReadPlayerInput();
        }

        static void DrawMap()
        {
            Console.Clear();// To not douplicate the map in console while moving
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
            //if (stamina > 0)
            //{
            map[yPos - 1][xPos - 1] = " ";
            switch (playerCommand)
            {
                case "w":
                case "u":
                case "up":
                    if (yPos > 1)
                    {
                        yPos -= 1;
                        //stamina -= 1;
                    }
                    break;
                case "a":
                case "l":
                case "left":
                    if (xPos > 1)
                    {
                        xPos -= 1;
                        //stamina -= 1;
                    }
                    break;
                case "s":
                case "b":
                case "back":
                    if (yPos < 6)
                    {
                        yPos += 1;
                        //stamina -= 1;
                    }
                    break;
                case "d":
                case "r":
                case "right":
                    if (xPos < 9)
                    {
                        xPos += 1;
                        //stamina -= 1;
                    }
                    break;
            }
            IfOnLocation();
            OpenMap();
            //}

        }

        static void IfOnLocation()
        {
            if (xPos == mxPos && yPos == myPos)
            {
                //enter base
                yPos += 1;
                Base.EnterBase();
            }
            else if (xPos == gxPos && yPos == gyPos)//don't forget to add a level check
            {
                //enter grocery store
                yPos += 1;
                Location.EnterRoom("Grocery Store", 0);
            }
            else if (xPos == rxPos && yPos == ryPos)//here too
            {
                yPos -= 1;
                Location.EnterRoom("Restaraunt", 1);
            }
            else if (xPos == hxPos && yPos == hyPos)//here too
            {
                yPos += 1;
                Location.EnterRoom("House", 2);
            }
            else if (xPos == fxPos && yPos == fyPos)//here too
            {
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
                Location.EnterRoom("Junkyard", 4);
            }
            else if (xPos == rcxPos && yPos == rcyPos)//here too
            {
                yPos -= 1;
                Location.EnterRoom("Recycling Center", 5);
            }
        }

        public static void OpenMap()
        {
            //Player position
            map[yPos - 1][xPos - 1] = "T";
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

            GameRuntime.LineSep();
            DrawMap();
            DrawText();
        }

    }
}
