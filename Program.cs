using System;

namespace HashTable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hash Table implementation");
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To");
            hash.Add("1", "be");
            hash.Add("2", "or");
            hash.Add("3", "not");
            hash.Add("4", "To");
            hash.Add("5", "be");
            string hash5 = hash.Get("4");
            Console.WriteLine("5th index value:" + hash5);
            string paragraph = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            ///Split converts paragraph  into array of sub strings.
            string[] para = paragraph.Split(" ");
            ///Creating reference of MyMapNode.
            MyMapNode<int, string> hash1 = new MyMapNode<int, string>(para.Length);
            int key = 0;
            ///foreach iterates on paragraph and adds key and value to hash.
            foreach (string word in para)
            {
                hash1.Add(key, word);
                key++;
            }
            Console.WriteLine("\nFrequency :" + hash1.GetFrequency("paranoid"));
        }
    }
}

