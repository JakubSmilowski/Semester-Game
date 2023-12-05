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


        private static List<Item>? itemList = new List<Item>()
        {
            FoodExpired,
            Snacks
        };
        public static void OpenInventory()
        {
            bool isInventoryEmpty = true;

            foreach(var item in itemList)
            {
                if(item.Quantity != 0)
                {
                    isInventoryEmpty = false;
                    System.Console.WriteLine($"{item.ItemName} x{item.Quantity}");
                }
            }
            
            if(isInventoryEmpty) System.Console.WriteLine("Inventory is empty!");
        }
    }
}
