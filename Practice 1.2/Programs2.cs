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
            Console.WriteLine("App_1:");
            
            int[] numbers_app1 = new int[100];
            Random rnd = new Random();
            numbers_app1[99] = rnd.Next(300, 1000);

            for (int i = 99; i > 0; i--)
            {
                numbers_app1[i - 1] = numbers_app1[i] - 3;
                Console.Write($"{numbers_app1[i]} ");
            }
            
            //Задание 2
            Console.WriteLine("\n\nApp_2:");
            
            int[] numbers_app2 = new int[30];
            int k = 1;

            for (int i = 0; i < 30; i++)
            {
                numbers_app2[i] = k;
                k += 2;
                Console.Write($"{numbers_app2[i]} ");
            }
            
            //Задание 3
            Console.WriteLine("\n\nApp_3:");

            int[,] numbers_app3 = new int[5, 5];

            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (row == 0 || column == 0)
                    {
                        numbers_app3[row, column] = 1;
                    }
                    else
                    {
                        numbers_app3[row, column] = numbers_app3[row - 1, column] + numbers_app3[row, column - 1];
                    }
                    Console.Write($"{numbers_app3[row,column]} ");
                }
                Console.WriteLine();
            }
            
            //Задание 4
            Console.WriteLine("\n\nApp_4:");

            int[,] temperature = new int[12, 30];
            int[] middle_temperature = new int[12];
            int summ_temperature = 0;
            
            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    if (month < 2 || month == 11)
                    {
                        temperature[month,day] = rnd.Next(-45, -5);
                    }
                    else if (month < 5 || month >= 8)
                    {
                        temperature[month, day] = rnd.Next(-5, 20);
                    }
                    else
                    {
                        temperature[month, day] = rnd.Next(10, 45);
                    }
                    summ_temperature += temperature[month, day];
                }
                middle_temperature[month] = summ_temperature / 30;
                summ_temperature = 0;
            }
            Console.WriteLine("Average temperature:");
            
            for (int i = 0; i < 12; i++)
            {
                Console.Write($"{middle_temperature[i]} ");
            }
            Array.Sort(middle_temperature);
            
            Console.WriteLine("\nSorted average temperature:");
            for (int i = 0; i < 12; i++)
            {
                Console.Write($"{middle_temperature[i]} ");
            }
            
            //Задание 5
            Console.WriteLine("\n\nApp_5:");
            
            Dictionary<int, int[]> temperature_dictionary = new Dictionary<int, int[]>();
            for (int month = 0; month < 12; month++)
            {
                int[] month_temperature = new int[30];
                for (int day = 0; day < 30; day++)
                {
                    if (month < 2 || month == 11)
                    {
                        month_temperature[day] = rnd.Next(-45, -5);
                    }
                    else if (month < 5 || month >= 8)
                    {
                        month_temperature[day] = rnd.Next(-5, 20);
                    }
                    else
                    {
                        month_temperature[day] = rnd.Next(10, 45);
                    }
                }
                temperature_dictionary.Add(month, month_temperature);
            }
            Dictionary<int, int> avarage_temperature = new Dictionary<int, int>();
            Console.WriteLine("Average temperature:");
            foreach (var dictionary in temperature_dictionary)
            {
                int summ = 0;
                for (int i = 0; i < 30; i++)
                {
                    summ += dictionary.Value[i];
                }
                Console.WriteLine($"{dictionary.Key}: {summ/30}");
                avarage_temperature.Add(dictionary.Key, (summ/30));
            }
            Console.WriteLine("\nSorted average temperature:");
            var sorted_temperature = avarage_temperature.OrderBy(x => x.Value);
            foreach (var dictionary in sorted_temperature)
            {
                Console.WriteLine($"{dictionary.Key}: {dictionary.Value}");
            }
        }
    }
}