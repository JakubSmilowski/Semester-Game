using System.Collections;
using System.ComponentModel;
using foodman;

namespace WorldOfZuul { }

class Quest
{

    /*
    public static void Factory1()
    {
        Console.WriteLine("While searching for the enterence you notice a pipe connected with a dumbster behind the factory. When approaching it you smell rotting food. You see a worker near by. Maybe you should ask him about it.");
        Console.WriteLine("[A] Talk to the worker [Any Key] Ignore the situation");
        string read = Console.ReadLine().ToLower();
        if(read == "a")
        {
            Console.WriteLine("Worker: This is the food waste that comes from the factory.");
            Console.WriteLine(Player.name + ": Do you recycle the waste?");
            Console.WriteLine("Worker: No we just send it to the landfill.");
            Console.WriteLine("[A] Suggest recyciling [Any Key] Ignore");
            read = Console.ReadLine().ToLower();
            if(read == "a")
            {
                Console.WriteLine(Player.name + ": Have you considered recycling?");
                Console.WriteLine("Worker: No, but you can take the waste if you want to recycle it.");
                Console.WriteLine("[A] Take the waste [Any Key] Leave the worker alone");
                read = Console.ReadLine().ToLower();
                if(read == "a")
                {
                    Location.progress[0] += 1;
                     //Add waste to inventory
                }
                else
                {
                    Console.WriteLine(Player.name + ": It's not worth the effort.");
                }
            }
            else
            {
                Console.WriteLine("You decide that it's the best way to deal with the waste");
            }
        }
        else
        {
            Console.WriteLine("You ignor the situation");
        }
    }
    */
    public static void Factory2()
    {
        Console.WriteLine("You visit the factory. You see all the food that is being thrown out because it doesn't meet the factory's standarts...");
        Console.WriteLine("Maybe you can talk to someone about this.");
        Console.WriteLine("[A] Go talk to a manager [Any Key] Leave the Factory");
        string? read = Console.ReadLine()?.ToLower();
        if (read == "a")
        {
            Console.WriteLine("Manager: We usually trow the misformed food out, but you can buy it if you want.");
            Console.WriteLine("[A] Buy the food [Any Key] Leave the Factory");
            read = Console.ReadLine()?.ToLower();
            Player.MakeAction();
            if (read == "a")
            {
                Location.progress[3] += 1;
                //subtract money
                //add good food to inventory
            }
            else
            {
                Console.WriteLine("You left the factory.");
            }
        }
        else
        {
            Console.WriteLine("You left the factory.");
        }
    }
    public static void Factory3()
    {
        Console.WriteLine("You visit the factory ones again, but this time with a sugestion to the maniger to manage the food waste");
        Console.WriteLine("[A] Go to the manigers office [Any Key] He probably won't find it interesting");
        string? read = Console.ReadLine()?.ToLower();
        if (read == "a")
        {
            Console.WriteLine(Player.name + ": I have an offer for you.");
            Console.WriteLine("Manager: I'm listening, tell me your offer");
            Console.WriteLine(Player.name + ": I will instal beater machenes in your factory, which will reduce waste, but you will need to give me a cut of what you saved with these machenes.");
            Console.WriteLine("Manager: Sure, why not");
            Console.WriteLine("[A] Buy the machenes (HERE WRITE THE AMOUNT THEY WILL COST) [Any Key] On other thoughts its not worth it");
            read = Console.ReadLine()?.ToLower();
            Player.MakeAction();
            if (read == "a" && Player.IsActionPossible())
            {
                Location.progress[3] += 1;
                //subtract money
                //make player get money every new day
            }
            else
            {
                Console.WriteLine("You decided to ignore the benefits and save your money");
            }
        }
        else
        {
            Console.WriteLine("You ignore this oportunity");
        }
    }

