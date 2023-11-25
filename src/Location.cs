using System.Data.SqlTypes;

namespace foodman
{
    class Location
    {

        
        public static int[] progress = {0, 0, 0, 0, 0, 0};
        //progress is a primary quest stat. It does +1 to a specific part after you accept a quest.
        static bool[] quizComp = {false, false, false, false, false, false};
        //quizComp becomes true for each quiz you complete
        
        public static void EnterRoom(string locName, int id)
        {
            Console.WriteLine("You are inside a " + locName);
            Console.WriteLine($"You have {2 - progress[id]} available quests");
            if (quizComp[id] == true)
            {
                Console.WriteLine("The quiz of this area has been completed");
            } else {
                Console.WriteLine("The quiz of this area has not been completed");
            }
            if (progress[id] < 2) {
                Console.Write("[A] Accept quest   ");
            }
            if (!quizComp[id])
            {
                Console.Write("[D] Try your luck with the Quiz  ");
            }
            Console.Write("[T] Talk to someone at the " + locName + "   ");
            Console.WriteLine("[S] Leave the " + locName + "    ");
            string? answer = Console.ReadLine()?.ToLower();
            if (answer == "a")
            {
                LookAround(locName, id);
            } 
            else if(answer == "t")
            {
                switch(id)//place for npc
                {
                   case 3:
                    NPC.FacroyManager();
                    break; 
                }
                EnterRoom(locName, id);
            }
            else if (answer == "s")
            {
                //do nothing
                //exits back to map class
            } 
            else if (answer == "d")
            {
                //Do the quiz of the respectable location
                switch(id)
                {
                    // add quizes (id - the number of your room)
                    case 3:
                        
                        Program.FactoryQuiz();
                        if(Program.score == 3)
                        quizComp[3] = true;

                        break;
                }
                Console.WriteLine("PLACEHOLDER FOR QUIZZES");
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
             */
            //switch case for each area with checks for the progressin of said area's quests
            //A to agree, Any key to ignore. Bc that's easier to code and to account for human stupidity (typing C when the game tells you to choose from A and B)
            switch (id)
            {
                case 0:
                    if (progress[id] == 0)
                    {
                        Console.WriteLine("You can smell expired food. Strange... Maybe you can ask someone about it?");
                        Console.WriteLine("[A] Ask the owner [Any Key] Ignore the smell");
                        string? read = Console.ReadLine()?.ToLower();
                        if (read == "a")
                        {
                            Console.WriteLine("Manager: 'The food is expired and ready to be thrown out. Yes, we will throw it to the trash. We don't recycle.'");
                            Console.WriteLine(Player.name+": 'Recycling is actually very easy! Here, let me show you, so you will start doing so too!'");
                            progress[0] += 1;
                            //DON'T FORGET TO ADD NASTY FOOD TO INVENTORY
                        } else
                        {
                            Console.WriteLine("You ignore the smell and decide to leave this disgusting place after getting yourself a few snacks");
                            //DON'T FORGET TO ADD SNACKS TO INVENTORY AND TO REMOVE THE MONEY
                        }
                    }
                    else if (progress[id] == 1)
                    {
                        Console.WriteLine("It is dark outside. The store will close soon. You take a look at the shelves. Some of them still have food. It is almost expired, so the store will throw it out. Do you want to take care of it?");
                        Console.WriteLine("[A] Take the leftovers [Any Key] Leave them there");
                        string? read = Console.ReadLine()?.ToLower();
                        if (read == "a")
                        {
                            Console.WriteLine("You take the food. Now you can either eat it or sell it for 1/4 of its original price");
                            progress[0] += 1;
                            //DON'T FORGET TO ADD WORSE FOOD TO INVENTORY
                        }
                        else
                        {
                            Console.WriteLine("You ignore the food. It is best to throw things that have no use, right?");
                        }
                    } else
                    {
                        Console.WriteLine("There is nothing left for you to do here...");
                        Console.WriteLine("[Any Key] Exit");
                        //Leaving
                    }
                break;
                case 1:
                    //restaraunt questline
                    break;
                    //other locations will have the same thing. Such individuality allows us to make every quest unique
                case 3:

                    if(progress[id] == 0)
                    {
                        Quest.Factory2();
                        EnterRoom(locName, id);
                        break;                    
                    }
                    if(progress[id] == 1)
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
