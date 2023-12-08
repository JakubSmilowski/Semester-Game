using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;




namespace foodman
{

    class Junkyard
    {
        //All the stats needed in the junkyard
        public static bool isUpgraded = false;
        public static bool hasRecyclingCenterBlueprint = false;
        public static bool QuestCompleted = false;

        //Main function caled after entering junkyard.
        public static void EnterJunkyard()
        {
            if (isUpgraded){
                JunkyardUpgradedLogic();
            }else{
                JunkyardLogic();
            }
        }
        //Draw Junkyard/
        private static void DrawJunkyard()
        {
            Console.Clear();
            Console.Write("\n=====================");

            //Value i indicates how how hight the border of the room is.
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    Console.Write("\n|\t\t    |");
                }
                else if (i == 3)
                {
                    Console.Write("\n|\t\t    |");
                    break;
                }
                Console.Write("\n|\t\t    |");
            }
            Console.Write("\n=====================\n");

            //Possible options
            Console.WriteLine("[O] Open shop");
            Console.Write("[A] Accept quest ");
            Console.Write("[D] Try your luck with the Quiz ");
            Console.WriteLine("[T] Talk to someone");
            Console.WriteLine("[S] Leave the Junkyard. ");
            Console.Write("> ");
        }
        //All the logic of the junkyard
        private static void JunkyardLogic()
        {
            do
            {
                GreetingMessage();
                DrawJunkyard();

                string? userInput = Console.ReadLine();

                switch (userInput?.ToLower())
                {
                    case "o":
                        //Here player will be able to sell food waste for money
                        JunkyardShop();
                        ContinueMessage();
                        break;
                    case "a":
                        //Quest of ths location
                        StartTheQuest();
                        ContinueMessage();
                        break;
                    case "d":
                        //Open quiz
                        JunkyardStartQuizz();
                        ContinueMessage();
                        break;
                    case "t":
                        //Talk to the npc.
                        if(isUpgraded){
                            Console.WriteLine("Grizzly: Thank you for helping in transforming this place into more sustainable place!");
                            ContinueMessage();
                        }else{
                            NPC.JunkyardBoss();
                            ContinueMessage();
                        }
                        break;
                    case "s":
                        Console.WriteLine("You are leaving the junkyard,");
                        return;
                    default:
                        Console.WriteLine("This is a correct input! Try again.");
                        ContinueMessage();
                        break;
                }

            } while (true);
        }

        private static void JunkyardUpgradedLogic(){
            do
            {
                GreetingMessageUpgraded();
                DrawJunkyardUpgraded();

                string? userInput = Console.ReadLine();

                switch (userInput?.ToLower())
                {
                    case "d":
                        //Open quiz
                        JunkyardStartQuizz();
                        ContinueMessage();
                        break;
                    case "t":
                        //Talk to the npc.
                        Console.WriteLine("Grizzly: Thank you for helping in transforming this place into more sustainable place!");
                        ContinueMessage();
                        break;
                    case "s":
                        Console.WriteLine("You are leaving the junkyard,");
                        return;
                    default:
                        Console.WriteLine("This is a correct input! Try again.");
                        ContinueMessage();
                        break;
                }

            } while (true);

        }

        private static void DrawJunkyardUpgraded(){
            Console.Write("\n=====================");

            //Value i indicates how how hight the border of the room is.
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    Console.Write("\n|\t\t    |");
                }
                else if (i == 3)
                {
                    Console.Write("\n|\t\t    |");
                    break;
                }
                Console.Write("\n|\t\t    |");
            }
            Console.Write("\n=====================\n");

            //Possible options
            Console.Write("[D] Try your luck with the Quiz ");
            Console.WriteLine("[T] Talk to someone");
            Console.WriteLine("[S] Leave the new recycle center. ");
            Console.Write("> ");

        }
        private static void GreetingMessageUpgraded(){
            Console.Clear();
            Console.WriteLine("Welcome in the new recycle center! Here we recycle!");
        }


        //Junkyar shop
        private static void JunkyardShop()
        {
            bool leave = false;
            do
            {
                Console.Clear();
                Console.WriteLine("> You entered the shop.");
                Console.WriteLine("> Here you can throw out not needed items to earn extra money.");
                Console.WriteLine("> Junkyard prices are firm. No matter what you bring, we pay out 4$ for each item.\n");
                Console.WriteLine("> Do you want to proceed? [Y/N]");
                string? userInput = Console.ReadLine();

                if (userInput != null)
                {
                    if (userInput.ToLower() == "n")
                    {
                        Console.WriteLine("You are leaving the shop.");
                        leave = true;
                    }
                    else if (userInput.ToLower() == "y")
                    {
                        Items.JunkyardSellMenu();
                        leave = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input.");
                    }
                }
                else
                {
                    Console.WriteLine("Input can not be blank");
                    ContinueMessage();
                }
            }
            while (!leave);
        }

        //Starts quest of the location.
        private static void StartTheQuest()
        {
            if(QuestCompleted){
                Console.WriteLine("Quest of this location is completed, to progress more talk to the boss of the junkyard");
                ContinueMessage();
            }else{

                if (Player.turn < 5 && Player.IsActionPossible())
                {
                    Console.WriteLine("There is nothing going on here currently. Visit this place later.");
                }
                else
                {
                    Player.MakeAction();
                    Quest.JunkyardQuest();
                }
            }
        }
        //Starts the quizz, and decide wich one to display.
        private static void JunkyardStartQuizz()
        {
            if (Location.progress[4] == 0 && Player.IsActionPossible())
            {
                Player.MakeAction();
                Program.JunkyardQuizz();
            }
            else if (Player.IsActionPossible())
            {
                Player.MakeAction();
                Program.JunkyardQuizz1();
            }
        }

        //Message displayed each time when 
        public static void ContinueMessage()
        {
            Console.WriteLine("Press [Any key] to continue.");
            Console.ReadLine();
        }

        //Message displayed when entering the junkayard
        private static void GreetingMessage()
        {
            Console.WriteLine("You are entering junkyard.");
        }
        
        public static void TransformJunkyardIntoRecycleCenter(){
            if (Player.IsActionPossible()){
                Console.Clear();
                Player.MakeAction();
                Player.SubstractMoney(300);

                Console.WriteLine("The Junkyard is transformed into a Recycling Center! Congratulations!");

                Console.WriteLine("\nCongratulations, Player! The transformation of the Junkyard into a Recycling Center marks a significant step towards a more sustainable future.");
                Console.WriteLine("Here's why this change is crucial for the minimization of food waste:");

                Console.WriteLine("\n1. Efficient Waste Management:");
                Console.WriteLine("   - A Recycling Center allows for the proper sorting and disposal of waste, ensuring that recyclable materials are processed efficiently.");

                Console.WriteLine("\n2. Resource Recovery:");
                Console.WriteLine("   - By recycling materials, we can recover valuable resources, reducing the need for new raw materials and minimizing environmental impact.");

                Console.WriteLine("\n3. Contribution to Circular Economy:");
                Console.WriteLine("   - Transforming the Junkyard into a Recycling Center aligns with the principles of a circular economy, where resources are reused and recycled in a sustainable loop.");

                Console.WriteLine("\n4. Community Awareness:");
                Console.WriteLine("   - The Recycling Center serves as a focal point for raising awareness about responsible waste disposal and the importance of minimizing food waste.");

                Console.WriteLine("\nThank you for your efforts in making this positive change. Together, we're building a more environmentally-friendly community!");
                Console.WriteLine("=================================================================");
                Console.WriteLine("From now on you will be geting 1 green point and 20xp each turn! ");
                isUpgraded = true;
            }
        }







    }
}