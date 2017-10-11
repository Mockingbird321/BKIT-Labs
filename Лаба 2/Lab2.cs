using System;

namespace ConsoleApp23
{
    /// <summary>
    /// Интерфейс
    /// </summary>
    interface IPrint
    {
        void IPrint();
    }
    /// <summary>
    /// Класс Фигура
    /// </summary>
    abstract class Figure
    {
        /// <summary>
        /// Тип фигуры
        /// </summary>
        protected string FigureType { get; set; }
        /// <summary>
        /// Вычисление площади
        /// </summary>
        /// <returns> площадь фигуры</returns>
        public abstract double Area(); 
        /// <summary>
        /// Переопределение метода 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (this.FigureType + " has area " + this.Area().ToString());
        }
    }

    #region Figures
    /// <summary>
    /// Класс Прямоугольник
    /// </summary>
    class Rectangle : Figure, IPrint 
    {
        /// <summary>
        /// Ширина
        /// </summary>
        protected double Width { get; set; } 
        /// <summary>
        /// Высота
        /// </summary>
        protected double Length { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="width">ширина</param>
        /// <param name="length">высота</param>
        public Rectangle(double width, double length)
        {
            this.FigureType = "Rectangle";
            this.Width = width;
            this.Length = length;
        }
        /// <summary>
        /// Вычисление площади
        /// </summary>
        /// <returns> площадь прямоугольника</returns>
        public override double Area() 
        {
            return (this.Width * this.Length); 
        }
        /// <summary>
        /// Информация о фигуре
        /// </summary>
        /// <returns>информация</returns>
        public override string ToString() 
        {
            return (this.FigureType + " (width = " + Width.ToString() + ", length = " + Length.ToString() +  ") has area " + this.Area().ToString());
        }                               
        /// <summary>
        /// Вывод ToString()
        /// </summary>
        public void IPrint() 
        {
            Console.WriteLine(this.ToString());
        }
    }
    /// <summary>
    /// Класс Квадрат
    /// </summary>
    class Square : Rectangle, IPrint
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="length">длина</param>
        public Square(double length) : base(length, length) 
        {
            this.FigureType = "Square";
            this.Length = length;
        }
        /// <summary>
        /// Вычисление площади
        /// </summary>
        /// <returns> площадь квадрата </returns>
        public override double Area() 
        {
            return (this.Length * this.Length);
        }
        /// <summary>
        /// Информация о фигуре
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
        {
            return (this.FigureType + " (lenght = " + Length.ToString() + ") has area " + this.Area().ToString());
        }                               
    }
    /// <summary>
    /// Класс Круг
    /// </summary>
    class Cirle : Figure, IPrint
    {
        /// <summary>
        /// Радиус
        /// </summary>
        private double Radius { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="radius">радиус</param>
        public Cirle(double radius)
        {
            this.FigureType = "Circle";
            this.Radius = radius;
        }
        /// <summary>
        /// Площадь круга
        /// </summary>
        /// <returns></returns>
        public override double Area() 
        {
            return Math.PI * this.Radius * this.Radius;
        }
        /// <summary>
        /// Переопределение метода
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
        {
            return (this.FigureType + " (radius = " + Radius.ToString() + ") has area " + this.Area().ToString());
        }                               
        /// <summary>
        /// Вывод информации
        /// </summary>
        public void IPrint() 
        {
            Console.WriteLine(this.ToString());
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            int id;  // тип фигуры

            Console.WriteLine("1 - Rectangle");
            Console.WriteLine("2 - Square");
            Console.WriteLine("3 - Circle");

            Console.Write("Your choise is : ");
            id = Convert.ToInt32(Console.ReadLine());

            
            while ((id < 1) || (id > 3)) // проверка на правильность
            {
                Console.WriteLine("\n!You entered wrong data! Please, try again.");
                Console.Write("Your choise is : ");

                id = Convert.ToInt32(Console.ReadLine());
            }

            Console.Clear();

            switch (id) 
            {
                #region Rectangle
                case 1:
                    double enterWidthRec, enterLengthRec; //входные параметры, которые мы будем считывать с консоли

                    Console.Write("Enter rectangle's width: ");
                    enterWidthRec = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter rectangle's length: ");
                    enterLengthRec = Convert.ToDouble(Console.ReadLine());

                    Rectangle obj_rectangle = new Rectangle(enterWidthRec, enterLengthRec); 
                    obj_rectangle.IPrint(); // Ввыод получившихся параметров

                    break; // Аналогично case 2 и case 3
                #endregion
                #region Square
                case 2:

                    double enterLengthSquare;

                    Console.Write("Enter square's length: ");
                    enterLengthSquare = Convert.ToDouble(Console.ReadLine());

                    Square obj_square = new Square(enterLengthSquare); 
                    obj_square.IPrint();

                    break;
                #endregion
                #region Circle
                case 3:

                    double enterRadius;

                    Console.WriteLine("Enter circle's radius: ");
                    enterRadius = Convert.ToDouble(Console.ReadLine());

                    Cirle obj_circle = new Cirle(enterRadius);
                    obj_circle.IPrint();

                    break;
                #endregion
                  
                default:
                    Console.WriteLine("\n!You entered wrong data!\nPlease, try again.");
                    break;
            }

            Console.Write("\n\nEnter any key for continue...");
            Console.ReadKey();
        }
    }
}
