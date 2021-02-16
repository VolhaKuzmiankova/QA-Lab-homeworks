using System;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            byte num1 = 13;
            if (num1 >= 11)
            {
                Console.WriteLine($"Post increment operation: {num1++}");
                Console.WriteLine($"Result: {num1}");
            }

            sbyte num2 = -3;
            if (num2 != 1)
            {
                Console.WriteLine($"Pred decrement operation: {--num2}");
                Console.WriteLine($"Result: {num2}");
            }

            bool alive = true;
            for (int i = 0; i < 2; i++)
            {
                if (alive)
                {
                    Console.WriteLine("It's alive");
                    alive = false;
                }
                else
                {
                    Console.WriteLine("It's not alive");
                }
            }

            
            double num3 = 533.0;
            if (num3 % 2 == 1)
            {
                Console.WriteLine($"Something {num3}");
            }
            else
            {
                Console.WriteLine("Something wrong..");
            }

            float num4 = 31.7f;

            var u = num4 * 15;
            Console.WriteLine(u);

            decimal num5 = 323.9m;
            if (num5 <= 500 || num5 >= 300)
            {
                Console.WriteLine($"{num5}: perfect number");
            }

            int num6 = -17;
            if (num6 == -17 | num6++ >= 23)
            {
                Console.WriteLine(num6);
            }
            else
            {
                Console.WriteLine(num6 - 1);
            }


            uint num7 = 23;
            uint x = 19;
            uint max;
            max = num7 > x ? num7 : x;
            Console.WriteLine(max);
            if (max - x > num7 ^ x + num7 > max)
            {
                Console.WriteLine("Max is less than sum of two numbers");
            }
            
            
            long num8 = -117;
            ulong num9 = 119;
            long sum;

            if (num8 <= (long) num9 && num8 < 0)
            {
                sum = num8 + (long) num9;
                Console.WriteLine(sum);
            }

            short num10 = 2;
            if (num10 == null & --num10 <= 0)
            {
                Console.WriteLine(num10);
            }
            else
            {
                Console.WriteLine("Nope");
                Console.WriteLine(num10);
            }

            string question = "What is your name";
            if (question is object)
            {
                Console.WriteLine("Hello! {0}, man?", question);
            }

            object name = "Winnie-the-Pooh";
            string name1 = name as string;
            char symbol = 'o';
            Console.WriteLine($"Hi! My name is {name1}!");
            if (name1.Contains(symbol))
            {
                Console.WriteLine($"My name contains symbol {symbol}");    
            }

            dynamic dyn = 13;
            dyn += 6;
            Console.WriteLine(dyn);
            
         int num13 = 175;
         int num = num13 / 5;
         if (num < 40)
         {
             Console.WriteLine(+num); // -35
         }

         bool check = true;
         Console.WriteLine(!check);

         short a = -113;
         Console.WriteLine(++a);

         ushort b = 10;
         Console.WriteLine(b--);

        }
        
    }
}