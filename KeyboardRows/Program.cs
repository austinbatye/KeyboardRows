using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardRows
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("This program will test several words to determine if they can" +
                              " be typed using only one row on the keyboard.\n" +
                              "When entering words, please do not use any syntax as this" +
                              " program is checking only letters.");

            while (true)
            {
                Console.WriteLine("Please type all words to check separated by a space (' ').");

                //Input string is split and put into an array so that each word is its own index.
                string[] words = Console.ReadLine().Split(' ');

                //Checks each word in the FindWords method and displays only valid words
                Console.WriteLine("Below are the words that you can type using only one row of the keyboard:");
                Console.Write("[ ");
                foreach (var word in FindWords(words))
                {
                    Console.Write($"{word} ");
                }

                Console.Write("]");

                Console.WriteLine();
            }
        }

        public static string[] FindWords(string[] words)
        {
            List<string> goodWords = new List<string>();        //Creates list to store valid words

            for (int i = 0; i < words.Length; i++)
            {
                if (TestWord(words[i].ToLower()))       //TestWord method called on each word
                {                                       //If TestWord returns true, adds word to 
                    goodWords.Add(words[i]);            //goodWords list
                }
            }
            return goodWords.ToArray();                 //goodWords turned to array and returned
        }

        public static bool TestWord(string word)
        {
            //Each keyboard row created as a HashSet
            HashSet<char> firstRow = new HashSet<char> { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            HashSet<char> secondRow = new HashSet<char> { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            HashSet<char> thirdRow = new HashSet<char> { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };

            //word is created as a HashSet, elminiating duplicate letters
            var letterSet = new HashSet<char>(word.ToCharArray());


            //Each HashSet row is tested against the letterSet as true or false
            if (letterSet.IsSubsetOf(firstRow)) return true;
            else if (letterSet.IsSubsetOf(secondRow)) return true;
            else if (letterSet.IsSubsetOf(thirdRow)) return true;
            return false;
        }
    }
}
