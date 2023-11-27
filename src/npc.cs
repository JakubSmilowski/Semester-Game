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
}