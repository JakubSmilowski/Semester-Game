namespace Location
{
    class Location
    {
        static int[] progress = {0, 0, 0, 0, 0, 0};
        //progress is a primary quest stat. It does +1 to a specific part after you accept a quest.

        static void Main(string[] args)
        {
            //DEBUG PURPOSES
            EnterRoom("Grocery Store", 0);
        }

        public static void EnterRoom(string locName, int id)
        {
            Console.WriteLine("You are inside a " + locName);
            Console.WriteLine($"You have {2 - progress[id]} available quests");
            Console.WriteLine("[A] Accept quest [S] Leave the " + locName);
            string answer = Console.ReadLine();
            if (answer == "A")
            {
                LookAround(locName, id);
            } else if (answer == "B")
            {
                //OpenMap(CURRENT LOCATION)
            }
            else
            {
                Console.WriteLine("Something went wrong... Please try again");
                EnterRoom(locName, id);
            }
        }
        static void LookAround(string locName, int id)
        {
            /*  0 - Grocery Store
             *  1 - Restaraunt
             *  2 - House
             *  3 - Factory
             *  4 - Junkyard
             *  5 - Recycling centre
             */
            //if the quest of the area is available
            switch (id)
            {
                case 0:
                    if (progress[id] == 0)
                    {
                        Console.WriteLine("You can smell expired food. Strange... Maybe you can ask someone about it?");
                        Console.WriteLine("[A] Ask the owner [B] Ignore the smell");
                        string read = Console.ReadLine();
                        if (read == "A")
                        {
                            Console.WriteLine("Manager: 'The food is expired and ready to be thrown out. Yes, we will throw it to the trash. We don't recycle.'");
                            Console.WriteLine("You: 'Recycling is actually very easy! Here, let me show you, so you will start doing so too!'");
                            progress[0] += 1;
                            //DON'T FORGET TO ADD NASTY FOOD TO INVENTORY
                        } else if (read == "B")
                        {
                            Console.WriteLine("You ignore the smell and decide to leave this disgusting place after getting yourself a few snacks");
                            //DON'T FORGET TO ADD SNACKS TO INVENTORY AND TO REMOVE THE MONEY
                        }
                    }
                    else if (progress[id] == 1)
                    {
                        Console.WriteLine("It is dark outside. The store will close soon. You take a look at the shelves. Some of them still have food. It is almost expired, so the store will throw it out. Do you want to take care of it?");
                        Console.WriteLine("[A] Take the leftovers [B] Leave them there");
                        string read = Console.ReadLine();
                        if (read == "A")
                        {
                            Console.WriteLine("You take the food. Now you can either eat it or sell it for 1/4 of its original price");
                            progress[0] += 1;
                            //DON'T FORGET TO ADD WORSE FOOD TO INVENTORY
                        }
                        else if (read == "B")
                        {
                            Console.WriteLine("You ignore the food. It is best to throw things that have no use, right?");
                        }
                    } else
                    {
                        Console.WriteLine("There is nothing left for you to do here...");
                        Console.WriteLine("[E] Exit");
                        //OpenMap(STORE LOCATION);
                    }
                break;
                    //other locations will have the same thing. Such individuality allows us to make every quest unique
            }
        }

    }
}
