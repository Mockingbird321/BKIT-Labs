using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLab6
{
    class Program
    {
        delegate double CalcDeleg(double a, double b);

        static double Sum(double a, double b) { return a + b; }
        static double Dif(double a, double b) { return a - b; }
        static double Mul(double a, double b) { return a * b; }
        static double Div(double a, double b) { return a / b; }

        static void CalcResult(string str, double arg1, double arg2, CalcDeleg DelParametr)
        {
            double result = DelParametr(arg1, arg2);
            Console.WriteLine(str + result.ToString());
        }

        static void Main(string[] args)
        {
            Console.Write("x = "); double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = "); double y = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine("Без лябмда-выражений:");
            CalcResult("Сложение: ", x, y, Sum);
            CalcResult("Вычитание: ", x, y, Dif);
            CalcResult("Умножение: ", x, y, Mul);
            CalcResult("Деление: ", x, y, Div);

            Console.WriteLine("\nС использованием лябмда-выражений:");
            CalcResult("Сложение: ", x, y, (arg1, arg2) => arg1 + arg2);
            CalcResult("Вычитание: ", x, y, (arg1, arg2) => arg1 - arg2);
            CalcResult("Умножение: ", x, y, (arg1, arg2) => arg1 * arg2);
            CalcResult("Деление: ", x, y, (arg1, arg2) => arg1 / arg2);

            Console.WriteLine("\nС использованием обобщенных делегатов:");
            Action<double, double> Sumaction = (arg1, arg2) =>
            { Console.WriteLine("{0} + {1} = {2}", arg1, arg2, arg1 + arg2); };

            Action<double, double> Difaction = (arg1, arg2) =>
            { Console.WriteLine("{0} - {1} = {2}", arg1, arg2, arg1 - arg2); };

            Action<double, double> Mulaction = (arg1, arg2) =>
            { Console.WriteLine("{0} - {1} = {2}", arg1, arg2, arg1 * arg2); };

            Action<double, double> Divaction = (arg1, arg2) =>
             { Console.WriteLine("{0} / {1} = {2}", arg1, arg2, arg1 / arg2); };

            Action<double, double> AllDelegates = Difaction + Sumaction + Mulaction + Divaction;
            AllDelegates(x, y);

            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
