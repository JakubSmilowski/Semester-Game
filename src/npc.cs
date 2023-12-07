using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using foodman;

class NPC
{

        public static void FacroyManager()
        {
            string? ans = "";
            if(Location.progress[3] == 0)
            {
                Console.WriteLine("Manager: Hi, welcome to the factory,");
                Console.WriteLine("here we process food for the grocery store");
                Console.WriteLine(Player.name + ":");
                Console.WriteLine("[A] Do you have any problems plaguing your factory?");
                Console.WriteLine("[B] Can I buy food here?");
                Console.WriteLine("[C] ...");

                ans = Console.ReadLine()?.ToLower();
                switch(ans)
                {
                    case "a":

                        Console.WriteLine("Manager: Actually yes. We throw out a lot of food because of our quality standards and imprecise machines.");
                        Console.WriteLine("If you have some ideas about what to do about these problems, feel free to take action.");
                        Console.WriteLine();
                        break;

                    case "b":

                        Console.WriteLine("Manager: You can only buy the waste we produce, not the actual product.");
                        Console.WriteLine();
                        break;
                
                    case "c":
                    default:

                        Console.WriteLine("Manager: If you need anything feel free to ask!");
                        Console.WriteLine();
                        break;
                }
                
            }
            if(Location.progress[3] == 1)
                {
                    Console.WriteLine("Manager: Hi, I was hoping you would come back!");
                    Console.WriteLine("You helped us massively by taking the food waste.");
                    Console.WriteLine("By doing that you removed a lot of hasstle from my shoulders!");
                    Console.WriteLine(Player.name + ":");
                    Console.WriteLine("[A] Glad to hear that I could help!");
                    Console.WriteLine("[B] Why was it a hasstle?");
                    Console.WriteLine("[C] ...");
                    ans = Console.ReadLine()?.ToLower();
                    switch(ans)
                    {
                        case "a":

                            Console.WriteLine("Manager: If you have some ideas about how we can improve our business just contact me.");
                            Console.WriteLine();

                            break;
                        case "b":

                            Console.WriteLine("We need to find and pay other companies to take out our waste.");
                            Console.WriteLine("By taking our waste you removed some of our business expenses.");
                            Console.WriteLine();

                            break;
                        case "c":
                        default:

                            Console.WriteLine("Manager: Hope to see you again soon!");
                            Console.WriteLine();
                            break;
                    }
                }
            if(Location.progress[3] == 2)
            {
                Console.WriteLine("Manager: Hi, I wanted to thank you for making our factory more eco-friendly, and in turn more profitable!");
            }
        }

    public static void HouseholdRobot()
    {
        switch (Location.progress[2])
        {
                case 0:
                    Console.WriteLine("└|*-*|┘ - 'Hi! My name's Robert the Robot and I arrive from future, when I am your typical Eco-Friendly Robot assisting with everyday tasks.'\n");
                    Console.WriteLine("└|*-*|┘ - 'People of future are rarely needing my help as years of education throughout the FOODMAN have resulted in eco-aware society, that just knows how to waste less food.'");
                    Console.WriteLine("└|*-*|┘ - 'Even though I love humans of my times, I'd lie saying that I don't miss when they were less educated and needed my assistance more. That's why after consulting with them they've decided to try sending me back in time, so I could educate people of the past.'");
                    Console.WriteLine("└|*-*|┘ - 'I think they did succeed right? Could you please tell me what year are we in?'");
                    Console.Write($"{Player.name} - 'I think it is...");
                    string? currentYear = "";
                    currentYear = Console.ReadLine();
                    Console.WriteLine($"└|*-*|┘ - '{currentYear}?!?'");
                    Console.WriteLine("└|*-*|┘ - 'That is crazy!'\n");
                    Console.WriteLine("└|*-*|┘ - 'So it did work after all... Amazing! By the way excuse my poor manners, your name is " + Player.name + " right?'");
                    Console.ReadLine();
                    Console.WriteLine($"└|*-*|┘ - 'You look like a {Player.name}.'");
                    Console.WriteLine("[Any Key] to continue..");
                    Console.ReadLine();
                    Console.Clear();
                break;
        }
    }
}
