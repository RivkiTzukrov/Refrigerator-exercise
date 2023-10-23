using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_exercise;

class Shelf
{
    public Guid id { get; set; }
    public int floorNum { get; set; }
    public int capacity { get; set; }
    public List<Item> items { get; set; }

    public Shelf(int floorNum, int capacity)
    {
        id = Guid.NewGuid();
        this.floorNum = floorNum;
        this.capacity = capacity;
        items = new List<Item>();
    }

    public void ToString()
    {
        Console.WriteLine($"Shelf code: {id}\nfloor number: {floorNum}\ncapacity: {capacity}\n items:");
        foreach (Item item in items)
        {
            item.ToString();
        }
    }

    public int SpaceLeft()
    {
        int space = capacity;
        foreach (Item item in items)
        {
            space -= item.capacity;
        }
        return space;
    }

}
