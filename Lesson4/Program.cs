using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] answerTask2 = Task2(300000000);
            //Task10(20);
            //double answerTask27 = Task27(7, 10);
            //Console.WriteLine(answerTask27);
            //Console.WriteLine(Task27a(7, 10));
            //Task68(1000, 2, 12);
            //Task68a(1000, 2, 12);
            //Task299(1234, 3);

            //Task172();

            //Console.WriteLine(  factorial(5));
            //Console.WriteLine(  factorialRecursion(5));

            Console.WriteLine(summaPropis(0));
            Console.WriteLine(summaPropis(1));
            Console.WriteLine(summaPropis(500));
            Console.WriteLine(summaPropis(112));
            Console.WriteLine(summaPropis(220));
            Console.WriteLine(summaPropis(857));


            Console.ReadLine();
        }

        static string summaPropis(int money)
        {
            string result = "";
            int digitsNumber = 0, t = money;
            while (t > 0)
            {
                t /= 10;
                digitsNumber++;
            }

            
            int []digits = new int[digitsNumber];

            int number = 0, div = (int)Math.Pow(10, digitsNumber - 1);
            for (int i = 1; i <= digitsNumber; i++)
            {
                number = (money / div) % 10;
                div /= 10;
                digits[i - 1] = number;
                Console.Write($"{digits[i-1]} ");
            }


            // hundreds
            if (digitsNumber >= 3)
            {
                    switch (digits[digitsNumber - 3])
                    {
                        case 1: result += "one"; break;
                        case 2: result += "two"; break;
                        case 3: result += "three"; break;
                        case 4: result += "four"; break;
                        case 5: result += "five"; break;
                        case 6: result += "six"; break;
                        case 7: result += "seven"; break;
                        case 8: result += "eight"; break;
                        case 9: result += "nine"; break;

                        default:
                            break;
                    }
                    result += " hundred" + (digits[digitsNumber - 3] > 1 ? "s" : "");
                    if (digits[digitsNumber - 1] > 0 || digits[digitsNumber - 2] > 0)
                        result += " and ";
            }
            // tens
            if (digitsNumber >= 2)
            {
                if (digits[digitsNumber - 2] == 1)
                {
                    switch (digits[digitsNumber - 1])
                    {
                        case 0: result += "ten"; break;
                        case 1: result += "eleven"; break;
                        case 2: result += "twelve"; break;
                        case 3: result += "thirteen"; break;
                        case 4: result += "fourteen"; break;
                        case 5: result += "fivteen"; break;
                        case 6: result += "sixteen"; break;
                        case 7: result += "seventeen"; break;
                        case 8: result += "eightteen"; break;
                        case 9: result += "nineteen"; break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (digits[digitsNumber - 2] > 1)
                    {
                        switch (digits[digitsNumber - 2])
                        {
                            case 2: result += "twenty"; break;
                            case 3: result += "thirty"; break;
                            case 4: result += "fourty"; break;
                            case 5: result += "fifty"; break;
                            case 6: result += "sixty"; break;
                            case 7: result += "seventy"; break;
                            case 8: result += "eighty"; break;
                            case 9: result += "ninety"; break;
                            default:
                                break;
                        }
                    }

                    result += onesPropis(digits[digitsNumber-1]);
                }
            }

            if (digitsNumber == 1)
                result += onesPropis(digits[digitsNumber - 1]);

            //Console.WriteLine($"digits:{digitsNumber}\n");

            if (digitsNumber == 0)
                result = "Zero";

            return result;
        }

        static string onesPropis(int number)
        {
            string result = "";

            switch (number)
            {
                case 1: result += "one"; break;
                case 2: result += "two"; break;
                case 3: result += "three"; break;
                case 4: result += "four"; break;
                case 5: result += "five"; break;
                case 6: result += "six"; break;
                case 7: result += "seven"; break;
                case 8: result += "eight"; break;
                case 9: result += "nine"; break;

                default:
                    break;
            }

            return result;
        }

        static int[] Task2(int number)
        {
            List<int> answerList = new List<int>();
            for (int i = number / 2; i >= 1; i--)
            {
                if (number % i == 0)
                {
                    answerList.Add(i);
                }
            }
            return answerList.ToArray();
        }

        static void Task10(int pound)
        {
            int poundInKilogram = 453; // фунт = 453грм
            for (int i = 1; i <= pound; i++)
            {
                Console.WriteLine($"{i} pound" + (i == 1 ? string.Empty : "s").ToString() +
                                $" = {i * poundInKilogram / 1000.0} kg");
            }
        }

        static double Task27(int x, int count)
        {
            double sum = 0, plusMinusCounter = 1;
            //bool plusMinus = false;
            for (int i = 3; i <= count; i++)
            {
                if (i % 2 != 0)
                {
                    sum += plusMinusCounter % 2 != 0 ? -Math.Pow(x, i) / factorialRecursion(i) :
                        Math.Pow(x, i) / factorialRecursion(i);
                    plusMinusCounter++;
                    /* if (!plusMinus) //Вариант с переменной bool для очередности знака +- Вверху вариант короче
                     {
                         sum -= Math.Pow(x, i) / factorialRecursion(i);
                         plusMinus = true;
                     }
                     else
                     {
                         sum += Math.Pow(x, i) / factorialRecursion(i);
                         plusMinus = false;
                     }*/
                }
            }

            return x + sum;
        }

        static double Task27a(int x, int count)
        {
            double sum = x, sign = 1, chislitel = x, znamenatel = 1;

            for (int i = 3; i <= count; i+=2)
            {
                chislitel = chislitel * x * x;
                znamenatel = znamenatel * (i - 1) * i;
                sign *= -1;
                sum += sign * chislitel / znamenatel;
            }

            return sum;
        }

        // Для задания 27. Определяем факториал с помощью рекурсии
        static double factorialRecursion(int number)
        {
            if (number == 0)
                return 1;
            else
                return number * factorialRecursion(number - 1);
        }

        static double factorial(int number)
        {
            int result = 1;

            for (int i = 2; i <= number; i++)
                result *= i;

            return result;
        }

        static void Task68(double sumInvest, double percent, int month)
        {
            percent /= 100;
            for (int i = 1; i <= month; i++)
            {
                sumInvest = sumInvest + (sumInvest * percent);
                Console.WriteLine($"{i} month = {Math.Round(sumInvest, 2)} uah");
            }
        }

        static void Task68a(double sumInvest, double percent, int month)
        {
            double summa = sumInvest;
            double prirost = 0;
            int monthNumber = 0, monthNumber1200 = 0;
            do {
                prirost = summa * percent / 100;
                summa = summa + prirost;
                monthNumber++;
                if (summa > 1200 && monthNumber1200 == 0)
                   monthNumber1200 = monthNumber;
            }
            while (prirost < 30);
            Console.WriteLine(monthNumber);
            Console.WriteLine(monthNumber1200);

        }
        static void Task299(int number, int digit)
        {
            for (int i = number; i > 0; i /= 10)
            {
                if (i % 10 == digit)
                {
                    Console.WriteLine($"Digit {digit} find in number {number}");
                    break;
                }
            }
        }

        static void Task172()
        {
            /*Заполнение случайными очками для команд*/
            int[] masComands = new int[20];
            Random rand = new Random();
            for (int i = masComands.Length - 1; i >= 0; i--)
            {
                int randomNumber = rand.Next(20, 50) * i;
                int previousIndex = i + 1;
                if (i != masComands.Length - 1)
                {
                    while (masComands[previousIndex] <= randomNumber)
                    {
                        randomNumber = rand.Next(20, 50) * i;
                    }
                }

                masComands[i] = randomNumber;
                Console.WriteLine($"Сommand #{previousIndex} = {randomNumber} points");
            }
            /*------------------------------------------*/

            Console.Write("Enter the number of team points: ");
            int enterPoints = Convert.ToInt32(Console.ReadLine());

            for (int i = masComands.Length - 1; i >= 0; i--)
            {
                if (masComands[i] == enterPoints)
                {
                    Console.WriteLine($"Command #{(i + 1).ToString()} took {masComands.Length - i} place");
                    break;
                }
            }
        }
    }
}
