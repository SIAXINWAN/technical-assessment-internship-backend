﻿class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        IItemManager manager = new ItemManager();

        // Part One: Fix the NullReferenceException
        // This will throw a NullReferenceException
        manager.AddItem("Apple");
        manager.AddItem("Banana");

        manager.PrintAllItems();

        // Part Two: Implement the RemoveItem method
        manager.RemoveItem("Apple");
        Console.Write("\nList after removed: ");
        manager.PrintAllItems();

        // Part Three: Introduce a Fruit class and use the ItemManager<Fruit> to add a few fruits and print them on the console.
        // TODO: Implement this part three.
        ItemManager<Fruit> fruitManager = new ItemManager<Fruit>();
        fruitManager.AddItem(new Fruit("Mango"));
        fruitManager.AddItem(new Fruit("Pineapple"));
        fruitManager.AddItem(new Fruit("Watermelon"));
        fruitManager.PrintAllItems();

        // Part Four (Bonus): Implement an interface IItemManager and make ItemManager implement it.
        // TODO: Implement this part four.
    }
}

public class ItemManager : IItemManager
{
    private List<string> items;

    public ItemManager()
    {
        items = new List<string>();// Part One: Fix the NullReferenceException
    }

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    // Part Two: Implement the RemoveItem method
    // TODO: Implement this method
    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"Removed: {item}");
        }
        else
        {
            Console.WriteLine($"Item {item} not found." );
        }
    }

    public void ClearAllItems()
    {
        items = [];
    }
}

public class ItemManager<T>
{
    private List<T> items;

    public ItemManager()
    {
        items = new List<T>();
    }

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        Console.WriteLine("\nAll new add items: ");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearAllItems()
    {
        items = [];
    }
}

//Part Three
public class Fruit
{
    public string Name { get; set; }

    public Fruit(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}

//Part Four
public interface IItemManager
{
    void AddItem(string item);
    void PrintAllItems();
    void RemoveItem(string item);
    void ClearAllItems();
}