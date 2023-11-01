        
        
        static void EnterBase(ref int maxHealth, ref int maxActionPoints, ref int maxInventoryCapacity, ref int levelPoints, int healt = 0, int level = 0, int actionPoints = 3, int turn = 1)
        {
            //Main loop
            do
            {
                Console.Clear();

                // Greeting message
                Console.WriteLine("You are entering the base: ");

                //Displaying stats: 
                DisplayStats();

                // Visual representation of the base 
                Console.Write("\n=====================");

                //Value i indicates how how hight the border of the base is.
                for (int i = 0; i < 6; i++)
                {
                    if (i == 0)
                    {
                        Console.Write("\n|{S}\t         {U}|");
                    }
                    else if (i == 5)
                    {
                        Console.Write("\n|{Q}\t         {P}|");
                        break;
                    }
                    Console.Write("\n|\t\t    |");
                }
                Console.Write("\n=====================\n");

                //Possible options
                Console.WriteLine("\n> U - Upgrade");
                Console.WriteLine("> S - Shop");
                Console.WriteLine("> Q - Quests");
                Console.WriteLine("> P - Progress");
                Console.WriteLine("> E - Exit");
                Console.Write("> ");

                //User input
                string? userInput = Console.ReadLine();

                //Choice of the player logic.
                if (userInput != null)
                {
                    switch (userInput.ToLower())
                    {
                        case "u":
                            EnterUpgradeShop(ref maxHealth, ref maxActionPoints, ref maxInventoryCapacity, ref levelPoints);
                            break;
                        case "s":
                            EnterShop();
                            break;
                        case "q":
                            EnterQuests();
                            break;
                        case "p":
                            EnterProgress();
                            break;
                        case "e":
                            Console.Clear();
                            Console.WriteLine("You left the base");
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

        //Stats function. Takes in current stats of the player
        static void DisplayStats(int health = 0, int level = 0, int money = 0, int actionPoints = 3, int turn = 1)
        {
            Console.WriteLine($"\n> Day: {turn}");
            Console.WriteLine($"> Level: {level}\t   \n> Health: {health}");
            Console.WriteLine($"> Action points: {actionPoints} ");
        }

        //Upgrade shop logic
        static void EnterUpgradeShop(ref int maxHealth, ref int maxActionPoints, ref int maxInventoryCapacity, ref int levelPoints, int turn = 1)
        {

            if (levelPoints == 0)
            {
                Console.WriteLine("You dont have enought level points to upgrade!");
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }
            else
            {


                do
                {
                    //In the futuer cost will change depending on the tier.
                    Console.Clear();
                    Console.WriteLine("You entered upgrade shop.\n");
                    Console.WriteLine($"You currently have: {levelPoints} points. \nWhat do you want to upgrade:\n");
                    Console.WriteLine($"> 1. Helth - Currently tier {TierCheck(maxHealth, 1)} cost 1 level point");
                    Console.WriteLine($"> 2. Action Points - Currently tier {TierCheck(maxActionPoints, 2)}");
                    Console.WriteLine($"> 3. Inventory Capacity - Currently tier {TierCheck(maxInventoryCapacity, 3)}");
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
                                Console.WriteLine("You upgraded the health stat!");
                                maxHealth += 1;
                                Console.WriteLine("Press enter to continue: ");
                                Console.ReadLine();
                                break;
                            case "2":
                                Console.WriteLine("You upgraded the action points stat!");
                                maxActionPoints += 1;
                                Console.WriteLine("Press enter to continue: ");
                                Console.ReadLine();
                                break;
                            case "3":
                                maxInventoryCapacity += 1;
                                Console.WriteLine("You upgraded the inventory!");
                                Console.WriteLine("Press enter to continue: ");
                                Console.ReadLine();
                                break;
                            case "y":
                                break;
                            case "e":
                                Console.Clear();
                                Console.WriteLine("You left the upgrade shop");
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
        }
        //Shop logic
        static void EnterShop(int money = 0)
        {
            Console.Clear();
            Console.WriteLine("You entered the shop");
            Console.WriteLine($"Money: {money}");
            Console.WriteLine("Press enter to continue: ");
            Console.ReadLine();

        }
        //Quest display 
        static void EnterQuests()
        {
            Console.Clear();
            Console.WriteLine("Completed puzzles, quizes.");
            Console.WriteLine("Press enter to continue: ");
            Console.ReadLine();
        }

        //Progress display
        static void EnterProgress()
        {
            Console.Clear();
            Console.WriteLine("Progres of the game:");
            Console.WriteLine("Press enter to continue: ");
            Console.ReadLine();

        }

        //Check tier of the stat
        static string TierCheck(int statInCheck, int type)
        {
            string tier = "I";
            int cost = 1;

            if (type == 1)
            {
                switch (statInCheck)
                {
                    case 6:
                        tier = "II";
                        break;
                    case 7:
                        tier = "III";
                        break;
                    case 8:
                        tier = "IV";
                        break;
                    case 9:
                        tier = "V";
                        break;
                    case 10:
                        tier = "VI";
                        break;
                    default:
                        tier = "I";
                        break;
                }
            }
            else if (type == 2)
            {
                switch (statInCheck)
                {
                    case 4:
                        tier = "II";
                        break;
                    case 5:
                        tier = "III";
                        break;
                    case 6:
                        tier = "IV";
                        break;
                    case 7:
                        tier = "V";
                        break;
                    case 8:
                        tier = "VI";
                        break;
                    default:
                        tier = "I";
                        break;
                }
            }
            else if (type == 3)
            {
                switch (statInCheck)
                {
                    case 3:
                        tier = "II";
                        break;
                    case 4:
                        tier = "III";
                        break;
                    case 5:
                        tier = "IV";
                        break;
                    case 6:
                        tier = "V";
                        break;
                    case 7:
                        tier = "VI";
                        break;
                    default:
                        tier = "I";
                        break;
                }
            }

            return tier;
        }

