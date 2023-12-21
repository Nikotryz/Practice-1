using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_1._1
{
    internal class Programs1
    {
        public static void Main()
        {
            //Задание 1
            Console.WriteLine("Task 1:");
            Random rnd = new Random();
            int[] randomNumbers1 = new int[10];
            int min = 100;
            int index_min=0;
            for (int i = 0; i < 10; i++)
            {    
                randomNumbers1[i] = rnd.Next(-100, 100);
                Console.Write($"{randomNumbers1[i]} ");    
                if (min > randomNumbers1[i])
                {       
                    min = randomNumbers1[i];
                    index_min = i;  
                }
            }
            Console.WriteLine($"\nMinimal element is: {min}");
            Console.WriteLine($"Index of min element: {index_min}");

            //Задание 2
            Console.WriteLine("\nTask 2:");
            List<int> randomNumbers2 = new List<int>();
            int mult = 1;
            double sum = 0;
            while (true)
            {
                int number = int.Parse(Console.ReadLine());
                if (number != 0)
                {
                    randomNumbers2.Add(number);
                    sum += number;
                    mult *= number;
                }
                else break;
            }
            Console.WriteLine($"Summ of all numbers: {sum}");
            Console.WriteLine($"Mult of all numbers: {mult}");
            Console.WriteLine($"Average of all Numbers: {sum/randomNumbers2.Count}");

            //Задание 3
            Console.WriteLine("\nTask 3:");
            List<string> words = new List<string>();
            while (true)
            {
                string word = Console.ReadLine();
                if (word == "") break;
                words.Add(word);
            }
            string minWord = words[0];
            string maxWord = words[0];
            foreach (string word in words)
            {
                if (maxWord.Length < word.Length) maxWord = word;
                if (minWord.Length > word.Length) minWord = word;
            }
            Console.WriteLine($"Min word: {minWord}");
            Console.WriteLine($"Max word: {maxWord}");

            //Задание 4
            Console.WriteLine("\nTask 4:");
            Console.Write("Enter the 1st border: ");
            int border1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the 2nd border: ");
            int border2 = int.Parse(Console.ReadLine());

            int[] borderMas = Border(border1, border2);
            foreach (int j in borderMas) Console.Write($"{j} ");
            
            //Задание 5
            Console.WriteLine("\n\nTask 5:");
            string text = Console.ReadLine();
            string[] wordMas = text.Split();
            List<string> wordList = wordMas.ToList();
            Console.WriteLine($"Count of words: {wordList.Count}");
            Console.WriteLine($"Edit text: {"Start " + text + " End"}");
        }
        public static int[] Border(int Border1, int Border2)
        {
            Random rnd = new Random();
            int[] borderMas = new int[10];
            for (int i=0; i < 10; i++)
            {
                borderMas[i] = (rnd.Next(Border1, Border2));
            }
            return borderMas;
        }
    }
}