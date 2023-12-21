using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Practice_1._2
{
    internal class Programs2
    {
        public static void Main()
        {
            //Задание 1
            Console.WriteLine("Task 1:");
            int[] numbersMas1 = new int[100];
            Random rnd = new Random();
            numbersMas1[99] = rnd.Next(300, 1000);
            for (int i = 99; i > 0; i--)
            {
                numbersMas1[i - 1] = numbersMas1[i] - 3;
                Console.Write($"{numbersMas1[i]} ");
            }
            
            //Задание 2
            Console.WriteLine("\n\nTask 2:");
            int[] numbersMas2 = new int[30];
            int k = 1;
            for (int i = 0; i < 30; i++)
            {
                numbersMas2[i] = k;
                k += 2;
                Console.Write($"{numbersMas2[i]} ");
            }
            
            //Задание 3
            Console.WriteLine("\n\nTask 3:");
            Console.Write("Enter the number of rows: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of columns: ");
            int M = int.Parse(Console.ReadLine());
            int[,] numbersMas3 = new int[N, M];
            for (int row = 0; row < N; row++)
            {
                for (int column = 0; column < M; column++)
                {
                    if (row == 0 || column == 0) numbersMas3[row, column] = 1;
                    else numbersMas3[row, column] = numbersMas3[row - 1, column] + numbersMas3[row, column - 1];
                    Console.Write($"{numbersMas3[row,column]} ");
                }
                Console.WriteLine();
            }
            
            //Задание 4
            Console.WriteLine("\n\nTask 4:");
            int[,] temperature = new int[12, 30];
            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    if (month < 2 || month == 11) temperature[month,day] = rnd.Next(-45, -5);
                    else if (month < 5 || month >= 8) temperature[month, day] = rnd.Next(-5, 20);
                    else temperature[month, day] = rnd.Next(10, 45);
                }
            }
            //Используем метод
            double[] averageTemperature = Average(temperature);
            Console.WriteLine("Average temperature:");
            foreach (double average in averageTemperature) Console.Write($"{average.ToString("0.0")} ");
            Array.Sort(averageTemperature);
            Console.WriteLine("\nSorted average temperature:");
            foreach (double average in averageTemperature) Console.Write($"{average.ToString("0.0")} ");
            
            //Задание 5
            Console.WriteLine("\n\nTask 5:");
            Dictionary<int, int[]> temperatureDictionary = new Dictionary<int, int[]>();
            for (int month = 0; month < 12; month++)
            {
                int[] monthTemperature = new int[30];
                for (int day = 0; day < 30; day++)
                {
                    if (month < 2 || month == 11) monthTemperature[day] = rnd.Next(-45, -5);
                    else if (month < 5 || month >= 8) monthTemperature[day] = rnd.Next(-5, 20);
                    else monthTemperature[day] = rnd.Next(10, 45);
                }
                switch (month)
                {
                    case 0: temperatureDictionary.Add(0, monthTemperature); break;
                    case 1: temperatureDictionary.Add(1, monthTemperature); break;
                    case 2: temperatureDictionary.Add(2, monthTemperature); break;
                    case 3: temperatureDictionary.Add(3, monthTemperature); break;
                    case 4: temperatureDictionary.Add(4, monthTemperature); break;
                    case 5: temperatureDictionary.Add(5, monthTemperature); break;
                    case 6: temperatureDictionary.Add(6, monthTemperature); break;
                    case 7: temperatureDictionary.Add(7, monthTemperature); break;
                    case 8: temperatureDictionary.Add(8, monthTemperature); break;
                    case 9: temperatureDictionary.Add(9, monthTemperature); break;
                    case 10: temperatureDictionary.Add(10, monthTemperature); break;
                    case 11: temperatureDictionary.Add(11, monthTemperature); break;
                }
            }
            //Используем метод
            Dictionary<string, double> averageDictionary = DictionaryAverage(temperatureDictionary);
            Console.WriteLine("Average temperature:");
            foreach (var average in averageDictionary)
            {
                Console.WriteLine($"{average.Key}: {average.Value.ToString("0.0")}");
            }
            
            var sortedAverage = averageDictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("\nSorted average temperature:");
            foreach (var average in sortedAverage)
            {
                Console.WriteLine($"{average.Key}: {average.Value.ToString("0.0")}");
            }
        }
        //Метод для 4 задания
        public static double[] Average(int[,] TemperatureMas)
        {
            double[] AverageTemperature = new double[12];
            for (int i = 0; i < 12; i++)
            {
                double monthSum = 0;
                for (int j = 0; j < 30; j++) monthSum += TemperatureMas[i, j];
                AverageTemperature[i] = monthSum / 30;
            }
            return AverageTemperature;
        }
        //Метод для 5 задания
        public static Dictionary<string, double> DictionaryAverage(Dictionary<int, int[]> dictionaryTemperature)
        {
            Dictionary<string, double> averageDictionary = new Dictionary<string, double>();
            foreach (var month in dictionaryTemperature)
            {
                switch (month.Key)
                {
                    case 0: averageDictionary.Add("January", month.Value.Sum() / 30.0); break;
                    case 1: averageDictionary.Add("February", month.Value.Sum() / 30.0); break;
                    case 2: averageDictionary.Add("March", month.Value.Sum() / 30.0); break;
                    case 3: averageDictionary.Add("April", month.Value.Sum() / 30.0); break;
                    case 4: averageDictionary.Add("May", month.Value.Sum() / 30.0); break;
                    case 5: averageDictionary.Add("June", month.Value.Sum() / 30.0); break;
                    case 6: averageDictionary.Add("July", month.Value.Sum() / 30.0); break;
                    case 7: averageDictionary.Add("August", month.Value.Sum() / 30.0); break;
                    case 8: averageDictionary.Add("September", month.Value.Sum() / 30.0); break;
                    case 9: averageDictionary.Add("October", month.Value.Sum() / 30.0); break;
                    case 10: averageDictionary.Add("November", month.Value.Sum() / 30.0); break;
                    case 11: averageDictionary.Add("December", month.Value.Sum() / 30.0); break;
                }
            }
            return averageDictionary;
        }
    }
}