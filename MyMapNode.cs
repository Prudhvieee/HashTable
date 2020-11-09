using System;
using System.Collections.Generic;
using System.Text;
namespace HashTable
{
    public class MyMapNode<K, V>
    {
        public readonly int size;
        public readonly LinkedList<keyValue<K, V>>[] items;
        /// <summary>
        /// Initializes a new instance of the <see cref="MyMapNode{K, V}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<keyValue<K, V>>[size];
        }
        /// <summary>
        /// get set methods 
        /// </summary>
        /// <typeparam name="k"></typeparam>
        /// <typeparam name="v"></typeparam>
        public struct keyValue<k, v>
        {
            public k key { get; set; }
            public v value { get; set; }
        }
        /// <summary>
        /// Gets the linkedlist.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        protected LinkedList<keyValue<K, V>> GetLinkedlist(int position)
        {
            LinkedList<keyValue<K, V>> linkedlist = items[position];

            if (linkedlist == null)
            {
                linkedlist = new LinkedList<keyValue<K, V>>();
                items[position] = linkedlist;
            }

            return linkedlist;
        }
        /// <summary>
        /// Gets the array position.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected int GetArrayPosition(K key)
        {
            //gethashcode gives position value using inbuilt function
            int position = key.GetHashCode() % size;
            //returning absolute position
            return Math.Abs(position);
        }
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public V Get(K key)
        {
            int position = GetArrayPosition(key);

            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);

            foreach (keyValue<K, V> item in linkedlist)
            {
                if (item.key.Equals(key))
                {
                    return item.value;
                }
            }
            return default;
        }
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);
            keyValue<K, V> item = new keyValue<K, V>() { key = key, value = value };

            linkedlist.AddLast(item);
        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);
            bool itemFound = false;
            keyValue<K, V> foundItem = default(keyValue<K, V>);
            foreach (keyValue<K, V> item in linkedlist)
            {
                if (item.key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedlist.Remove(foundItem);
            }
        }
        /// <summary>
        ///Gives the count the of word provided.
        /// </summary>
        public int GetFrequency(V value)
        {
            int frequency = 0;
            ///Iterating to get the key value of each item.
            foreach (LinkedList<keyValue<K, V>> list in items)
            {
                ///Checking if key is not null 
                if (list == null)
                    continue;
                ///Iterating to get the value of the item in linked list.
                foreach (keyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                        continue;
                    if (obj.value.Equals(value))
                        frequency++;
                }
            }
            return frequency;
        }
        /// <summary>
        /// Removes the given value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void RemoveValue(V value)
        {
            foreach (LinkedList<keyValue<K, V>> list in items)
            {
                if (list == null)
                    continue;
                foreach (keyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                        continue;
                    if (obj.value.Equals(value))
                    {
                        Remove(obj.key);
                        break;
                    }
                }
            }
        }
    }
}
