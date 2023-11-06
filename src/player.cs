using System.Diagnostics.Tracing;

namespace FOODMAN
{
    class Player
    {
        public static string name { get; set; } = "";
        public static int turn { get; set; } = 1;
        public static int actionPoints { get; set; } = 3;
        public static int level { get; set; } = 1;
        public static double xp {get; set; } = 0;
        public static int levelPoints { get; set; } = 0;

        public static double money { get; private set; } = 100;
        public static int maxActionPoints { get; private set; } = 5;
        public static int maxInventoryCapacity { get; private set; } = 5;
        public static double moneyMultiplier { get; private set; } = 1;
        public static double xpMultiplier { get; private set; } = 1;
        public static int endOfTheWorld {get; private set; } = 7;
        

        public static int currentXPosition { get; set; } = 1;
        public static int currentYPosition { get; set; } = 1;
        // Player constructor
        public Player(string name, int actionPoints, int money, int endOfTheWorld)
        {
            Player.name = name;
            Player.actionPoints = actionPoints;
            Player.money = money;
            Player.endOfTheWorld = endOfTheWorld;
        }

        //Set name 
        public static void  ChangeName(string newName) {
            name = newName;
        }
        //Checks if player can level up.
        public static void CheckXp(double xpGained){
            xp += xpGained;
            if(xp >= 100) {
                LevelUp();
                xp -= 100;
            }
        }
        //Next day
        public static void NextTurn(){
            if(turn >= endOfTheWorld) {
                Console.WriteLine("You lost!");
            }else {
                turn +=1;
                Console.WriteLine($"You slept like a baby, today is day: {turn}");
            }
        }
        //Used during action
        public static void MakeAction(){
            if(!(actionPoints == 0)){
                actionPoints -= 1;
            }else{
                Console.WriteLine("You run out of action points! You can restore them in base.");
            }
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
            
        }
        public static void AddMoney(double value)
        {
            money += value;
        }

        public static void PayWithMoney(int moneyValue)
        {
            if (money < moneyValue)
            {
                Console.WriteLine("You don't have enough money!");
            }
            else
            {
                Console.WriteLine("Payment succeeded");
                money -= moneyValue;
            }
        }
        //Upgrades action points
        public static void UpgradeActionPoints(int newMaxActionPoints){
            if(newMaxActionPoints > maxActionPoints){
                maxActionPoints = newMaxActionPoints;
            } else {
                Console.WriteLine("This is not a correct max action points value! ");
            }
            
        }
        //Upgrade Inventory capacity
        public static void UpgradeInventoryCapacity(int newInventoryCapacity){
           if(maxInventoryCapacity < newInventoryCapacity) {
            maxInventoryCapacity = newInventoryCapacity;
           }
           else{
            Console.WriteLine("This is not a correct max inventory value!");
           }
        }
        //Upgrades Money multiplier
        public static void UpgradeMoneyMultiplier(double newMoneyMultiplier) {
            if(moneyMultiplier < newMoneyMultiplier){
                moneyMultiplier = newMoneyMultiplier;
            }
            else{
                Console.WriteLine("This is not a correct money multiplier value!");
            }
        }
        //Upgrades Xp multiplier
        public static void UpgradeXpMultiplier(double newXpMultiplier) {
            if(xpMultiplier < newXpMultiplier){
                xpMultiplier = newXpMultiplier;
            }
            else{
                Console.WriteLine("This is not a correct Xp multiplier value!");
            }
        }
        //Saves Current Position
        public static void SaveCurrentPosition(int xPositon, int yPosition) {
            currentXPosition = xPositon;
            currentYPosition = yPosition;
        }

        //Calculate xp gained
        public static double CalculateXp(double xpGained){
            if(xpGained!=0){
                return xpMultiplier*xpGained;    
            }
            else {
                return 0;
            }
        }
        //Calculate money gained
        public static double CalculateMoney(double moneyGained) {
            if(moneyGained!=0){
                return moneyMultiplier*moneyGained;    
            }
            else {
                return 0;
            }
        }


        //Displays main stats
        public static void DisplayBasicStats(){
        Console.WriteLine($"> Day: {turn}");
        Console.WriteLine($"> Level: {level} ");
        Console.WriteLine($"> Action points left: {actionPoints} ");
        Console.WriteLine($"> Money: {money}");
        }   
        //Displays upgrade stats.
        public static void DisplayUpgradeStats(){
            Console.WriteLine($"> Your are curretly level: {level}");
            Console.WriteLine($"> Level points left: {levelPoints}");
            Console.WriteLine($"> Your curret max inventory: {maxInventoryCapacity}");
            Console.WriteLine($"> Your curret money multiplier {moneyMultiplier}");
            Console.WriteLine($"> Your curret xp multiplier {xpMultiplier}");
        }

    }
}