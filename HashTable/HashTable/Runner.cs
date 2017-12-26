using System;
using System.Collections.Generic;

namespace MyHashTable
{
    public class Runner
    {
        static void Main(string[] args)
        {
            //Random rng = new Random();
            //bool flag = true;
            //HashTable table = new HashTable();
            //while (flag)jgg
            //{
            //    KeyedItem item = new KeyedItem(rng.Next(0, 1000000000));
            //    flag = table.TableInsert(item);
            //}
            //table.ShowHashTable();
            //Console.ReadKey();
            HashTable<long> table = new HashTable<long>(79);
            table.Insert(200);
            table.Insert(300);
            table.Insert(1);
            table.Insert(2);
            Console.WriteLine("Enter a number");
            table.Insert(long.Parse(Console.ReadLine()));
            table.ShowHashTable();
            Console.WriteLine("HashTable contans 200?: " + table.ConntainsValue(200));
            Console.WriteLine("Count of elements: " + table.Count);
            Console.WriteLine("Enter a number to delete");
            long itemToDelete = long.Parse(Console.ReadLine());
            table.Remove(itemToDelete);
            Console.Write("Удаление элемента -> ");
            Console.WriteLine(itemToDelete);
            table.ShowHashTable();
            Console.ReadKey();
        }
    }
}
