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

        public bool TryRemove(int removedQuantity)
        {
            if(removedQuantity > 0 && Quantity - removedQuantity >= 0)
            {
                Quantity -= removedQuantity;
                return true;
            }
            else if(Quantity - removedQuantity < 0)
            {
                System.Console.WriteLine($"Cannot perform action. You currently have {Quantity}x {ItemName}");
                return false;
            }
            else return false;
        }

        public void GetInfo()
        {
            System.Console.WriteLine($"Item name: {ItemName}");
            System.Console.WriteLine($"{Description}");
            System.Console.WriteLine($"Number owned: {Quantity}");
        }
    }