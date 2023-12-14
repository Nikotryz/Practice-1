using System;
using System.Collections.Generic;

namespace Practice_1._1
{
    internal class Programs1
    {
        public static void Main()
        {
            //Задание 1
            Console.WriteLine("App_1:");
            Random rnd = new Random();
            int[] random_numbers_1 = new int[10];
            int min = 100;int index_min=0;
            for (int i = 0; i < 10; i++)
            {    random_numbers_1[i] = rnd.Next(-100, 100);
                Console.Write($"{random_numbers_1[i]} ");    
                if (min > random_numbers_1[i])
                {       
                    min = random_numbers_1[i];
                    index_min = i;  
                }
            }
            Console.WriteLine($"\nMinimal element is: {min}");
            Console.WriteLine($"Index of min element: {index_min}");

            //Задание 2
            Console.WriteLine("\nApp_2:");
            List<int> random_numbers_2 = new List<int>();
            int number;
            float summ = 0;
            int mult = 1;
            float count = 0;
            while (true)
            {
                number = int.Parse(Console.ReadLine());
                if (number != 0)    
                {
                    random_numbers_2.Add(number);
                    summ += number;
                    mult *= number;        
                    count += 1; 
                }    
                else 
                {        
                    break; 
                }
            }
            float middle = summ / count;
            Console.WriteLine($"Summ of all numbers: {summ}");
            Console.WriteLine($"Mult of all numbers: {mult}");
            Console.WriteLine($"Middle of all Numbers: {middle}");

            //Задание 3
            Console.WriteLine("\nApp_3:");
            List<string> words = new List<string>();
            string word;
            string min_word = " ";
            string max_word = " ";
            int first_counter = 0;
            while (true)
            {
                word = Console.ReadLine();    
                if (first_counter == 0)
                {        
                    min_word = word;
                    max_word = word;        
                    first_counter += 1; 
                }    
                if (word != "") 
                {        
                    words.Add(word);
                    if (min_word.Length > word.Length)        
                    {
                        min_word = word;        
                    }
                    if (max_word.Length < word.Length) 
                    {            
                        max_word = word; 
                    }    
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"Min word: {min_word}");
            Console.WriteLine($"Max word: {max_word}");

            //Задание 4
            Console.WriteLine("\nApp_4:");
            List<int> random_numbers_3 = new List<int>();
            int[] random_numbers_mas = new int[10];
            
            Console.Write("Enter the 1st border: ");
            int border_1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the 2nd border: ");
            int border_2 = int.Parse(Console.ReadLine());

            for (int i=0; i < 10; i++)
            {
                random_numbers_3.Add(rnd.Next(border_1, border_2));
                random_numbers_mas[i] = random_numbers_3[i];
            }
            foreach (int j in random_numbers_mas)
            {
                Console.Write($"{j} ");
            }
            
            //Задание 5
            Console.WriteLine("\n\nApp_5:");

            string text = Console.ReadLine();
            int count_words = 1;

            for (int i=0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    count_words += 1;
                }
            }
            text = "Start " + text + " End";
            Console.WriteLine($"Count of words: {count_words}");
            Console.WriteLine($"Edit text: {text}");
        }
    }
}