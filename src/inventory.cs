namespace WorldOfZuul
{    
    public struct Item
    {
        public int Quantity=0;
        public string ItemName;
        public string Description="";
        public int MaxCapacity=0;


        public Item(string itemName, string description, int maxCapacity)
        {
            ItemName = itemName;
            Description = description;
            MaxCapacity = maxCapacity;
        }

        public void Add(int addedQuantity)
        {
            if(addedQuantity > 0 && Quantity + addedQuantity <= MaxCapacity)
            {
                Quantity += addedQuantity;
            }
            else if(Quantity + addedQuantity > MaxCapacity)
            {
                Quantity = MaxCapacity;
                System.Console.WriteLine($"{ItemName} limit ({MaxCapacity}) reached.");
            }
        }

        public void Remove(int removedQuantity)
        {
            if(removedQuantity > 0 && Quantity - removedQuantity >= 0)
            {
                Quantity -= removedQuantity;
            }
            else
            {
                System.Console.WriteLine(Quantity = 0);
            }
        }

        public bool UseItem(int quantityNeeded)
        {
            if(quantityNeeded<=Quantity)
            {
                //*placeholder for an action from using an item*
                Remove(quantityNeeded);
                return true;
            }
            else
            {
                System.Console.WriteLine($"Cannot perform action. Not enough {ItemName}");
                return false;
            }
        }

        public void GetInfo()
        {
            System.Console.WriteLine($"Item name:\t{ItemName}");
            System.Console.WriteLine($"Description:\t{Description}");
            System.Console.WriteLine($"Number owned:\t{Quantity}");
        }
    }
}