    public static void Grocery(int progress)
    {
        switch (progress)
        {
            case 0:
                Console.WriteLine("You can smell expired food. Strange... Maybe you can ask someone about it?");
                Console.WriteLine("[A] Ask the owner [Any Key] Ignore the smell");
                string? read = Console.ReadLine()?.ToLower();
                if (read == "a")
                {
                    Console.WriteLine("Manager: 'The food is expired and ready to be thrown out. Yes, we will throw it to the trash. We don't recycle.'");
                    Console.WriteLine($"{Player.name}: 'Recycling is actually very easy! Here, let me show you, so you will start doing so too!'");
                    Items.FoodExpired.AddRandomAmount(1, 10);
                    Items.FoodExpired.Display();
                    Location.progress[0]++;
                    PressToExit("Grocery Store", 0);
                }
                else
                {
                    Console.WriteLine("You ignore the smell and decide to leave this disgusting place after getting yourself a few snacks");
                    Items.Snacks.Add(1);
                    Player.SubstractMoney(10);
                    PressToExit("Grocery Store", 0);
                }
                break;
            case 1:
                Console.WriteLine("It is dark outside. The store will close soon. You take a look at the shelves. Some of them still have food. It is almost expired, so the store will throw it out. Do you want to take care of it?");
                Console.WriteLine("[A] Take the leftovers [Any Key] Leave them there");
                read = Console.ReadLine()?.ToLower();
                if (read == "a")
                {
                    Console.WriteLine("You take the food. Now you can either eat it or sell it for 1/4 of its original price");
                    Location.progress[0]++;
                    PressToExit("Grocery Store", 0);
                }
                else
                {
                    Console.WriteLine("You ignore the food. It is best to throw things that have no use, right?");
                    PressToExit("Grocery Store", 0);
                }
                break;
            default:
                Console.WriteLine("There is nothing left for you to do here...");
                break;
        }
    }

    public static void JunkyardQest(){
        
    }

    public static void Restaurant(int progress)
    {
        switch (progress)
        {
            case 0:
                Console.WriteLine("You notice that an employee is taking out an unreasonably large amount of trash. Why could he be doing that?");
                Console.WriteLine("[A] Talk with the employee [Any Key] Ignore the situation");
                string? read = Console.ReadLine()?.ToLower();
                if (read == "a")
                {
                    Console.WriteLine("Employee: 'Oh, this? We actually ordered Way too much food, but now most of it has gone bad.'");
                    Console.WriteLine($"{Player.name}: 'Why would he order so much food if you won't ever use it?'");
                    Console.WriteLine("Employee: 'I guess it's because last month we had a boom of customers, but now there's not as many.'");
                    Console.WriteLine($"{Player.name}: 'So an issue with inventory management and menu planning caused this waste?'");
                    Console.WriteLine("Employee: 'I guess. Well, I have to go back to work. You can talk to my boss about your proposal if you want'");

                    Console.WriteLine("[A] Go talk with the boss [Any Key] Ignore it");
                    read = Console.ReadLine()?.ToLower();
                    if (read == "a")
                    {
                        Console.Clear();
                        Console.WriteLine("You have a long talk with the boos. You educate him on the issues of Overproduction, Excess Inventory and Menu Planning.");
                        Console.WriteLine("Cooking or preparing more food than needed can lead to significant waste if not all of it is sold or consumed.");
                        Console.WriteLine("Poor inventory control can result in overordering and excess stock, leading to items expiring or going to waste.");
                        Console.WriteLine("Regular changes in the menu can lead to excess inventory of ingredients that are no longer needed, especially if suppliers require large minimum orders.");
                        Location.progress[1]++;
                    }
                    PressToExit("Restaurant", 1);
                }
                else
                {
                    Console.WriteLine("You ignore the clear issue and decide to leave.");
                    PressToExit("Restaurant", 1);
                }
                break;
            case 1:
                Console.WriteLine("Something outside catches your eye. It is a homeless person that stays outside the establishment, begging for food.");
                Console.WriteLine("You sit inside and order some food. While waiting for it, you look into the open kitchen.");
                Console.WriteLine("The cooks actually throw out some parts of the food that they don't need in the order");
                Console.WriteLine("[A] Ask them to give leftovers to charities [Any Key] Forget about it");
                read = Console.ReadLine()?.ToLower();
                if (read == "a")
                {
                    Console.WriteLine("You ask the workers to not throw out small pieces of food and instead to give them to people in need, liek the one outside.");
                    Console.WriteLine("To your surprise, they agree with you. After they finish your order, you can see that they give something to the homeless person.");
                    Console.WriteLine("You can rest easy knowing that from now on, not only do their issue with leftovers is smaller, but the peopel in need revieve more food");
                    Location.progress[1]++;
                    PressToExit("Restaurant", 1);
                }
                else
                {
                    Console.WriteLine("You ignore the homeless person and the issue with the leftovers. Deciding to not interfere is better, right?");
                    PressToExit("Restaurant", 1);
                }
                break;
            default:
                Console.WriteLine("There is nothing left for you to do here...");
                break;
        }
    }

    public static void PressToExit(string location, int locId)
    {
        Console.WriteLine("=========================================");
        Console.WriteLine("Press S to Exit");
        Console.WriteLine("-----------------------------------------");
        string? a = Console.ReadLine()?.ToLower();
        if (a != "s")
            PressToExit(location, locId);
        Console.Clear();
        Location.EnterRoom(location, locId);
    }
}
