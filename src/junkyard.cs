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
        private static bool isUpgraded = false;

        //Main function caled after entering junkyard.
        public static void EnterJunkyard()
        {
            JunkyardLogic();
        }
        //Draw Junkyard/
        private static void DrawJunkyard()
        {
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

                switch (userInput.ToLower())
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
                        Program.JunkyardQuizz();
                        ContinueMessage();
                        break;
                    case "t":
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
        //Junkyar shop
        private static void JunkyardShop()
        {
            bool leave = false;
            do
            {
                Console.Clear();
                Console.WriteLine("> You entered the shop. Press [s] to leave.");
                Console.WriteLine("> Here you can throw out not needed items to earn extra money.\n");
                Console.WriteLine("> What do you want to throw out?");
                Items.OpenInventory();
                string? userInput = Console.ReadLine();

                if (userInput != null)
                {
                    if (userInput.ToLower() == "s")
                    {
                        Console.WriteLine("You are leaving the shop.");
                        leave = true;
                    }
                    else
                    {
                        Console.WriteLine("Work in progress!");
                        //Item.SellItem();
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
            if (Player.turn < 5)
            {
                Console.WriteLine("There is nothing going on here currently. Visit this place later.");
            }
            else
            {
                Quest.JunkyardQest();
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
        //







    }
}