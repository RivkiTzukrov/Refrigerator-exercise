using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_exercise;

class Item
{
    public Guid id { get; set; }
    public string name { get; set; }
    public int shelfNum { get; set; }
    public string type { get; set; }
    public string kosher { get; set; }
    public DateTime expiryDate { get; set; }
    public int capacity { get; set; }

    public Item(string name, int shelfNum, string type, string kosher, DateTime expiryDate, int capacity)
    {
        id = Guid.NewGuid();
        this.name = name;
        this.expiryDate = expiryDate;
        this.capacity = capacity;
        this.shelfNum = shelfNum;
        this.type = type;
        this.kosher = kosher;
    }
    public Item()
    {
        id = Guid.NewGuid();
    }

    public void ToString()
    {
        Console.WriteLine($"Item code: {id} Name: " +
            $"{name} Shelf number: {shelfNum}\nType: {type} Kosher: {kosher}" +
            $"\nExpiry date: {expiryDate} Capacity: {capacity}");
    }
}
