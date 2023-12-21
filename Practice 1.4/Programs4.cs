using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Practice_1._4
{
    internal class Programs4
    {
        public static void Main()
        {
            //Задание 1
            Console.WriteLine("Task 1:");
            Random rnd = new Random();
            int N = rnd.Next(1, 30);
            int mult = 1;
            for (int i = 3; i < N+1; i += 3)
            {
                mult *= i;
                Console.Write($"{i} ");
            }
            Console.WriteLine($"\nN: {N}, Mult of all numbers: {mult}");
            
            //задание 2
            Console.WriteLine("\nTask 2:");
            string pathNumsTask2 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.4/numsTask2.txt";
            using (StreamReader readerTask2 = new StreamReader(pathNumsTask2))
            {
                string lineNumbers = readerTask2.ReadLine();
                string[] numbersMas = lineNumbers.Split(';');
                double[] numbersMasDouble = Array.ConvertAll(numbersMas, str => double.Parse(str));
                double sum = 0;
                foreach (double number in numbersMasDouble)
                {
                    if (number == 0) break;
                    if (number > 0) sum += number;
                    Console.Write($"{number} ");
                }
                Console.WriteLine($"\nSumm of positive numbers: {sum}");
            }

            //Задание 3
            Console.WriteLine("\nTask 3:");
            string pathNumsTask3 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.4/numsTask3.txt";
            using (StreamReader readerTask3 = new StreamReader(pathNumsTask3))
            {
                string lineNumbers = readerTask3.ReadLine();
                string[] stringNumbers = lineNumbers.Split(',');
                int[] numbersMasInt = Array.ConvertAll(stringNumbers, str => int.Parse(str));
                double maxNumber = numbersMasInt[0];
                double minNumber = numbersMasInt[0];
                foreach (int number in numbersMasInt)
                {
                    if (number == 0) break;
                    if (maxNumber < number) maxNumber = number;
                    if (minNumber > number) minNumber = number;
                    Console.Write($"{number} ");
                }
                Console.WriteLine($"\nMax number: {maxNumber}");
                Console.WriteLine($"Min number: {minNumber}");
                Console.WriteLine($"Ratio of minimum to maximum: {minNumber/maxNumber}");
            }

            //Задание 4
            Console.WriteLine("\nTask 4:");
            string pathNumsTask4 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.4/numsTask4.txt";
            using (StreamReader readerTask4 = new StreamReader(pathNumsTask4))
            {
                string lineNumbers = readerTask4.ReadLine();
                string[] stringNumbers = lineNumbers.Split();
                int[] numbersMasInt = Array.ConvertAll(stringNumbers, str => int.Parse(str));
                List<int> listNumbers = numbersMasInt.ToList();
                foreach (int number in listNumbers) Console.Write($"{number} ");
                int verifiableNumber = listNumbers[0];
                int maxCount = 0;
                int maxCountNumber = listNumbers[0];
                for (int i = 0; i < listNumbers.Count-1; i++)
                {   
                    int local = 1;
                    int count = 1;
                    verifiableNumber = listNumbers[i];
                    while (i+local <= listNumbers.Count-1 && verifiableNumber == listNumbers[i+local])
                    {
                        count += 1;
                        local += 1;
                    }
                    if (maxCount < count)
                    {
                        maxCount = count;
                        maxCountNumber = verifiableNumber;
                    }
                }
                Console.WriteLine($"\nMax count number: {maxCountNumber}");
                Console.WriteLine($"Count: {maxCount}");
            }

            //Задание 5
            Console.WriteLine("\nTask 5:");
            Console.Write("Input a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Input b: ");
            double b = double.Parse(Console.ReadLine());
            if (a >= -1 && a <= 3 && b >= -2 && b <= 4) Console.WriteLine("A point is in area");
            else Console.WriteLine("A point isn't in area");

            //Задание 6
            Console.WriteLine("\nTask 6:");
            Console.Write("Input a: ");
            double a1 = double.Parse(Console.ReadLine());
            Console.Write("Input b: ");
            double b1 = double.Parse(Console.ReadLine());
            if ((a1 >= 0) && (a1 <= 2) && (b1 <= 2 - 2.5 * a1) && (b1 >= -3)) Console.WriteLine("A point is in area");
            else if ((a1 <= 0) && (a1 >= -2) && (b1 <= 2 + 2.5 * a1) && (b1 >= -3)) Console.WriteLine("A point is in area");
            else Console.WriteLine("A point isn't in area");
        }
    }
}