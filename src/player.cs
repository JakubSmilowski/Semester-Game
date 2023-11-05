using System.Diagnostics.Tracing;

namespace PlayerClass
{
    class Player
    {
        static int turn = 1;
        static int actionPoints = 3;
        static int level = 1;

        static int money = 100;
        static int levelPoints = 0;

        static int maxActionPoints = 5;
        static int maxInventoryCapacity = 5;
        static int moneyMultiplier = 1;
        static int xpMultiplier = 1;

        static int currentXPosition = 1;
        static int currentYPosition = 1;

        //Next day
        static void NextTurn(int endOfTheWorld){
            if(turn >= endOfTheWorld) {
                Console.WriteLine("You lost!");
            }else {
                turn +=1;
                Console.WriteLine($"You slept like a baby, today is day: {turn}");
            }
        }
        //Used during action
        static void MakeAction(){
            if(!(actionPoints == 0)){
                actionPoints -= 1;
            }else{
                Console.WriteLine("You run out of action points! You can restore them in base.");
            }
        }
        //Restores action points to it's maximum amount
        static void RestoreActionPoints()
        {
            actionPoints = maxActionPoints;
        }
        //Levles up the player. For each lvel player gains 2 level points.
        static void LevelUp()
        {
            level += 1;
            levelPoints += 2;
            
        }
        static void AddMoney(int value)
        {
            money += value;
        }

        static void PayWithMoney(int moneyValue)
        {
            if (money < value)
            {
                Console.WriteLine("You don't have enough money!");
            }
            else
            {
                Console.WriteLine("Payment succeeded");
                money -= value;
            }
        }
        //Upgrades action points
        static void UpgradeActionPoints(int newMaxActionPoints){
            if(newMaxActionPoints > maxActionPoints){
                maxActionPoints = newMaxActionPoints;
            } else {
                Console.WriteLine("This is not a correct max action points value! ");
            }
            
        }
        //Upgrade Inventory capacity
        static void UpgradeInventoryCapacity(int newInventoryCapacity){
           if(maxInventoryCapacity < newInventoryCapacity) {
            maxInventoryCapacity = newInventoryCapacity;
           }
           else{
            Console.WriteLine("This is not a correct max inventory value!");
           }
        }
        //Upgrades Money multiplier
        static void UpgradeMoneyMultiplier(int newMoneyMultiplier) {
            if(moneyMultiplier < newMoneyMultiplier){
                moneyMultiplier = newMoneyMultiplier;
            }
            else{
                Console.WriteLine("This is not a correct money multiplier value!");
            }
        }
        //Upgrades Xp multiplier
        static void UpgradeXpMultiplier(int newXpMultiplier) {
            if(xpMultiplier < newXpMultiplier){
                xpMultiplier = newXpMultiplier;
            }
            else{
                Console.WriteLine("This is not a correct Xp multiplier value!");
            }
        }
        //Saves Current Position
        static void SaveCurrentPosition(int xPositon, int yPosition) {
            currentXPosition = xPositon;
            currentYPosition = yPosition;
        }

        //Displays main stats
        static void DisplayBasicStats(){
        Console.WriteLine($"> Day: {turn}");
        Console.WriteLine($"> Level: {level} ");
        Console.WriteLine($"> Action points left: {actionPoints} ");
        Console.WriteLine($"> Money: {money}");
        }   
        //Displays upgrade stats.
        static void DisplayUpgradeStats(){
            Console.WriteLine($"> Your are curretly level: {level}");
            Console.WriteLine($"> Level points left: {levelPoints}");
            Console.WriteLine($"> Your curret max inventory: {maxInventoryCapacity}");
            Console.WriteLine($"> Your curret money multiplier {moneyMultiplier}");
            Console.WriteLine($"> Your curret xp multiplier {xpMultiplier}");
        }

    }
}