using System.Collections;
using System.ComponentModel;
using System.Security;
using foodman;
using Microsoft.VisualBasic.FileIO;

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
    public static bool isPurchasedFood = false; //its for the restaurant quest, dont remove
    public static void RestaurantQuest()
    {
        
        Console.WriteLine("Good job, you found the secret quest!");
        Console.WriteLine("To complete the quest you have to order a meal from the menu.");
        Player.MakeAction();
        if(isPurchasedFood == true)
        {
            Location.progress[1] += 1;
        }
        

    }
    public static void Factory2()
    {
        Console.WriteLine("You visit the factory. You see all the food that is being thrown out because it doesn't meet the factory's standarts...");
        Console.WriteLine("Maybe you can talk to someone about this.");
        Console.WriteLine("[A] Go talk to a manager [Any Key] Leave the Factory");
        string? read = Console.ReadLine()?.ToLower();
        if (read == "a")
        {
            Console.WriteLine("Manager: We usually trow the misformed food out, but you can buy it if you want.");
            Console.WriteLine("[A] Buy the food (30$) [Any Key] Leave the Factory");
            read = Console.ReadLine()?.ToLower();
            Player.MakeAction();
            if (read == "a")
            {
                if(Player.money >= 30)
                {
                    Player.SubstractMoney(30);
                    System.Console.WriteLine("Good job!");
                    Items.FoodDeformed.AddRandomAmount(1, 10);
                    questReward(80, 30);
                    Location.progress[3] += 1;
                }
                else
                {
                    System.Console.WriteLine("Not enough money!");
                }
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
        Console.WriteLine("You visit the factory ones again, but this time with a sugestion to the manager to manage the food waste");
        Console.WriteLine("[A] Go to the managers office [Any Key] He probably won't find it interesting");
        string? read = Console.ReadLine()?.ToLower();
        if (read == "a")
        {
            Console.WriteLine(Player.name + ": I have an offer for you.");
            Console.WriteLine("Manager: I'm listening, tell me your offer");
            Console.WriteLine(Player.name + ": I will install better machenes in your factory, which will reduce waste, but you will need to give me a cut of what you saved with these machines.");
            Console.WriteLine("Manager: Sure, why not");
            Console.WriteLine("[A] Buy the machines (500$) [Any Key] On other thoughts its not worth it");
            read = Console.ReadLine()?.ToLower();
            Player.MakeAction();
            if (read == "a" && Player.IsActionPossible())
            {
                if(Player.money >= 500)
                {
                    Player.SubstractMoney(500);
                    System.Console.WriteLine("Good job!");
                    
                    questReward(120, 50);
                    Location.progress[3] += 1;
                }
                else
                {
                    System.Console.WriteLine("Not enough money!");
                }
            }
            else
            {
                Console.WriteLine("You decided to ignore the benefits and save your money.");
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
                    questReward(80, 30);
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
                    questReward(120, 50);
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

    //Junkyard quest
    public static void JunkyardQuest()
    {
        if(Player.IsActionPossible()){
            ExecuteQuestStep("Grizzle, the dedicated Junkyard worker, approaches you with a gleam in their eye.",
                    "Grizzle: Welcome, friend! The Junkyard has stories to tell. Ready to embark on a quest of transformation?\n");

            ExecuteQuestStep("Grizzle gestures toward the sprawling Junkyard.",
                    "Grizzle: This is where it all begins. Explore and observe; the Junkyard holds the tale of food waste.\n");
            Console.WriteLine("Are you redy to start this journey? (Y/N)");
            Console.Write("> ");

            if (userInputValidation()){
                Console.WriteLine("The journey begins...");       
            }else{
                return;
            }

            ExecuteQuestStep("As you wander, Grizzle introduces you to various Junkyard denizens and scrap collectors.",
                    "Grizzle: These folks know the tale of every discarded item. Engage them in conversation, learn about the consequences of improper disposal, and the impact of food waste.\n");

            ExecuteQuestStep("Grizzle challenges you with a quiz to test your knowledge on global food waste and its disposal.",
                "Grizzle: Let's delve into the broader picture of food waste and its impact on the planet.\n");

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            //Quiz of the foodwast, part of the quest.
            Console.WriteLine("Quiz Question: What percentage of global food waste typically ends up in improperly managed locations like junkyards?");
            Console.WriteLine("A) 5%\tB) 25%\tC) 50%\tD) 75%");
            Console.Write("Your answer (enter A, B, C, or D): ");
            string playerAnswer = Console.ReadLine().ToUpper();

            if (playerAnswer == "D")
            {
                Console.WriteLine("Correct! You've earned 10 green points and 20$.");
                Player.AddGreenPoints(10);
                Player.AddMoney(20);
            }
            else
            {
                Console.WriteLine("Incorrect. The correct answer is D) 75%.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();


            ExecuteQuestStep("Grizzle points to a designated area and hands you a sack.",
                    "Grizzle: Time to put theory into practice. Gather recyclable items – focus on food containers, plastic, and paper. We're laying the foundation for change.\n");

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            //Minigame in the quest
            GuessTheNumberMiniGame();

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            ExecuteQuestStep("Grizzle leads you through the process of sorting and recycling.",
                    "Grizzle: Each item has a purpose. Watch as we turn what was once considered waste into valuable resources. It's the first step towards transforming this Junkyard.\n");

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            ExecuteQuestStep("Grizzle reflects on the progress made and the potential for transformation.",
                    "Grizzle: Look around. We've begun the journey from trash to treasure. Share what you've learned, and let's inspire others to contribute to a cleaner, greener future.\n");

            ExecuteQuestStep("Grizzle unveils a blueprint of a Recycling Center.",
                    "Grizzle: The time has come. With your newfound knowledge and the progress we've made, let's propose the establishment of a Recycling Center right here in the Junkyard.\n");
            
            //User input:
            Console.WriteLine("Accept Recycling center blueprint Y/N");
            Console.Write("> ");
            if (userInputValidation()){
                Console.WriteLine("Recycle center blueprint added to your inventory");
                Junkyard.hasRecyclingCenterBlueprint = true;            
            }else{
                Console.WriteLine("You miss the chanse to get bluprint of the recycle center");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Console.WriteLine("\nQuest Completed! You earned green points and made the junkyard a better place.");
            Console.WriteLine("\nYou earn 213xp and 7$");
            Console.WriteLine("Recycling Center Blueprint Unlocked: " + (Junkyard.hasRecyclingCenterBlueprint ? "Yes" : "No"));
            Player.AddAndCheckXp(213);
            Player.AddMoney(7);
            Junkyard.QuestCompleted = true;
        }
    }

    static void GuessTheNumberMiniGame()
    {
        Console.WriteLine("Welcome to trash recycle symulator! Here your score in the guess the number minigame will define your efficiency.");
        Console.WriteLine("I've picked a number between 1 and 100. Try to guess it.");
        Console.WriteLine("Your score will indicate how much recyclable items you gathered!");

        // Generate a random number between 1 and 100
        Random random = new Random();
        int secretNumber = random.Next(1, 101);

        int numberOfTries = 0;
        int userGuess = 0;
        double finalScore = 0;

        while (userGuess != secretNumber)
        {
            Console.Write("Enter your guess: ");
            string userInput = Console.ReadLine();

            // Check if the input is a valid integer
            if (!int.TryParse(userInput, out userGuess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            numberOfTries++;

            if (userGuess < secretNumber)
            {
                Console.WriteLine("You serch too low! Try again.");
            }
            else if (userGuess > secretNumber)
            {
                Console.WriteLine("You serch too high! Try again.");
            }
            else
            {
                finalScore = 100 / numberOfTries;
                Math.Round(finalScore);
                double finalGreenPoints = finalScore*0.2;
                finalGreenPoints = Math.Round(finalGreenPoints);
                Console.WriteLine($"Good job! You gather {finalScore} recyclable items and earn {finalGreenPoints} green points.");
                Player.AddGreenPoints(Convert.ToInt32(finalGreenPoints));
            }
        }
    }

    static bool userInputValidation(){
        string? userInput = Console.ReadLine();

            do{

                if(userInput != null){
                    if(userInput.ToLower()== "y"){
                        return true;
                    }
                    else{
                        return false;
                    }
                }else{
                    Console.WriteLine("Wrong input, try again!");
                }
            }while(true);
    }

    static void ExecuteQuestStep(string description, string dialogue)
    {
        Console.Clear();
        Console.WriteLine($"** {description} **");
        Console.WriteLine(dialogue);
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    //Junkyard quest finish

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
                        questReward(80, 30);
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
                    questReward(120, 50);
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

    public static void House(int progress)
    {
        switch (progress)
        {
            case 0:
                Console.WriteLine("You look into the trash can and see that whoever lives here doesn't sort their trash.");
                Console.WriteLine("The government invites its citizens to sort the trash into food, paper, plastic, metal and other, but some people think that sorting is too hard for them.");
                Console.WriteLine("Robert the Robot's powerful gaze forces you to sort the trash, even if you didn't want to.");
                Location.progress[2]++;
                questReward(80, 30);
                PressToExit("House", 2);
                break;
            case 1:
                Console.WriteLine("└|*-*|┘ - 'There is far too much food in the fridge. Some of it has even started to go bad.'");
                Console.WriteLine("[A] No one could eat this much [Any Key] That's not our problem");
                string? read = Console.ReadLine()?.ToLower();
                if (read == "a")
                {
                    Console.WriteLine("└|*-*|┘ - 'I agree. Let's help them and throw out the moldy food, and donate the food that they don't need'");
                    Console.WriteLine($"{Player.name} - Just don't forget to sort the trash");
                    Console.WriteLine("└|*-*|┘ - 'Okay! Thank you for reminding me.'");
                    Console.WriteLine("[A] Donate the food [Any Key] Just put it in a freezer");
                    read = Console.ReadLine()?.ToLower();
                    if (read == "a")
                    {
                        Console.WriteLine("You throw out the trash while Robert the Robot donates the excess food to people in need");
                        Location.progress[2]++;
                        questReward(120, 50);
                        PressToExit("House", 2);
                    }
                    else
                    {
                        Console.WriteLine("└|*-*|┘ - 'Oh... I guess that's also an option.");
                        PressToExit("House", 2);
                    }
                }
                else
                {
                    Console.WriteLine("└|*-*|┘ - 'I guess you are correct. We have no right to decide what to do with other people's food.'");
                    Console.WriteLine($"{Player.name} - 'It's not our busines, true. Goodbye, Robert'");
                    PressToExit("House", 2);
                }
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

    public static void questReward(int xp, int money)
    {
        System.Console.WriteLine($"Quest is completed. You received {money}$ and {xp} xp.");
        Player.AddAndCheckXp(xp);
        Player.AddMoney(money);
    }
}
