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
            if (read == "a")
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

}