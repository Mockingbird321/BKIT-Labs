using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба
{
    class Program
    {   /*Проверка на правильность ввода*/
        static double readFromConsole()
        {
            while (true)
            {
                string str = Console.ReadLine();

                double result;
                if (double.TryParse(str, out result))
                    return result;
                else
                    Console.WriteLine("Invalid input, try again.");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            double A = 0, B = 0, C = 0; /*коэффы*/
            double D, d;

            Console.WriteLine("Vvedite A:");
            A = readFromConsole(); /*Реализование проверки через TryParse*/

            while (A == 0)
            {
                Console.WriteLine("Koef A ne mojet bit raven nulu!");
                A = readFromConsole();
            }

            Console.WriteLine("Vvedite B:");
            B = readFromConsole();
            Console.WriteLine("Vvedite C:");
            C = readFromConsole();


            D = B * B - 4 * A * C;
            d = Math.Sqrt(D);

            Console.WriteLine("Discriminant uravneniya D = " + D.ToString() + "\n");
            
            /*выбор пути решения*/
            if (D > 0)
            {
                double x1, x2;
                x1 = (-B + d) / (2 * A);
                x2 = (-B - d) / (2 * A);
                /*проверка на равность корней*/
                /*чтоб не показывал два одинаковых корня*/
                if (x1 != x2)
                    Console.WriteLine("Perviy koren uravneniya x1 = " + x1.ToString() + "\nVtoroi koren uravneniya x2 = " + x2.ToString());
                else Console.WriteLine("Koren uravneniya x = " + x1.ToString());
            }

            if (D == 0)
            {
                double x;
                x = (-B) / (2 * A);

                Console.WriteLine("Koren uravneniya x = " + x.ToString());
            }

            if (D < 0)
                Console.WriteLine("Korney net!\n");

            Console.WriteLine("\n\n\n\nDlya prodolzheniya vvedite lubuyu klavishu..."); /*system("pause")*/  /*c++*/
            Console.ReadKey();
        }
    }
}
