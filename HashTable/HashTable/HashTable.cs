using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashTable
{
    public class HashTable<T>
    {
        private Dictionary<int, List<T>> table;

        public int HashIndexValue { get; protected set; }

        public HashTable(int hashValue)
        {
            HashIndexValue = hashValue;
            table = new Dictionary<int, List<T>>();
        }

        public bool Insert(T value)
        {
            int hash = HashIndex(value.GetHashCode());
            if (!table.ContainsKey(hash)) table[hash] = new List<T>();
            table[hash].Add(value);
            return true;
        }

        public void ShowHashTable()
        {
            foreach (var key in table)
            {
                Console.Write("Номер элемента массива: " );
                Console.Write(key.Key);
                foreach (var value in key.Value)
                {
                    Console.Write(" -> ");
                    Console.Write(value);
                }
                Console.WriteLine();
            }
        }

        //удаление элемента
        public int Remove(T value)
        {
            int hash = HashIndex(value.GetHashCode());

            if (!table.ContainsKey(hash) || !table[hash].Contains(value))
            {
                Console.WriteLine("Error, no such Item");
                return 0;
            }
            return table[hash].RemoveAll((val) => value.Equals(val));

        }

        public IEnumerable<T> Get(int hash)
        {
            if (table.ContainsKey(hash)) return null;
            return table[hash].ToList();
        } 

        //возвращает номер в массиве, где хранить данные
        private int HashIndex(long searchKey)
        {
            return (int)(searchKey % HashIndexValue);
        }

        public bool ConntainsValue(T value)
        {
            int hash = HashIndex(value.GetHashCode());

            if (!table.ContainsKey(hash)) return false;
            return table[hash].Contains(value);
        }

        public int Count
        {
            get { return table.Values.Select(list => list.Count).Sum(); }
        }
    }
}
