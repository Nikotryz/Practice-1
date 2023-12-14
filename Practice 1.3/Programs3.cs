using System;
using System.Collections.Generic;
using System.IO;

namespace Practice_1._3
{
    internal class Programs3
    {
        public static void Main(string[] args)
        {
            //Задание 1
            string path1 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.3/input.txt";
            string path2 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.3/output.txt";
            Random rnd = new Random();

            using (StreamWriter writer = new StreamWriter(path1, false))
            {
                for (int i = 0; i < 10; i++)    
                {
                    writer.Write($"{rnd.Next(1, 32)} ");    
                }
                int n = rnd.Next(1, 1000);    
                writer.WriteLine($"\n{n}");
                for (int i = 0; i < n; i++)    
                {
                    for (int j = 0; j < 6; j++)        
                    {
                        writer.Write($"{rnd.Next(1, 32)} ");        
                    }
                    writer.Write("\n");    
                }
            }       
            using (StreamReader reader = new StreamReader(path1))
            {
                string lucky_numbers = reader.ReadLine();    
                string[] lucky_numbers_mas = new string[10]; 
                string number1 = "";
                int metka = 0;    
                for (int l = 0; l < 10; l++)    
                {
                    for (int k = metka; k < lucky_numbers.Length; k++)        
                    {
                        if (lucky_numbers[k] != ' ')            
                        {
                            number1 += lucky_numbers[k];            
                        }
                        else            
                        {
                            metka = k+1;                
                            break;
                        }        
                    }
                    lucky_numbers_mas[l] = number1;        
                    number1 = "";
                }    
                metka = 0;
                int n = int.Parse(reader.ReadLine());
                using (StreamWriter writer_output = new StreamWriter(path2, false))
                {
                    string number2 = "";
                    int count = 0;
                    for (int i = 0; i < n; i++)        
                    {
                        string ticket = reader.ReadLine();
                        for (int j = 0; j < 6; j++)
                        {                
                            for (int h = metka; h < ticket.Length; h++)
                            {                    
                                if (ticket[h] != ' ')
                                {                        
                                    number2 += ticket[h];
                                }                    
                                else
                                {                        
                                    metka = h + 1;
                                    break;                    
                                }
                            }                
                            for (int proverka = 0; proverka < 10; proverka++)
                            {
                                if (number2 == lucky_numbers_mas[proverka])
                                {                        
                                    count += 1;
                                }                
                            }
                            number2 = "";            
                        }
                        if (count >= 3)            
                        {
                            writer_output.WriteLine($"Lucky");            
                        }
                        else            
                        {
                            writer_output.WriteLine($"Unlucky");            
                        }
                        count = 0;
                        metka = 0;
                    }
                }
            }  

            //Задание 2
            string path3 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.3/nums.txt";
            using (StreamWriter writer_app2 = new StreamWriter(path3, false))
            {
                for (int i = 0; i < 30; i++)    
                {
                    writer_app2.Write($"{rnd.Next(1,100)} ");    
                }
            }
            List<int> numbers = new List<int>();
            using (StreamReader reader_app2 = new StreamReader(path3))
            {    
                int metka_2 = 0;
                string number = "";    
                string text = reader_app2.ReadLine();
                for (int i = 0; i < 30; i++)
                {        
                    for (int j = metka_2; j < text.Length; j++)
                    {            
                        if (text[j] != ' ')
                        {                
                            number += text[j];
                        }            
                        else
                        {                
                            metka_2 = j+1;
                            break;            
                        }
                    }        
                    numbers.Add(int.Parse(number));
                    number = "";
                }
            }  
            using (StreamWriter writer_output_app2 = new StreamWriter(path3, true))
            {
                writer_output_app2.Write("\n");
                for (int i = 0; i < 30; i++)    
                {
                    if (numbers[i] % 2 != 0)        
                    {
                        writer_output_app2.Write($"{numbers[i]} ");
                    }    
                }
            }
            
            //Задание 3
            string path4 = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.3/waterpool.txt";

            int max_i=0;
            int max_j=0;
            int max_S=0;
            using (StreamReader reader_app3 = new StreamReader(path4))
            {
                int[] height = new int[10];
                string text = reader_app3.ReadLine();
                string number_app3 = "";
                int metka_app3 = 0;    
                for (int i = 0; i < 10; i++)    
                {
                    for (int j = metka_app3; j < text.Length; j++)        
                    {
                        if (text[j] != ' ')            
                        {
                            number_app3 += text[j];            
                        }
                        else            
                        {
                            metka_app3 = j+1;                
                            break;
                        }        
                    }
                    height[i] = int.Parse(number_app3);
                    Console.Write($"{height[i]} ");
                    number_app3 = "";
                }
                Console.WriteLine();
                int S = 0;
                int X = 0;
                int Y = 0;
                for (int i=0; i < 10; i++)
                {
                    for (int j=0; j < 10; j++)
                    {
                        if (i <= j)
                        {
                            X = j - i;
                        }
                        if (i > j)
                        {
                            X = i - j;
                        }
                        if (height[i] >= height[j])
                        {
                            Y = height[j];
                            S = X * Y;
                        }
                        if (height[i] < height[j])
                        {
                            Y = height[i];
                            S = X * Y;
                        }
                        if (max_S < S)
                        {
                            max_S = S;
                            max_i = i;
                            max_j = j;
                        }
                        Console.Write($"|X:{X}, Y:{Y}, S = {S}| ");
                    }
                    Console.WriteLine();
                }
            }
            using (StreamWriter writer_app3 = new StreamWriter(path4, true))
            {
                writer_app3.Write($"\nLine 1: {max_i+1}, Line 2: {max_j+1}, Max square: {max_S}");
            }
        }
    }
}