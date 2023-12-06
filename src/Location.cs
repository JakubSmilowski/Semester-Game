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
            Console.WriteLine("[T] Talk to someone at the" + locName + "  ");
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
                    case 3:
                        NPC.FacroyManager();
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
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
                case 1:
                    //restaraunt questline
                    break;
                //other locations will have the same thing. Such individuality allows us to make every quest unique
                case 2:
                    string? currentYear = "";
                    Console.WriteLine("Welcome to the House! Press Enter to continue...");
                    Console.ReadLine();
                    Console.WriteLine("└|*-*|┘ - 'Hi! My name's Robert the Robot and I arrive from future, when I am your typical Eco-Friendly Robot assisting with everyday tasks.'");
                    Console.ReadLine();
                    Console.WriteLine("└|*-*|┘ - 'People of future are rarely needing my help as years of education throughout the FOODMAN have resulted in eco-aware society, that just knows how to waste less food.'");
                    Console.ReadLine();
                    Console.WriteLine("└|*-*|┘ - 'Even though I love humans of my times, I'd lie saying that I don't miss when they were less educated and needed my assistance more. That's why after consulting with them they've decided to try sending me back in time, so I could educate people of the past.'");
                    Console.ReadLine();
                    Console.WriteLine("└|*-*|┘ - 'Oh wow I think they did succeed right? Could you please tell me what year are we in?'");
                    currentYear = Console.ReadLine();
                    Console.WriteLine($"└|*-*|┘ - '{currentYear}?!?'");
                    Console.ReadLine();
                    Console.WriteLine("└|*-*|┘ - 'That is crazy!'");
                    Console.ReadLine();
                    Console.WriteLine("└|*-*|┘ - 'So it did work after all... Amazing! By the way excuse my poor manners, your name is ", Player.name + " right?'");
                    Console.ReadLine();
                    Console.WriteLine($"└|*-*|┘ - 'You look like a {Player.name}.'");
                    Console.ReadLine();
                    Console.WriteLine("└|*-*|┘ - 'OK, now that we know each other would you be interested in participating in a quizz that would evaluate your knowledge regarding ways of lessening food waste? Type YES if you would like to try, or NO if you would rather go on exploring other rooms.'");
                    string? decisionQuizz = Console.ReadLine()?.ToLower();

                    if (decisionQuizz == "yes")
                    {
                        if (Player.IsActionPossible())
                        {
                            Console.WriteLine("└|*-*|┘ - 'I AM SO EXCITED!!!!! Let's begin then.'");
                            //Add "Player.MakeAction();" before executing the quiz.
                            //Quizz();
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