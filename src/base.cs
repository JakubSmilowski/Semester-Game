using System.Collections.Immutable;

namespace foodman
{
    class Base {

        public static int actionPointsUpgrades { get; set; } = 1;
        public static int inventoryUpgrades { get; set; } = 1;
        public static int moneyMultiplierUpgrades { get; set; } = 1;
        public static int xpMultiplierUpgrades { get; set; } = 1;

        public static double moneyMultiplierValue { get; set; } = 1;
        public static double xpMultiplierValue{ get; set; } = 1;

        public static int xShopPosition{ get; set; } = 6;
        public static int yShopPosition{ get; set; } = 6;

        public static int xBedPosition{ get; set; } = 6;
        public static int yBedPosition{ get; set; } = 1;

        public static int xQuestPosition{ get; set; } = 1;
        public static int yQuestPosition{ get; set; } = 6;



        //Main method
        public static void EnterBase()
        {
            Console.WriteLine("You entered the base!");
            Console.WriteLine("[Any Key] Exit");
            Console.ReadLine();

            //Room should look same as the other rooms except for placement of shop, bed?, quest progress.

            //So there shuld be a drawing method from room class.
            
        }

        //Rest method allows player to skip turn to gain extra action points.
        static void Rest(){
            Console.WriteLine("You are resting");  
            Console.WriteLine($"skiping to day {(Player.turn + 1)}");
            Player.NextTurn();
            Player.RestoreActionPoints();
        }

        //Upgrade shop logic.
        static void EnterUpgradeShop()
        {
                do
                {
                    Console.Clear();
                    Console.WriteLine("You entered upgrade shop.\n");
                    Console.WriteLine($"You currently have: {Player.levelPoints} points. \nWhat do you want to upgrade:\n");
                    Console.WriteLine($"> 1. Action Points - Currently tier {actionPointsUpgrades} costs {actionPointsUpgrades+1} level point");
                    Console.WriteLine($"> 2. Inventory Capacity - Currently tier {inventoryUpgrades } costs {inventoryUpgrades+1} level point");
                    Console.WriteLine($"> 3. Money Multiplier - Currently tier {moneyMultiplierUpgrades} costs {moneyMultiplierUpgrades+1} level point");
                    Console.WriteLine($"> 4. Xp Multiplier - Currently tier {xpMultiplierUpgrades} costs {xpMultiplierUpgrades+1} level point");
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
                                if(IsEnughLevelPoints(actionPointsUpgrades)){
                                    actionPointsUpgrades ++;
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
                                if(IsEnughLevelPoints(inventoryUpgrades)){
                                    inventoryUpgrades ++;
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
                                if(IsEnughLevelPoints(moneyMultiplierUpgrades)){
                                    moneyMultiplierUpgrades ++;
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
                                if(IsEnughLevelPoints(xpMultiplierUpgrades)){
                                    xpMultiplierUpgrades ++;
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
        static bool IsEnughLevelPoints(int statUpgradeLevel){
            if (Player.levelPoints >= (statUpgradeLevel+1)){
                return true;
            }
            else {
                return false;
            }
        }
        //Quest display 
        // static void ShowQuests(Quest[] questsInProgress)
        // {
        //     Console.Clear();
        //     Console.WriteLine("Quests in progress: ");
        //     foreach (Quest quest in questsInProgress){
        //     Console.writeline(quest.title);
        //     Console.writeline(quest.description);
        //     Console.writeline(quest.objective);
        //     Console.writeline("==============================");
        //     }
        //     Console.WriteLine("Completed quests:");
        //     foreach (Quest quest in questsCompleted){
        //     Console.writeline(quest.title);
        //     Console.writeline(quest.description);
        //     Console.writeline(quest.objective);
        //     Console.writeline("==============================");
        //     }
        //     Console.WriteLine("Press enter to continue: ");
        //     Console.ReadLine();
        // }
    }
}
        
