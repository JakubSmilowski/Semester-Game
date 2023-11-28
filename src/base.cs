using System.Collections.Immutable;
using System.Data.Common;
using System.Diagnostics;

namespace foodman
{
    class Base
    {

        public static int actionPointsUpgrades { get; set; } = 1;
        public static int inventoryUpgrades { get; set; } = 1;
        public static int moneyMultiplierUpgrades { get; set; } = 1;
        public static int xpMultiplierUpgrades { get; set; } = 1;

        public static double moneyMultiplierValue { get; set; } = 1;
        public static double xpMultiplierValue { get; set; } = 1;

        public static int xShopPosition { get; set; } = 6;
        public static int yShopPosition { get; set; } = 6;

        public static int xBedPosition { get; set; } = 6;
        public static int yBedPosition { get; set; } = 1;

        public static int xQuestPosition { get; set; } = 1;
        public static int yQuestPosition { get; set; } = 6;

        public static bool QuizzesProgress { get; set; } = false;
        public static int id = 0;

        //Main method
        public static void EnterBase()
        {

            do
            {
                // Greeting message
                Console.Clear();
                if (Player.turn <= 1)
                {
                    GreetingMessageStart(Player.name);
                }
                else
                {
                    GreetingMessageDefault(Player.name);
                }
                //Displaying stats: 
                Player.DisplayBasicStats();
                // Visual representation of the base 
                Console.Write("\n=====================");

                //Value i indicates how how hight the border of the base is.
                for (int i = 0; i < 6; i++)
                {
                    if (i == 0)
                    {
                        Console.Write("\n| E \t          U |");
                    }
                    else if (i == 5)
                    {
                        Console.Write("\n| Q \t          R |");
                        break;
                    }
                    Console.Write("\n|\t\t    |");
                }
                Console.Write("\n=====================\n");

                //Possible options
                Console.WriteLine("\n> [U] - Upgrade");
                Console.WriteLine("> [R] - Rest");
                Console.WriteLine("> [Q] - Quests");
                Console.WriteLine("> [A] - Start quest");
                Console.WriteLine("> [E] - Exit");
                Console.Write("> ");

                //User input
                string? userInput = Console.ReadLine();

                //Choice of the player logic.
                if (userInput != null)
                {
                    switch (userInput.ToLower())
                    {
                        case "u":
                            EnterUpgradeShop();
                            break;
                        case "r":
                            Rest();
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case "q":
                            //ShowQuests();
                            Console.WriteLine("Work in progress!");
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case "e":
                            Console.Clear();
                            Console.WriteLine("You left the base");
                            return;
                        case "a":    
                            if (Player.IsActionPossible())
                            {
                                Player.MakeAction();
                                //Choses wich quiz to display depending on already completed ones.
                                switch(id) {
                                    case 0:
                                        //Assigns if quest has been completed or not.
                                        QuizzesProgress = QuizOfTheLocation1();
                                        break;
                                    case 1:
                                        QuizzesProgress = QuizOfTheLocation2();
                                        break;
                                    // case 2:
                                    //     //QuizProgress[0] = QuizOfTheLocation1();
                                    //     //id += 1;
                                    // break;
                                    default:
                                        // if id is equal to 3 and  quizzesProgress is true then quizzes are completed, becouse id
                                        // is incremented only when quiz is completed.
                                         Console.WriteLine("You already finished quizzes of this location!");
                                         break;
                                }                                
                            }
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            return;
                        default:
                            Console.WriteLine("Input correct value!");
                            Console.WriteLine("Press enter and try again!");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorect input!");
                    Console.WriteLine("Press enter and try again!");
                    Console.ReadLine();
                }
            } while (true);
        }

        //Quizzes of the base 
        //In the future it can be implemented more optimal
        static bool QuizOfTheLocation1()
        {
            Console.Clear();
            Console.WriteLine(@"
> In your quest to combat food waste within FOODMAN, you come across a scenario where you have several overripe fruits in your inventory. To address this, what action would be most effective in minimizing food waste?

> [A] Selling the overripe fruits at the Junkyard to recoup some losses.
> [B] Upgrading Money Multiplier to afford better-quality fruits in the future.
> [C] Creating a weekly meal plan to use the overripe fruits in various recipes.
> [D] Upgrading Action Points to quickly move between locations and dispose of the fruits responsibly.");
            string? userInput = Console.ReadLine();

            if (userInput != null)
            {
                switch (userInput.ToLower())
                {
                    case "a":
                        Console.WriteLine(@"

> Your answer: [A] 
> This is not a correct answer. Try again later!

> Selling overripe fruits may provide some monetary gain, but it doesn't address the root cause of food waste. 
> The focus should be on finding ways to use or repurpose the fruits.");
                        return false;
                    case "b":
                        Console.WriteLine(@$"

> Your answer: [B] 
> This is not a correct answer. Try again later!

> While having better-quality fruits is desirable, upgrading the Money Multiplier doesn't directly address the issue of existing overripe fruits. 
> It's more about preventing waste in future purchases.");
                        return false;
                    case "c":
                        Console.WriteLine(@$"

> Your answer: [C]                       
> By incorporating the overripe fruits into a meal plan, you optimize their use and reduce the likelihood of them going to waste. 
> This strategy aligns with responsible decision-making within the context of combating food waste in FOODMAN.

> Excellent choice, {Player.name}! Your commitment to practical solutions will certainly make a positive impact on reducing food waste in your gameplay.
> Keep up the resourceful decision-making! 

> You gained 100xp and 20$. ");
                        QuizzCorrect(100, 20);
                        return true;
                    case "d":
                        Console.WriteLine(@$"
> Your answer [D]
> This is not a correct answer try again later!

> While disposing of fruits responsibly is essential, upgrading Action Points doesn't directly provide a solution for utilizing the overripe fruits. 
> It's more focused on movement efficiency rather than addressing the food waste issue.");
                        return false;
                    default:
                        Console.WriteLine("Input correct value!");
                        Console.WriteLine("Press enter and try again!");
                        Console.ReadLine();
                        QuizOfTheLocation1();
                        return false;
                }
            }
            else
            {

                Console.WriteLine("Incorect input!");
                Console.WriteLine("Press enter and try again!");
                Console.ReadLine();
                QuizOfTheLocation1();
                return false;
            }
        }
        //second quiz
        static bool QuizOfTheLocation2()
        {
            Console.Clear();
            Console.WriteLine(@"
> In your exploration of food waste within FOODMAN, consider the following scenario: In which stage of the food supply chain does the most significant amount of food waste occur?

> [A] Production/Farming
> [B] Distribution
> [C] Retail
> [D] Consumer");
            string? userInput = Console.ReadLine();

            if (userInput != null)
            {
                switch (userInput.ToLower())
                {
                    case "a":
                        Console.WriteLine(@"

> Your answer: [A] 
> This is not a correct answer. Try again later!

> While food waste does occur in the production/farming stage, it is often attributed to issues such as imperfect produce,
> overproduction, and inefficient harvesting methods.
> However, the percentage of waste during distribution tends to be higher.");
                        return false;
                    case "b":
                        Console.WriteLine(@$"

> Your answer: [B] 
> This is not a correct answer. Try again later!

> Distribution involves the transportation, handling, and storage of food from the farm to various retail outlets. 
> Factors such as inadequate infrastructure, improper storage conditions,
> and inefficient transportation contribute significantly to food waste in this stage. 
> According to data from the Food and Agriculture Organization (FAO), 
> around 21% of global food waste occurs during distribution.
");
                        return false;
                    case "c":
                        Console.WriteLine(@$"

> Your answer: [C] 
> This is not a correct answer try again later!

> Retail waste is primarily associated with unsold goods, expired products, and aesthetic standards imposed by retailers.
> While this is a significant concern, the overall percentage of waste in the distribution stage tends to be higher.");
                        return true;
                    case "d":
                        Console.WriteLine(@$"
> Your answer [D]
> Correct!

> Consumer food waste occurs at the end of the supply chain when individuals discard food at home.
> While this stage is crucial for awareness and behavior change, 
> the proportion of waste at the distribution stage is generally more substantial.

> You get 100xp and 20$.");
                        QuizzCorrect(100, 20);
                        return true;
                    default:
                        Console.WriteLine("Input correct value!");
                        Console.WriteLine("Press enter and try again!");
                        Console.ReadLine();
                        QuizOfTheLocation2();
                        return false;
                }
            }
            else
            {

                Console.WriteLine("Incorect input!");
                Console.WriteLine("Press enter and try again!");
                Console.ReadLine();
                QuizOfTheLocation2();
                return false;
            }
        }

        //Method caled after correctly answering the question.
        private static void QuizzCorrect(double money, double xp) {
            Base.id += 1;
            Player.AddMoney(money);
            Player.AddAndCheckXp(Player.CalculateXp(xp));
        }

        //Rest method allows player to skip turn to gain extra action points.
        static void Rest()
        {
            Console.WriteLine("You are resting");
            Console.WriteLine($"skiping to day {(Player.turn + 1)}");
            Player.NextTurn();
            Player.RestoreActionPoints();
        }
        static void GreetingMessageStart(string name)
        {
            Console.WriteLine(@$"
Welcome to the Base, {name}!

As you step into the central hub of FOODMAN, you feel the calm atmosphere enveloping you. 
The Base serves as your sanctuary, a place for strategic planning, upgrades, and a moment of respite before 
venturing back into the challenges that await you. 
Here, you can upgrade your character, plan your next moves, and reflect on the journey so far. 
Take a deep breath, recharge your spirit, and let's continue our mission to save the world from the impending global apocalypse.
");
        }
        static void GreetingMessageDefault(string name)
        {
            Console.WriteLine($"Welcome to the Base, {name}!");
        }
        //Upgrade shop logic.
        static void EnterUpgradeShop()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("You entered upgrade shop.\n");
                Console.WriteLine($"You currently have: {Player.levelPoints} points. \nWhat do you want to upgrade:\n");
                Console.WriteLine($"> 1. Action Points - Currently tier {actionPointsUpgrades} costs {actionPointsUpgrades + 1} level point");
                Console.WriteLine($"> 2. Inventory Capacity - Currently tier {inventoryUpgrades} costs {inventoryUpgrades + 1} level point");
                Console.WriteLine($"> 3. Money Multiplier - Currently tier {moneyMultiplierUpgrades} costs {moneyMultiplierUpgrades + 1} level point");
                Console.WriteLine($"> 4. Xp Multiplier - Currently tier {xpMultiplierUpgrades} costs {xpMultiplierUpgrades + 1} level point");
                Console.WriteLine($"> E - Exit");
                Console.Write("> ");

                //User input
                string? userInput = Console.ReadLine();

                //Choice of the player logic.
                if (userInput != null)
                {
                    switch (userInput.ToLower())
                    {
                        case "1":
                            if (IsEnughLevelPoints(actionPointsUpgrades))
                            {
                                actionPointsUpgrades++;
                                Player.UpgradeActionPoints(actionPointsUpgrades);
                                Console.WriteLine("> You upgraded action Points. ");
                                Console.WriteLine($"> Current maximum amount {Player.maxActionPoints}. ");
                            }
                            else
                            {
                                Console.WriteLine("> You dont have enough points to upgrade this sat! Level up and try again later!");
                            }
                            Console.WriteLine("> Press enter to continue: ");
                            Console.ReadLine();
                            break;
                        case "2":
                            if (IsEnughLevelPoints(inventoryUpgrades))
                            {
                                inventoryUpgrades++;
                                Player.UpgradeInventoryCapacity(inventoryUpgrades);
                                Console.WriteLine("> You upgraded max inventory. ");
                                Console.WriteLine($"> Current maximum inventory capacity {Player.maxInventoryCapacity}. ");
                            }
                            else
                            {
                                Console.WriteLine("> You dont have enough points to upgrade this sat! Level up and try again later!");
                            }
                            Console.WriteLine("> Press enter to continue: ");
                            Console.ReadLine();
                            break;
                        case "3":
                            if (IsEnughLevelPoints(moneyMultiplierUpgrades))
                            {
                                moneyMultiplierUpgrades++;
                                moneyMultiplierValue += 0.2;
                                Player.UpgradeMoneyMultiplier(moneyMultiplierValue);
                                Console.WriteLine("> You upgraded money multiplier. ");
                                Console.WriteLine($"> Current money multiplier {Player.moneyMultiplier}. ");
                            }
                            else
                            {
                                Console.WriteLine("> You dont have enough points to upgrade this sat! Level up and try again later!");
                            }
                            Console.WriteLine("> Press enter to continue: ");
                            Console.ReadLine();
                            break;
                        case "4":
                            if (IsEnughLevelPoints(xpMultiplierUpgrades))
                            {
                                xpMultiplierUpgrades++;
                                xpMultiplierValue += 0.2;
                                Player.UpgradeXpMultiplier(xpMultiplierValue);
                                Console.WriteLine("> You upgraded xp Multiplier. ");
                                Console.WriteLine($"> Current xp multiplier {Player.xpMultiplier}. ");
                            }
                            else
                            {
                                Console.WriteLine("> You dont have enough points to upgrade this sat! Level up and try again later!");
                            }
                            Console.WriteLine("> Press enter to continue: ");
                            Console.ReadLine();
                            break;
                        case "e":
                            Console.Clear();
                            Console.WriteLine("> You left the upgrade shop");
                            return;
                        default:
                            Console.WriteLine("> Input correct value!");
                            Console.WriteLine("> Press enter to continue: ");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorect input!");
                    Console.WriteLine("Press enter and try again!");
                    Console.ReadLine();
                }

            } while (true);
        }
        // Checks if there is enough points to upgrade, if so substract levelPoints and adds 1 to levelOfUprgrade of stat.
        static bool IsEnughLevelPoints(int statUpgradeLevel)
        {
            if (Player.levelPoints >= (statUpgradeLevel + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Quest display 
        // static void ShowQuests(quest[] questsInProgress, quest[] questCompleted)
        // {
        //     Console.Clear();
        //     Console.WriteLine("Quests in progress: ");
        //     foreach (quest quest in questsInProgress){
        //         Console.WriteLine(quest);
        //         Console.WriteLine("==============================");
        //     }
        //     Console.WriteLine("Completed quests:");
        //     foreach (quest quest in questCompleted){
        //         Console.WriteLine(quest);
        //         Console.WriteLine("==============================");
        //     }
        //     Console.WriteLine("Press enter to continue: ");
        //     Console.ReadLine();
        // }
    }
}

