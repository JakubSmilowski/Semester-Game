using System.Collections;
using System.Collections.Immutable;
using System.Data.Common;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

//To do:
//Add Npc?
//Add some kind of quest?


namespace foodman
{
    public class Base
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
                //Displayes greeting message:
                GreetPlayer();
                //Displaying stats and drawing the base: 
                DrawBase();

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
                        case "i":
                            Items.OpenInventory();
                            Console.ReadLine();
                            break;
                        case "r":
                            Rest();
                            Console.WriteLine("Press [Any key] to leave.");
                            Console.ReadLine();
                            break;
                        case "p":
                            ShowProgress();
                            Console.WriteLine("Press [Any key] to leave.");
                            Console.ReadLine();
                            break;
                        case "s":
                            Console.Clear();
                            Console.WriteLine("You left the base");
                            return;
                        case "a":
                            if (Player.IsActionPossible())
                            {
                                Player.MakeAction();
                                //Choses wich quiz to display depending on already completed ones.
                                switch (id)
                                {
                                    case 0:
                                        //Assigns if quest has been completed or not.
                                        QuizzesProgress = QuizOfTheLocation1();

                                        break;
                                    case 1:
                                        QuizzesProgress = QuizOfTheLocation2();

                                        break;
                                    case 2:
                                        QuizzesProgress = QuizOfTheLocation3();
                                        id += 1;
                                        Location.quizComp[6] = QuizzesProgress;

                                        break;
                                    default:
                                        // if id is equal to 3 and  quizzesProgress is true then quizzes are completed, becouse id
                                        // is incremented only when quiz is completed.
                                        Console.WriteLine("You already finished quizzes of this location!");
                                        break;
                                }
                            }
                            Console.WriteLine("Press [Any key] to continue.");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Input correct value!");
                            Console.WriteLine("Press [Any key], and try again!");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorect input!");
                    Console.WriteLine("Press [Any key], and try again!");
                    Console.ReadLine();
                }
            } while (true);
        }

        private static void DrawBase(){
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
                        Console.Write("\n| A \t          R |");
                        break;
                    }
                    Console.Write("\n|\t\t    |");
                }
                Console.Write("\n=====================\n");

                //Possible options
                Console.WriteLine("\n> [U] Upgrade");
                Console.WriteLine("> [I] Open Inventory");
                Console.WriteLine("> [R] Rest");
                Console.WriteLine("> [A] Start quiz ");
                Console.WriteLine("> [P] Progress");
                Console.WriteLine("> [S] Leave");
                Console.Write("> ");
        }

        static void GreetPlayer() {
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
        }

        //Quizzes of the base 
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
                        return false;
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
        //Third quiz of the base.
        static bool QuizOfTheLocation3()
        {
            Console.Clear();
            Console.WriteLine(@"
> What is the estimated economic cost of global food waste, including both consumer and supply chain losses?

> [A] $100 billion
> [B] $1 trillion
> [C] $2.5 trillion
> [D] $500 million");
            string? userInput = Console.ReadLine();

            if (userInput != null)
            {
                switch (userInput.ToLower())
                {
                    case "a":
                        Console.WriteLine(@"

> Your answer: [A] 
> This is not a correct answer. Try again later :)

> This figure underestimates the economic impact of food waste. 
> The actual cost is significantly higher due to the scale and widespread nature of the issue.");
                        return false;
                    case "b":
                        Console.WriteLine(@$"

> Your answer: [B] 
> This is not a correct answer. Try again later!

> While closer to the actual cost, $1 trillion is still below the estimated economic impact of global food waste. 
> The $2.5 trillion figure better captures the extensive financial consequences.
");
                        return false;
                    case "c":
                        Console.WriteLine(@$"

> Your answer: [C] 
> This is a correct answer!

> This staggering economic cost of $2.5 trillion represents the combined impact 
> of both consumer and supply chain losses associated with global food waste.

> You completed all the quizzes in the base!!! You get 500xp and 100$");
                        QuizzCorrect(500, 100);
                        return true;
                    case "d":
                        Console.WriteLine(@$"
> Your answer [D]
> This is not a correct answer. Good luck next time!

> This option significantly underestimates the economic impact of food waste.
> The actual cost is orders of magnitude greater, emphasizing the need for comprehensive solutions 
> to mitigate financial losses associated with wasted food.");
                        return false;
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
        public static void QuizzCorrect(double xp, double money)
        {
            Location.progress[6] += 1;
            Base.id += 1;
            Player.AddMoney(money);
            Player.AddAndCheckXp(xp);
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
                Console.WriteLine($"> 1. Action Points - Currently tier {actionPointsUpgrades} costs {actionPointsUpgrades + 2} level point");
                Console.WriteLine($"> 2. Inventory Capacity - Currently tier {inventoryUpgrades} costs {inventoryUpgrades + 2} level point");
                Console.WriteLine($"> 3. Money Multiplier - Currently tier {moneyMultiplierUpgrades} costs {moneyMultiplierUpgrades + 2} level point");
                Console.WriteLine($"> 4. Xp Multiplier - Currently tier {xpMultiplierUpgrades} costs {xpMultiplierUpgrades + 2} level point");
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
                            if (IsEnughLevelPoints(actionPointsUpgrades + 2))
                            {
                                Player.UpgradeActionPoints(actionPointsUpgrades, actionPointsUpgrades + 2);
                                actionPointsUpgrades += 1;
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
                            if (IsEnughLevelPoints(inventoryUpgrades + 2))
                            {
                                Player.UpgradeInventoryCapacity(inventoryUpgrades, inventoryUpgrades + 2);
                                inventoryUpgrades++;
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
                            if (IsEnughLevelPoints(moneyMultiplierUpgrades + 2))
                            {
                                moneyMultiplierValue += 0.2;
                                Player.UpgradeMoneyMultiplier(moneyMultiplierValue, moneyMultiplierUpgrades + 2);
                                moneyMultiplierUpgrades++;
                                Console.WriteLine("> You upgraded money multiplier. ");
                                Console.WriteLine($"> Current money multiplier {Player.moneyMultiplier * 100}%. ");
                            }
                            else
                            {
                                Console.WriteLine("> You dont have enough points to upgrade this sat! Level up and try again later!");
                            }
                            Console.WriteLine("> Press enter to continue: ");
                            Console.ReadLine();
                            break;
                        case "4":
                            if (IsEnughLevelPoints(xpMultiplierUpgrades + 2))
                            {
                                xpMultiplierValue += 0.2;
                                Player.UpgradeXpMultiplier(xpMultiplierValue, xpMultiplierUpgrades + 2);
                                xpMultiplierUpgrades++;
                                Console.WriteLine("> You upgraded xp Multiplier. ");
                                Console.WriteLine($"> Current xp multiplier {Player.xpMultiplier * 100}%. ");
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
        static void ShowProgress()
        {
            /*  0 - Grocery Store
             *  1 - Restaraunt
             *  2 - House
             *  3 - Factory
             *  4 - Junkyard
             *  5 - Recycling centre
             *  6 - Base - just for quizComp and progress

             */
            Console.Clear();

            Console.WriteLine("Progress of quizzes:");

            for (int i = 0; i <= 6; i++)
            {
                if (i != 0)
                {
                    Console.WriteLine("--------------------------------");
                }
                else
                {

                    Console.WriteLine("\n==================================");
                }

                switch (i)
                {
                    case 0:
                        Console.Write("Grocery Store - ");
                        break;
                    case 1:
                        Console.Write("Restaurant - ");
                        break;
                    case 2:
                        Console.Write("House - ");
                        break;
                    case 3:
                        Console.Write("Factory - ");
                        break;
                    case 4:
                        Console.Write("Junkyard - ");
                        break;
                    case 5:
                        Console.Write("Recycling centere - ");
                        break;
                    case 6:
                        Console.Write("Base - ");
                        break;
                    default:
                        Console.Write("Out of range!");
                        break;
                }
                ProgressMessage(i, Location.progress[i]);
                if (i == 6)
                {
                    Console.WriteLine("==================================");
                }
            }
        }

        static void ProgressMessage(int locationId, int progress)
        {
            if (progress == 2)
            {
                Console.WriteLine("All quizzes completed");
            }
            else if (locationId == 6)
            {
                Console.WriteLine($"Available quizzes - {3 - progress}  "); // in future this 3 could be a variable
            }
            else
            {
                Console.WriteLine($"Available quizzes - {2 - progress}  ");
            }
        }

        //*Probably won't be used, inventory was done a little different now.*
        //Open Inventry method
        // public static void OpenInventory()
        // {
        //     // if(Items.<item>.Quantity) Console.Write(Items.<item>.Name){

        //     //}
        //     do
        //     {
        //         //Displays all thee items in inventory
        //         string? userInput = Console.ReadLine();

        //         if (userInput != null) {
        //             switch (userInput) 
        //             {
        //                 case "u":
        //                     //Use item
        //                     return;
        //                 case "e":
        //                     Console.Clear();
        //                     Console.WriteLine("> Closing invenory.");
        //                     return;
        //             }
        //         }
        //     } while (true);
        // }










        //Namespace and class
    }
}

