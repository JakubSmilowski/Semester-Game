using System.Runtime;

namespace foodman
{
    class Location
    {
        static int[] progress = {0, 0, 0, 0, 0, 0};
        //progress is a primary quest stat. It does +1 to a specific part after you accept a quest.
        static bool[] quizComp = {false, false, false, false, false, false};
        //quizComp becomes true for each quiz you complete
        
        public static void EnterRoom(string locName, int id)
        {
            Console.WriteLine("You are inside a " + locName);
            Console.WriteLine($"You have {2 - progress[id]} available quests");
            if (quizComp[id])
            {
                Console.WriteLine("The quiz of this area has been completed");
            } else {
                Console.WriteLine("The quiz of this area has not been completed");
            }
            if (progress[id] < 2) {
                Console.Write("[A] Accept quest ");
            }
            if (!quizComp[id])
            {
                Console.Write("[D] Try your luck with the Quiz ");
            }
            Console.WriteLine("[S] Leave the " + locName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "a")
            {
                LookAround(locName, id);
            } else if (answer == "s")
            {
                //do nothing
                //exits back to map class
            } else if (answer == "d")
            {
                //Do the quiz of the respectable location
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
                        string read = Console.ReadLine().ToLower();
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
                        string read = Console.ReadLine().ToLower();
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
                case 2:
                 Console.WriteLine("Welcome to the House!");
                 Console.WriteLine("└|∵|┘ - 'Hi! My name's Robert the Robot and I arrive from future, when I am your typical Eco-Friendly Robot assisting with everyday tasks.'");
                 Console.WriteLine("└|∵|┘ - 'People of future are rarely needing my help as years of education throughout the FOODMAN have resulted in eco-aware society, that just knows how to waste less food.'");
                 Console.WriteLine("└|∵|┘ - 'Even though I love humans of my times, I'd lie saying that I don't miss when they were less educated and needed my assistance more. That's why after consulting with them they've decided to try sending me back in time, so I could educate people of the past.'");
                 Console.WriteLine("└|∵|┘ - 'Oh wow I think they did succeed right? Could you please tell me what year are we in?'");
                 string currentYear = Console.ReadLine();
                 Console.WriteLine("└|∵|┘ - '",currentYear,"?!?'");
                 Console.WriteLine("└|∵|┘ - 'That is crazy!'");
                 Console.WriteLine("└|∵|┘ - 'So it did work after all... Amazing! By the way excuse my poor manners, your name is ",Player.name+" right?'");
                 Console.WriteLine("└|∵|┘ - 'You look like a ",Player.name+".'");
                 Console.WriteLine("└|∵|┘ - 'OK, now that we know each other would you be interested in participating in a quizz that would evaluate your knowledge regarding ways of lessening food waste? Type YES if you would like to try, or NO if you would rather go on exploring other rooms.'");
                 string decisionQuizz = Console.ReadLine().ToLower();
                 
                 if(decisionQuizz == "yes")
                 {
                   Console.WriteLine("└|∵|┘ - 'I AM SO EXCITED!!!!! Let's begin then.'");
                    Quizz();
                 } else if(decisionQuizz == "no")
                 {
                    Console.WriteLine("└|∵|┘ - 'Fine, no worries. In case you would change your mind, please do not hesitate to come back, I'll be waiting.'");
                 }
                break;

            }
        }

    }
}
