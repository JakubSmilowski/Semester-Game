using System.Diagnostics.Tracing;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace foodman
{
    class Player
    {
        public static string name { get; set; } = "";
        public static int turn { get; private set; } = 1;

        public static DateTime currentlyDate = new DateTime(2009, 9, 1);

        public static int actionPoints { get; private set; } = 5;
        private static int level { get; set; } = 1;
        private static double xp { get; set; } = 0;
        private static double xpRequired { get; set; } = 100;
        public static int levelPoints { get; private set; } = 0;

        private static double money { get; set; } = 100;
        public static int maxActionPoints { get; private set; } = 5;
        public static int maxInventoryCapacity { get; private set; } = 5;
        public static double moneyMultiplier { get; private set; } = 1;
        public static double xpMultiplier { get; private set; } = 1;

        private static int endOfTheGame { get; set; } = 7;
        private static int greenPointsNeededToWin { get; set; } = 22;
        public static int greenPoints { get; private set; } = 0;

        public static bool questtoday = false;
        public static bool quiztoday = false;

        // Player constructor
        public Player(string name, int actionPoints, int money, int endOfTheGame, int greenPointsNeededToWin)
        {
            Player.name = name;
            Player.actionPoints = actionPoints;
            Player.money = money;
            Player.endOfTheGame = endOfTheGame;
            Player.greenPointsNeededToWin = greenPointsNeededToWin;
        }
        //Set name 
        public static void ChangeName(string newName)
        {
            name = newName;
        }

        //Next day
        public static void NextTurn()
        {
            if (turn >= endOfTheGame)
            {
                if (greenPoints >= greenPointsNeededToWin)
                {
                    Console.WriteLine("You won! NEW HIGH SCORE!");
                    Console.WriteLine("All player stats in this game:");
                    DisplayBasicStats();
                    DisplayUpgradeStats();
                    EndOfTheGameMessage();
                }
                else
                {
                    Console.WriteLine("You run out of time to colect required green points. Good luck next time!");
                    return;
                }
            }
            else
            {
                currentlyDate = NextDay(currentlyDate);
                turn += 1;
                Console.WriteLine($"You slept like a baby, today is day: {turn}");
            }
        }
        private static DateTime NextDay(DateTime currentDate)
        {
            // Increment the date by one day
            currentDate = currentDate.AddDays(1);

            // Check if we need to move to the next month
            if (currentDate.Day == 1)
            {
                currentDate = currentDate.AddMonths(1);
            }

            return currentDate;

        }
        //Checks if action possible!
        public static bool IsActionPossible()
        {
            if (actionPoints == 0)
            {
                Console.WriteLine($"================================================");
                Console.WriteLine("Action is not possible! Not enough action points.");
                Console.WriteLine($"================================================");
                return false;
            }
            return true;
        }
        //Used during action
        public static bool MakeAction()
        {
            if (IsActionPossible())
            {
                actionPoints -= 1;
                return true;
            } else { return false; }
        }
        //Restores action points to it's maximum amount
        public static void RestoreActionPoints()
        {
            actionPoints = maxActionPoints;
        }
        //Levles up the player. For each lvel player gains 2 level points.
        public static void LevelUp()
        {
            level += 1;
            levelPoints += 2;
            xp -= xpRequired;
            xpRequired *= 1.2;
            xpRequired = Math.Round(xpRequired);
            double neededXp = xpRequired - xp;
            if (neededXp > 0)
            {
                Console.WriteLine($"======================================================");
                Console.WriteLine($"You level up to {level}lv! Next level up in {neededXp} xp");
                Console.WriteLine($"======================================================");
            }


        }
        //Checks if player can level up.
        public static void AddAndCheckXp(double xpGained)
        {
            xpGained = CalculateXp(xpGained);
            xp += xpGained;
            while (xp >= xpRequired)
            {
                LevelUp();
            }
        }
        //Adds greenPoints
        public static void AddGreenPoints(int value)
        {
            greenPoints += value;
        }
        //Adds money and calls method calculatemoney
        public static void AddMoney(double value)
        {
            value = CalculateMoney(value);
            money += value;
        }

        public static void SubstractMoney(int moneyValue)
        {
            if (money < moneyValue)
            {
                Console.WriteLine("You don't have enough money!");
            }
            else
            {
                Console.WriteLine($"Succesfully payed {moneyValue}$");
                money -= moneyValue;
            }
        }
        //Upgrades action points
        public static void UpgradeActionPoints(int newMaxActionPoints, int upgradedStatLevel)
        {
            newMaxActionPoints += maxActionPoints;
            if (newMaxActionPoints > maxActionPoints)
            {
                SubstractLevelPoints(upgradedStatLevel);
                maxActionPoints = newMaxActionPoints;
            }
            else
            {
                Console.WriteLine("This is not a correct max action points value! ");
            }

        }
        //Upgrade Inventory capacity
        public static void UpgradeInventoryCapacity(int newInventoryCapacity, int upgradedStatLevel)
        {
            if (maxInventoryCapacity < newInventoryCapacity)
            {
                SubstractLevelPoints(upgradedStatLevel);
                maxInventoryCapacity = newInventoryCapacity;
            }
            else
            {
                Console.WriteLine("This is not a correct max inventory value!");
            }
        }
        //Upgrades Money multiplier
        public static void UpgradeMoneyMultiplier(double newMoneyMultiplier, int upgradedStatLevel)
        {
            if (moneyMultiplier < newMoneyMultiplier)
            {
                SubstractLevelPoints(upgradedStatLevel);
                moneyMultiplier = newMoneyMultiplier;
            }
            else
            {
                Console.WriteLine("This is not a correct money multiplier value!");
            }
        }
        //Upgrades Xp multiplier
        public static void UpgradeXpMultiplier(double newXpMultiplier, int upgradedStatLevel)
        {
            if (xpMultiplier < newXpMultiplier)
            {
                SubstractLevelPoints(upgradedStatLevel);
                xpMultiplier = newXpMultiplier;
            }
            else
            {
                Console.WriteLine("This is not a correct Xp multiplier value!");
            }
        }
        //Substracts level points if spend
        private static void SubstractLevelPoints(int value)
        {
            levelPoints -= value;
        }

        //Calculate xp gained
        private static double CalculateXp(double xpGained)
        {
            if (xpGained != 0)
            {
                return xpMultiplier * xpGained;
            }
            else
            {
                return 0;
            }
        }
        //Calculate money gained
        private static double CalculateMoney(double moneyGained)
        {
            if (moneyGained != 0)
            {
                return moneyMultiplier * moneyGained;
            }
            else
            {
                return 0;
            }
        }

        //Displays main stats
        public static void DisplayBasicStats()
        {
            Console.WriteLine($"> Day: {turn}");
            Console.WriteLine($"> Level: {level}, xp points: {xp}/{xpRequired} ");
            Console.WriteLine($"> Action points left: {actionPoints} ");
            Console.WriteLine($"> Money: {money}");
        }
        //Displays upgrade stats.
        public static void DisplayUpgradeStats()
        {
            Console.WriteLine($"> Your are curretly level: {level}");
            Console.WriteLine($"> Level points left: {levelPoints}");
            Console.WriteLine($"> Your curret max inventory: {maxInventoryCapacity}");
            Console.WriteLine($"> Your curret money multiplier {moneyMultiplier}");
            Console.WriteLine($"> Your curret xp multiplier {xpMultiplier}");
        }
        // //Saves Current Position
        // public static void SaveCurrentPosition(int xPositon, int yPosition)
        // {
        //     currentXPosition = xPositon;
        //     currentYPosition = yPosition;
        // }

        static string Truncate(double value, int precision)
        {
            string result = value.ToString();

            int dot = result.IndexOf(',');
            if (dot < 0)
            {
                return result;
            }

            int newLength = dot + precision + 1;

            if (newLength == dot + 1)
            {
                newLength--;
            }

            if (newLength > result.Length)
            {
                newLength = result.Length;
            }

            return result.Substring(0, newLength);
        }

        //Messege displayed when limited time for playing comes to an end
        private static void EndOfTheGameMessage(){
            Console.WriteLine("Thank you for playing FOODMAN!");
        }






    }
}