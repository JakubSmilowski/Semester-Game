//Here you declare all of the items used in the game
//for guidance, see Inventory.cs


namespace foodman
{
    public class Items
    {
        public static Item FoodExpired = new
        ("Expired food", "Something seems to have gone off, but it still has usage! Recycle it for some rewards.", 100);

        public static Item Snacks = new
        ("Snacks", "The tasty treats you bought at the store", 10);

        public static Item FoodDeformed = new
        ("Food from the factory", "Edible food from the factory. Apart from the visual deformation, it's perfectly safe to eat!", 20);


        public static List<Item> itemList = new List<Item>()
        {
            FoodExpired,
            Snacks,
            FoodDeformed
        };

        public static bool isInventoryEmpty()
        {
            foreach(var item in itemList)
            {
                if(item.Quantity != 0)
                {
                    return false;
                }
            }
            return true;
        }
        
        public static void OpenInventory()
        {
            foreach(var item in itemList)
            {
                if(item.Quantity != 0)
                {
                    System.Console.WriteLine($"{item.ItemName} x{item.Quantity}");
                }
            }
            
            if(isInventoryEmpty()) System.Console.WriteLine("Inventory is empty!");
        }

        public static void JunkyardSellMenu()
        {
            if(!isInventoryEmpty())
            {
                int optionNumber;
                int pickedNumber;
                bool isNumberCorrect;
                int amountToSell;
                bool isSellAmountCorrect = false;

                do
                {
                    optionNumber = 1;
                    Console.Clear();
                    Console.WriteLine("Choose an item you want to sell (enter the number):\n");
                    foreach(var item in itemList)
                    {
                        if(item.Quantity != 0)
                        {
                            System.Console.WriteLine($"[{optionNumber}] {item.ItemName} - {item.Quantity} available");
                            optionNumber++;
                        }
                    }
                    Console.WriteLine($"\n[{optionNumber}] Exit");
                    Console.Write("\n> ");
                    
                    isNumberCorrect = int.TryParse(Console.ReadLine(), out pickedNumber) && pickedNumber > 0 && pickedNumber <= optionNumber;
                    
                    if(isNumberCorrect && pickedNumber != optionNumber)
                    {
                        int count = 0;
                        foreach(var item in itemList)
                        {
                            count++;
                            if(pickedNumber == count)
                            {
                                Console.WriteLine("How many would you like to sell?");
                                Console.Write("\n> ");
                                isSellAmountCorrect = int.TryParse(Console.ReadLine(), out amountToSell) && amountToSell > 0 && amountToSell <= item.Quantity;

                                if(isSellAmountCorrect)
                                {
                                    item.Remove(amountToSell);
                                    Player.AddMoney(4 * amountToSell);
                                    Console.WriteLine($"\n{amountToSell}x {item.ItemName} succesfully sold for {4 * amountToSell}$!");
                                }
                            }
                        }
                    }

                    if(pickedNumber == optionNumber)
                    {
                        Location.EnterRoom("junkyard", 4);
                        break;
                    }
                    
                    if(!isNumberCorrect) 
                    {
                        Console.WriteLine("Incorrect number picked. Press [any key] to try again...");
                        Console.ReadKey();
                    }
                    else if(!isSellAmountCorrect) 
                    {
                        System.Console.WriteLine("Incorrect amount. Press [any key] to try again...");
                        Console.ReadKey();
                    }

                }
                while(!isNumberCorrect || !isSellAmountCorrect);
            }
        }
    }
}
