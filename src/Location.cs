using System.Runtime;
using System.Runtime.CompilerServices;
using WorldOfZuul;

namespace foodman
{
    class Location
    {
        public static int[] progress = { 0, 0, 0, 0, 0, 0, 0 };
        //progress is a primary quest stat. It does +1 to a specific part after you accept a quest.
        public static bool[] quizComp = { false, false, false, false, false, false, false };
        //quizComp becomes true for each quiz you complete

        public static void EnterRoom(string locName, int id)
        {
            Console.WriteLine("You are inside a " + locName);
            Console.WriteLine($"You have {2 - progress[id]} available quests");
            if (quizComp[id])
            {
                Console.WriteLine("The quiz of this area has been completed");
            }
            else
            {
                Console.WriteLine("The quiz of this area has not been completed");
            }
            if (progress[id] < 2)
            {
                Console.Write("[A] Accept quest ");
            }
            if (!quizComp[id])
            {
                Console.Write("[D] Try your luck with the Quiz ");
            }
            Console.WriteLine("[T] Talk to someone at the " + locName + "  ");
            Console.WriteLine("[S] Leave the " + locName);
            string? answer = Console.ReadLine()?.ToLower();
            if (answer == "a" && Player.IsActionPossible())
            {
                LookAround(locName, id);
            }
            else if (answer == "s")
            {
                //do nothing
                //exits back to map class
            }
            else if (answer == "d" && Player.IsActionPossible())
            {
                //Do the quiz of the respectable location
                switch (id)
                {
                    // add quizes (id - the number of your room)
                    case 0:
                        Player.MakeAction();
                        Program.GroceryStoreQuiz();
                        if(Program.score == 3)
                            quizComp[0] = true;
                        break;

                    

                        

                    case 2:
                        Player.MakeAction();
                        Program.House();
                        if (Program.score == 5)
                            quizComp[2] = true;
                        break;
                    case 3:
                        Player.MakeAction();
                        Program.FactoryQuiz();
                        if (Program.score == 3)
                            quizComp[3] = true;
                        break;
                }
                Console.WriteLine("PLACEHOLDER FOR QUIZZES");
                EnterRoom(locName, id);
            }
            else if (answer == "t")
            {
                switch (id)//place for npc
                {
                    case 0:
                        Console.Clear();
                        NPC.GroceryStoreOwner();
                        break;
                    case 2:
                        Console.Clear();
                        NPC.HouseholdRobot();
                        break;
                    case 3:
                        Console.Clear();
                        NPC.FacroyManager();
                        break;
                    case 5:
                        Console.Clear();
                        NPC.RecycilingCenterWorker();
                        break;
                }
                EnterRoom(locName, id);
            }
            else
            {
                GameRuntime.WentWrong();
                EnterRoom(locName, id);
            }
        }
        static void LookAround(string locName, int id)
        {
            /*  0 - Grocery Store
             *  1 - Restaraunt
             *  2 - House
             *  3 - Factory
             *  4 - Junkyard
             *  5 - Recycling centre
             *  6 - Base - just for quizComp and progress
             */
            //switch case for each area with checks for the progressin of said area's quests
            //A to agree, Any key to ignore. Bc that's easier to code and to account for human stupidity (typing C when the game tells you to choose from A and B)
            switch (id)
            {
                case 0:
                    Player.MakeAction();
                    Quest.Grocery(progress[id]);
                    break;
                case 1:
                    Player.MakeAction();
                    Quest.Restaurant(progress[id]);
                    break;
                //other locations will have the same thing. Such individuality allows us to make every quest unique
                case 2:
                    Console.WriteLine("└|*-*|┘ - 'It appears that humans of this year do not care about lessening food waste.");
                    Console.WriteLine("└|*-*|┘ - 'Would you be interested in helping me clean up here? I... do not have the best arms.'");
                    Console.WriteLine("└|*-*|┘ - 'Say YES if you would like to try, or NO if you would rather do something else.'");
                    string? deci = Console.ReadLine()?.ToLower();
                    if (deci == "yes")
                    {
                        if (Player.IsActionPossible())
                        {
                            Console.WriteLine("└|*-*|┘ - 'I AM SO EXCITED!!!!! Let's begin then.'");
                            Player.MakeAction();
                            Quest.House(progress[id]);
                            Quest.PressToExit("House", 2);
                        } else
                        {
                            Console.WriteLine("└|*-*|┘ - 'Oh... You look eager, but it appears that you are too tired. Let's try again tomorrow, okay?'");
                            Quest.PressToExit("House", 2);
                        }
                    } else
                        {
                        Console.WriteLine("└|*-*|┘ - 'Fine, no worries. In case you would change your mind, please do not hesitate to come back, I'll be waiting.'");
                        Quest.PressToExit("House", 2);
                    }
                    break;

                case 3:
                    if (progress[id] == 0)
                    {
                        Quest.Factory2();
                        EnterRoom(locName, id);
                        break;
                    }
                    if (progress[id] == 1)
                    {
                        Quest.Factory3();
                        EnterRoom(locName, id);
                        break;
                    }
                    break;
            }
        }
    }
}
