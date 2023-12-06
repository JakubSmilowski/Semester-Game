//###GUIDE###

//Declare a new item:
//Item <name> = new(<displayed name>, <item description>, <max amount in inventory>);

//Get info:
//<name>.Display();
//displays all of the information about an item
//can be used as a showcase or to test if everything was declared correctly

//Add items:
//<name>.Add(<amount>) 
//if added more than player can carry, adds as much as it can, the rest is discarded

//Add items randomly:
//<name>.AddRandomAmount(<minimum>, <maximum>);
//adjustable random drop of an item, adds as much as required to the maximum

//Remove items:
//<name>.Remove(<amount>);
//if removed more than there was, count goes to 0

//Using an item:
//<name>.TryUse(<amount needed to use>)
//a bool that checks if an action can be performed (i. e. if you have enough of an item to do so)

namespace foodman
{    
    public class Item
    {
        public int Quantity = 0;
        public string ItemName;
        public string Description = "";
        public int MaxCapacity = 0;


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
            System.Console.WriteLine($"*{addedQuantity} of {ItemName} has been added to your inventory.");
        }

        public void AddRandomAmount(int randMin, int randMax)
        {
            if(Quantity!=MaxCapacity)
            {
                Random random = new();
                int addedQuantity = random.Next(randMin, randMax);
                Add(addedQuantity);
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
                Quantity = 0;
            }
        }

        public bool TryUse(int quantityNeeded)
        {
            if(quantityNeeded<=Quantity)
            {
                Remove(quantityNeeded);
                return true;
            }
            else
            {
                System.Console.WriteLine($"Cannot perform action. Not enough {ItemName}");
                return false;
            }
        }

        public void Display()
        {
            System.Console.WriteLine($"Item name:\t{ItemName}");
            System.Console.WriteLine($"Description:\t{Description}");
            System.Console.WriteLine($"Number owned:\t{Quantity}");
        }
    }
}
