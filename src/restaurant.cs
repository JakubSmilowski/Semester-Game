using System.Diagnostics;
using Microsoft.VisualBasic;

namespace foodman
{
    public class Restaurant
    {


        public static void Menu()
        {
            Console.WriteLine("=======Menu=======");
            Console.WriteLine(" 1.Italian dish - 15 dollars\n 2.Mexican dish - 10 dollars\n 3.Chinese dish - 5 dollars\n 4. Exit");
        }
        public static void Npc1()
        {           
            string? userInput;
            

            do
            {
                Console.WriteLine("Press M to see the menu or L to quit");
                userInput = Console.ReadLine()?.ToUpperInvariant();

                if(userInput != null)
                {
                    switch (userInput)
                    {
                        case "M":
                            Menu();
                            string? menuInput;
                            do
                            {
                                menuInput = Console.ReadLine()?.ToLower();
                            
                                    switch(menuInput)
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
                                        case "4":
                                            break;
                                        default:
                                            Console.WriteLine("Invalid menu input. Please try again");
                                            break;    
                                    }
                            }while(menuInput != "4");
                            break;
                        case "H":
                            Program.RestarauntQuizz();
                            break;
                        case "L":
                            Console.WriteLine("Exiting the loop. Goodbye!");
                            EnterRestaurant();
                            return;
                            
                        default:
                            Console.WriteLine("Incorrect input. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again");
                }
            }while(true);
            
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
                Console.WriteLine("> Q - Quizz");
                Console.WriteLine("> E - Exit");
                Console.Write("> ");

                
                

                string? userInput;
                do
                {
                        
                        userInput = Console.ReadLine()?.ToLower();
                        switch(userInput)
                        {
                            case "n":
                                Npc1();
                                break;    

                            case "q":
                                Program.RestarauntQuizz();
                                break;

                            case "e":
                                Console.WriteLine("You left the restaurant.");
                                break;

                            default:    
                                Console.WriteLine("Invalid input");
                                Console.WriteLine("Press enter and try again");
                                break;
                        }        
                }while(userInput != "e");   
        }
       
    }
}