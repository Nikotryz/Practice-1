using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;

namespace Practice_1._6
{
    internal class Programs6
    {
        public static void Main()
        {
            //Задание 1
            Console.WriteLine("Task 1:");
            string pathNumsTask1 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.6/numsTask1.txt";
            using (StreamReader readerTask1 = new StreamReader(pathNumsTask1))
            {
                string[] words = readerTask1.ReadToEnd().Split();
                foreach (string word in words) if (word.Length % 2 != 0) Console.Write($"{word} ");
            }
            
            //Задание 2
            Console.WriteLine("\n\nTask 2:");
            string pathNumsTask2 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.6/numsTask2.txt";
            using (StreamReader readerTask2 = new StreamReader(pathNumsTask2))
            {
                string[] words = readerTask2.ReadToEnd().Split();
                foreach (string word in words) Console.Write($"{word} ");
            }
            
            //Задание 3
            Console.Write("\n\nTask 3:\nInput number: ");
            int number = int.Parse(Console.ReadLine());
            if (number % 10 == 0) Console.WriteLine("True");
            else Console.WriteLine("False");
            
            //Задание 4
            Console.Write("\nTask 4:\nInput a: ");
            int a = int.Parse(Console.ReadLine());
            int sum = 0;
            while (true)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 0) break;
                if (num % a == 0) sum += num;
            }
            Console.WriteLine($"Sum: {sum}");
            
            //Задание 5
            Console.Write("\nTask 5:\nInput N: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Input M: ");
            int M = int.Parse(Console.ReadLine());
            int[,] numbers = new int[N, M];
            int[,] numbers_edit = new int[N, M+1];
            Random rnd = new Random();
            Console.WriteLine("Original array:");
            for (int i = 0; i < N; i++)
            {
                int count = 0;
                for (int j = 0; j < M; j++)
                {
                    numbers[i, j] = rnd.Next(0, 2);
                    numbers_edit[i, j] = numbers[i, j];
                    if (numbers[i, j] == 1) count += 1;
                    Console.Write($"{numbers[i,j]} ");
                }
                if (count % 2 != 0) numbers_edit[i, M] = 1;
                else numbers_edit[i, M] = 0;
                Console.WriteLine();
            }
            Console.WriteLine("Edit array:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M+1; j++) Console.Write($"{numbers_edit[i, j]} ");
                Console.WriteLine();
            }
            
            //Задание 6
            Console.WriteLine("\nTask 6:");
            double[] all_numbers = new double[20];
            List<double> positive_numbers = new List<double>();
            List<double> negative_numbers = new List<double>();
            for (int i = 0; i < 20; i++)
            {
                all_numbers[i] = rnd.Next(-30, 30) / 4.00;
                Console.Write($"{all_numbers[i]} ");
                if (all_numbers[i] >= 0) positive_numbers.Add(all_numbers[i]);
                else negative_numbers.Add(all_numbers[i]);
            }
            Console.WriteLine();
            foreach (double positiveNumber in positive_numbers) Console.Write($"{positiveNumber} ");
            Console.WriteLine();
            foreach (double negativeNumber in negative_numbers) Console.Write($"{negativeNumber} ");
        }
    }
}