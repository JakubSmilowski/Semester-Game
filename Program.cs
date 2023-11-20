namespace restaurant
{
    class Restaurant
    {
        
        public static void Menu()
        {
        
            Console.WriteLine("=======Menu=======");
            Console.WriteLine(" 1.Italian dish - 15 dollars\n 2.Mexican dish - 10 dollars\n 3.Chinese dish - 5 dollars");
        }
        public static void Npc1()
        {
            Console.WriteLine("Press M to see the menu");
            string? NpcInput = Console.ReadLine();
            if(NpcInput == "M")
            {
                Menu();
            }
        }
        public static void EnterRestaurant()
        {
            
               
               Console.WriteLine("Welcome to the restaurant!");
               Console.WriteLine("You can buy a nutritious meal here");
               Console.WriteLine("You have  dollars"); 
               Console.Write("\n=====================");

               for (int i = 0; i < 6; i++)
                {
                    if (i == 0)
                    {
                        Console.Write("\n|{E}\t         {N}|");
                    }
                    else if (i == 5)
                    {
                        Console.Write("\n|{Q}\t            |");
                        break;
                    }
                    Console.Write("\n|\t\t    |");
                }
                Console.Write("\n=====================\n");
                Console.WriteLine("\n> N - NPC/Waitstaff");
                Console.WriteLine("> Q - Quests");
                Console.WriteLine("> E - Exit");
                Console.Write("> ");


                while(true)
                {
                    string? userInput = Console.ReadLine();

                    if(userInput != null)
                    {
                        if(userInput == "n")
                        {
                            Npc1();
                            Menu();
                            
                            string? MenuInput = Console.ReadLine();
                            if(MenuInput != null)
                            {
                                switch(MenuInput.ToLower())
                                {
                                    case "1":
                                        Console.WriteLine("You have chosen the Italian dish.\nIt costs 15 dollars.");
                                        break;
                                    case "2":
                                        Console.WriteLine("You have chosen the Mexican dish.\nIt costs 10 dollars.");
                                        break;
                                    case "3":
                                        Console.WriteLine("You have chosen the Chinese dish.\nIt costs 5 dollars.");
                                        break;
                                }
                            }
                            
                        }
                        else if(userInput == "q")
                        {
                            Console.WriteLine("Press enter to continue");
                            //ShowQuests();
                        }
                        else if(userInput == "e")
                        {
                            Console.WriteLine("You left the restaurant.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                            Console.WriteLine("Press enter and try again");
                        }            
                    }
                }
        }
        public static void Main()
        {
            EnterRestaurant();
        }
    }
}