// See https://aka.ms/new-console-template for more information
using Refrigerator_exercise;
using System.Diagnostics;


static List<Refrigerator> SortedRef(List<Refrigerator> refrigerators)
{
    return refrigerators.OrderBy(x => x.SpaceLeft()).ToList();
}

Console.WriteLine("Hello, World!");
List<Refrigerator> refrigerators = new List<Refrigerator>();
refrigerators.Add(new("Sharp", "black", 3));
refrigerators[0].shelves.Add(new(1, 250));
refrigerators[0].shelves.Add(new(2, 300));
refrigerators[0].shelves.Add(new(3, 150));

Item item1 = new("milk", 1, "drink", "milky", DateTime.Now.AddDays(2), 50);
Item item2 = new("eggs", 2, "food", "parve", DateTime.Now, 90);
Item item3 = new("yogurt", 1, "food", "milky", DateTime.Now.AddDays(10), 80);
Item item4 = new("chicken", 1, "food", "fleshy", DateTime.Now.AddDays(1), 70);
Item item5 = new("schnitzel", 3, "food", "fleshy", DateTime.Now.AddDays(3), 100);
Item item6 = new("fruits", 2, "food", "parve", DateTime.Now.AddDays(-2), 45);

refrigerators[0].InsertItem(item1);
refrigerators[0].InsertItem(item2);
refrigerators[0].InsertItem(item3);
refrigerators[0].InsertItem(item4);
refrigerators[0].InsertItem(item5);
refrigerators[0].InsertItem(item6);

int choice = 0;

do
{
    Console.WriteLine("Press 1: to print all the items on the refrigerator and all its contents.\n"
    + "Press 2: to print how much space is left in the fridge\n"
    + "Press 3: to allow the user to put an item in the refrigerator.\n"
    + "Press 4: to allow the user to remove an item from the refrigerator.\n"
    + "Press 5: to clean the refrigerator and print all the checked items to the user.\n"
    + "Press 6: to ask the user & quot; What do I want to eat ? &quot; and bring the function to bring a product.\n"
    + "Press 7: to print all the products sorted by their expiration date.\n"
    + "Press 8: to print all the shelves arranged according to the free space left on them.\n"
    + "Press 9: to print all the refrigerators arranged according to the free space left in them.\n"
    + "Press 10: to prepare the refrigerator for shopping\n"
    + "Press 100: system shutdown.\n        -------------------\n");

    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            refrigerators[0].ToString();
            break;
        case 2:
            Console.WriteLine($"Space left: {refrigerators[0].SpaceLeft()} cc.");
            break;
        case 3:
            Item newItem = new();
            DateTime expiryDate;
            Console.WriteLine("enter item name");
            newItem.name = Console.ReadLine();
            Console.WriteLine("enter item type");
            newItem.type = Console.ReadLine();
            Console.WriteLine("enter item kosher");
            newItem.kosher = Console.ReadLine();
            Console.WriteLine("enter item expiry date");
            DateTime.TryParse(Console.ReadLine(), out expiryDate);
            newItem.expiryDate = expiryDate;
            Console.WriteLine("enter shelf number");
            newItem.shelfNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter capacity");
            newItem.capacity = Convert.ToInt32(Console.ReadLine());
            if (refrigerators[0].InsertItem(newItem))
            {
                Console.WriteLine("The item has been placed in the refrigerator successfully!");
            }
            else Console.WriteLine("ERROR!");
            break;
        case 4:
            string itemId;
            Console.WriteLine("enter item id");
            itemId = Console.ReadLine();
            Item removedItem =  refrigerators[0].RemoveItem(Guid.Parse(itemId));
            if (removedItem != null)
            {
                Console.WriteLine($"the Item:");
                removedItem.ToString();
                Console.WriteLine("was removed successfully");
            }
            break;
        case 5:
            refrigerators[0].SortItemsByDate().ForEach(i => i.ToString());
            refrigerators[0].CleanRef();
            Console.WriteLine("refrigerator was cleaned successfully!");
            break;
        case 6:
            string type, kosher;
            Console.WriteLine("what do you want to eat?\nenter type and kosher to get options");
            type = Console.ReadLine();
            kosher = Console.ReadLine();
            refrigerators[0].FoodOptions(kosher, type).ForEach(i => i.ToString());
            break;
        case 7:
            refrigerators[0].SortItemsByDate().ForEach(i => i.ToString());
            break;
        case 8:
            refrigerators[0].SortShelvesBySpace().ForEach(i => i.ToString());
            break;
        case 9:
            SortedRef(refrigerators).ForEach(r => r.ToString());
            break;
        case 10:
            if (refrigerators[0].ReadyToShop())
            {
                Console.WriteLine("The refrigerator is ready for shopping!");
            }
            break;
        case 100:
            return;
        default:
            break;
    }

} while (choice != 100);
