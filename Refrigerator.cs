using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_exercise;

class Refrigerator
{
    public Guid id { get; set; }
    public string model { get; set; }
    public string color { get; set; }
    public int numOfShelves { get; set; }
    public List<Shelf> shelves { get; set; }

    public Refrigerator(string model, string color, int numOfShelves)
    {
        id = Guid.NewGuid();
        this.model = model;
        this.color = color;
        this.numOfShelves = numOfShelves;
        shelves = new List<Shelf>(numOfShelves);
    }

    public void ToString()
    {
        Console.WriteLine($"Refrigerator code: {id} Model: " +
            $"{model} color: {color} Number of shelves: {numOfShelves}");
        for (int i = 0; i < numOfShelves; i++)
        {
            Console.WriteLine($"\nShelf {i + 1}:");
            shelves[i].ToString();
        }
    }

    public int SpaceLeft()
    {
        int space = 0;
        foreach (var shelf in shelves)
        {
            space += shelf.SpaceLeft();
        }
        return space;
    }

    public bool InsertItem(Item item)
    {

        if (shelves[item.shelfNum - 1].SpaceLeft() >= item.capacity)
        {
            shelves[item.shelfNum - 1].items.Add(item);
            return true;
        }
        return false;
    }

    public Item RemoveItem(Guid itemId)
    {
        foreach (Shelf shelf in shelves)
        {
            foreach (Item item in shelf.items)
            {
                if (item.id == itemId)
                {
                    Item removedItem = item;
                    shelf.items.Remove(item);
                    return removedItem;
                }
            }
        }
        return null;
    }

    public void CleanRef()
    {
        foreach (Shelf shelf in shelves)
        {
            shelf.items.RemoveAll(i => i.expiryDate < DateTime.Today);
        }
    }

    public List<Item> FoodOptions(string kosher, string type)
    {
        List<Item> items = new List<Item>();
        foreach (Shelf shelf in shelves)
        {
            //items = shelf.items.FindAll(item => item.expiryDate > DateTime.Today && item.kosher == kosher && item.type == type).ToList();
            //new List<int>(firstlist.FindAll(isEven))
            foreach (Item item in shelf.items)
            {
                if (item.expiryDate > DateTime.Today && item.kosher == kosher && item.type == type)
                {
                    items.Add(item);
                }
            }
        }
        if (items.Count == 0)
        {
            Console.WriteLine("no options found:(");
        }
        return items;
    }

    public List<Item> SortItemsByDate()
    {
        List<Item> sortedItems = new List<Item>();
        foreach (Shelf shelf in shelves)
        {
            sortedItems.AddRange(shelf.items);
        }
        return sortedItems.OrderBy(x => x.expiryDate).ToList();
    }

    public List<Shelf> SortShelvesBySpace()
    {
        return shelves.OrderBy(s => s.SpaceLeft()).ToList();
    }

    public bool ReadyToShop()
    {
        if (SpaceLeft() > 19)
        {
            return true;
        }
        else CleanRef();
        if (SpaceLeft() > 19)
        {
            return true;
        }
        else
        {
            int space = SpaceLeft();
            foreach (Shelf shelf in shelves)
            {
                foreach (Item item in shelf.items)
                {
                    if (item.type == "milky" && (item.expiryDate - DateTime.Now).TotalDays < 3)
                    {
                        space += item.capacity;
                    }
                    else if (item.type == "fleshy" && (item.expiryDate - DateTime.Now).TotalDays < 7)
                    {
                        shelf.items.Remove(item);
                    }
                    else if (item.type == "parve" && (item.expiryDate - DateTime.Now).TotalDays < 1)
                    {
                        shelf.items.Remove(item);
                    }
                }
            }
            if (space < 20)
            {
                Console.WriteLine("This is not the right time to shop.");
                return false;
            }
        }
        foreach (Shelf shelf in shelves)
        {
            foreach (Item item in shelf.items)
            {
                if (item.type == "milky" && (item.expiryDate - DateTime.Now).TotalDays < 3)
                {
                    shelf.items.Remove(item);
                }
            }
        }
        if (SpaceLeft() > 19)
        {
            return true;
        }
        else foreach (Shelf shelf in shelves)
            {
                foreach (Item item in shelf.items)
                {
                    if (item.type == "fleshy" && (item.expiryDate - DateTime.Now).TotalDays < 7)
                    {
                        shelf.items.Remove(item);
                    }
                }
            }
        if (SpaceLeft() > 19)
        {
            return true;
        }
        else foreach (Shelf shelf in shelves)
            {
                foreach (Item item in shelf.items)
                {
                    if (item.type == "parve" && (item.expiryDate - DateTime.Now).TotalDays < 1)
                    {
                        shelf.items.Remove(item);
                    }
                }
            }
        return true;
    }
}




