using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Practice_1._3
{
    internal class Programs3
    {
        public static void Main()
        {
            //Задание 1
            Console.WriteLine("Task 1:\nCheck the txt file 'output'");
            string path1 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.3/input.txt";
            string path2 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.3/output.txt";
            
            using (StreamReader readerInput = new StreamReader(path1))
            {
                string luckyNumbers = readerInput.ReadLine();
                string[] luckyNumbersMas = luckyNumbers.Split();
                int n = int.Parse(readerInput.ReadLine());
                using (StreamWriter writerOutput = new StreamWriter(path2, false))
                {
                    for (int i = 0; i < n; i++)
                    {
                        int count = 0;
                        string ticket = readerInput.ReadLine();
                        string[] ticketNumbers = ticket.Split();
                        for (int ticketNumber = 0; ticketNumber < 6; ticketNumber++)
                        {
                            for (int luckyNumber = 0; luckyNumber < 10; luckyNumber++)
                            {
                                if (ticketNumbers[ticketNumber] == luckyNumbersMas[luckyNumber]) count += 1;
                            }
                        }
                        if (count >= 3)            
                        {
                            writerOutput.WriteLine($"Lucky");            
                        }
                        else            
                        {
                            writerOutput.WriteLine($"Unlucky");            
                        }
                    }
                }
            }
            

            //Задание 2
            Console.WriteLine("\nTask 2:\nCheck the txt file 'nums'");
            string path3 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.3/nums.txt";

            List<int> intListNumbers = new List<int>();
            using (StreamReader reader2 = new StreamReader(path3))
            {    
                string text = reader2.ReadLine();
                string[] numbers = text.Split();
                int[] intNumbers = Array.ConvertAll(numbers, str => int.Parse(str));
                intListNumbers = intNumbers.ToList();
            }  
            using (StreamWriter writer2 = new StreamWriter(path3, true))
            {
                writer2.WriteLine("\nList without even numbers:");
                foreach (int number in intListNumbers)
                {
                    if (number % 2 != 0) writer2.Write($"{number} ");
                }
            }
            
            //Задание 3
            Console.WriteLine("\nTask 3:\nCheck the txt file 'waterpool'");
            string path4 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.3/waterpool.txt";
            int maxI=0;
            int maxJ=0;
            int maxS=0;
            using (StreamReader reader3 = new StreamReader(path4))
            {
                string text = reader3.ReadLine();
                string[] numbers = text.Split();
                int[] height = Array.ConvertAll(numbers, str => int.Parse(str));
                
                int s = 0;
                int x = 0;
                int y = 0;
                
                for (int i=0; i < 10; i++)
                {
                    for (int j=0; j < 10; j++)
                    {
                        if (i <= j) x = j - i;
                        if (i > j) x = i - j;
                        if (height[i] >= height[j])
                        {
                            y = height[j];
                            s = x * y;
                        }
                        if (height[i] < height[j])
                        {
                            y = height[i];
                            s = x * y;
                        }
                        if (maxS < s)
                        {
                            maxS = s;
                            maxI = i;
                            maxJ = j;
                        }
                    }
                }
            }
            using (StreamWriter writer3 = new StreamWriter(path4, true))
            {
                writer3.Write($"\nLine 1: {maxI+1}, Line 2: {maxJ+1}, Max square: {maxS}");
            }
        }
    }
}