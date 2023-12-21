using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Practice_1._5
{
    internal class Programs5
    {
        public static void Main()
        {
            //Задание 1
            Console.WriteLine("Task 1:");
            string pathNumsTask1 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.5/numsTask1.txt";
            using (StreamReader readerTask1 = new StreamReader(pathNumsTask1))
            {
                string lineNumbers = readerTask1.ReadLine();
                string[] stringNumbers = lineNumbers.Split();
                int[] numbersMasInt = Array.ConvertAll(stringNumbers, str => int.Parse(str));
                List<int> listNumbers = numbersMasInt.ToList();
                int minNumber = listNumbers[0];
                int minIndex = 0;
                for (int i = 0; i < listNumbers.Count; i++)
                {
                    Console.Write($"{listNumbers[i]} ");
                    if (minNumber > listNumbers[i])
                    {
                        minNumber = listNumbers[i];
                        minIndex = i;
                    }
                }
                Console.WriteLine($"\nMin number: {minNumber}");
                int mult = 1;
                for (int i = minIndex + 1; i < listNumbers.Count; i++)
                {
                    mult *= listNumbers[i];
                }
                Console.WriteLine($"Mult of numbers after minimal number: {mult}");
            }
            
            //Задание 2
            Console.WriteLine("\nTask 2:");
            string pathNumsTask2 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.5/numsTask2.txt";
            string lineNumbersGlobal;
            using (StreamReader readerTask2 = new StreamReader(pathNumsTask2))
            {
                lineNumbersGlobal = readerTask2.ReadLine();
            }
            string[] numbersMas = lineNumbersGlobal.Split(';');
            double[] numbersMasDouble = Array.ConvertAll(numbersMas, str => double.Parse(str));
            List<double> listNumbersGlobal = numbersMasDouble.ToList();
            double temp;
            for (int i = 0; i < listNumbersGlobal.Count; i++)
            {
                for (int j = i + 1; j < listNumbersGlobal.Count; j++)
                {
                    if (listNumbersGlobal[i] > listNumbersGlobal[j])
                    {
                        temp = listNumbersGlobal[i];
                        listNumbersGlobal[i] = listNumbersGlobal[j];
                        listNumbersGlobal[j] = temp;
                    }
                }
            }
            using (StreamWriter writerTask2 = new StreamWriter(pathNumsTask2, true))
            {
                writerTask2.Write("\nSorted list: ");
                foreach (double number in listNumbersGlobal) writerTask2.Write($"{number} ");
            }
            Console.WriteLine("\nCheck the txt file 'numsTask2'");

            //Задание 3
            Console.WriteLine("\nTask 3:");
            string pathNumsTask3 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.5/numsTask3.txt";
            using (StreamReader readerTask3 = new StreamReader(pathNumsTask3))
            {
                string lineNumbers = readerTask3.ReadLine();
                string[] stringNumbers = lineNumbers.Split();
                int[] numbersMasInt = Array.ConvertAll(stringNumbers, str => int.Parse(str));
                List<int> listNumbers = numbersMasInt.ToList();
                int minNumber = listNumbers[0];
                int minIndex = 0;
                for (int i = 0; i < listNumbers.Count; i++)
                {
                    Console.Write($"{listNumbers[i]} ");
                    if (minNumber > listNumbers[i])
                    {
                        minNumber = listNumbers[i];
                        minIndex = i;
                    }
                }
                Console.WriteLine($"\nMin number: {minNumber}");
                double sum = 0;
                int count = 0;
                for (int i = minIndex - 1; i >= 0; i--)
                {
                    sum += listNumbers[i];
                    count += 1;
                }
                Console.WriteLine($"Average of numbers before minimal: {sum/count}");
            }

            //Задание 4
            Console.WriteLine("\nTask 4:");
            string pathNumsTask4 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.5/numsTask4.txt";
            using (StreamReader readerTask4 = new StreamReader(pathNumsTask4))
            {
                string lineNumbers = readerTask4.ReadLine();
                string[] stringNumbers = lineNumbers.Split();
                int[] numbersMasInt = Array.ConvertAll(stringNumbers, str => int.Parse(str));
                List<int> listNumbers = numbersMasInt.ToList();
                int maxNumber = listNumbers[0];
                foreach (int number in listNumbers)
                {
                    Console.Write($"{number} ");
                    if (maxNumber < number) maxNumber = number;
                }
                Console.WriteLine($"\nMax number: {maxNumber}");
                int sum = 0;
                foreach (int number in listNumbers) if (number == maxNumber - 1) sum += number;
                Console.WriteLine($"The summ of the numbers that differ from the maximum by 1: {sum}");
            }

            //Задание 5
            Console.WriteLine("\nTask 5:");
            string pathNumsTask5 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.5/numsTask5.txt";
            using (StreamReader readerTask5 = new StreamReader(pathNumsTask5))
            {
                string lineNumbers = readerTask5.ReadLine();
                string[] stringNumbers = lineNumbers.Split();
                int[] numbersMasInt = Array.ConvertAll(stringNumbers, str => int.Parse(str));
                List<int> listNumbers = numbersMasInt.ToList();

                int maxNumber = listNumbers[0];
                int maxIndex = 0;
                int minNumber = listNumbers[0];
                int minIndex = 0;

                for (int i = 0; i < listNumbers.Count; i++)
                {
                    Console.Write($"{listNumbers[i]} ");
                    if (maxNumber < listNumbers[i])
                    {
                        maxNumber = listNumbers[i];
                        maxIndex = i;
                    }
                    if (minNumber > listNumbers[i])
                    {
                        minNumber = listNumbers[i];
                        minIndex = i;
                    }
                }
                double sum = 0;
                int count = 0;
                for (int i = Math.Min(maxIndex, minIndex)+1; i < Math.Max(maxIndex, minIndex); i++)
                {
                    sum += listNumbers[i];
                    count += 1;
                }
                Console.WriteLine($"\nMin number: {minNumber}");
                Console.WriteLine($"Max number: {maxNumber}");
                Console.WriteLine($"Average of numbers between maximum and minimum: {sum/count}");
            }
        }
    }
}