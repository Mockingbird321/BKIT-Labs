using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Laba
{
    /// <summary>
    /// Класс Фигура
    /// </summary>
    abstract class Figure : IComparable
    {

        protected string FigureType { get; set; }

        public abstract double Area();

        public override string ToString()
        {
            return (this.FigureType + " has area " + this.Area().ToString());
        }
        public int CompareTo(object obj)
        {
            Figure ofigure = (Figure)obj;

            if (this.Area() < ofigure.Area())
                return -1;
            else if (this.Area() == ofigure.Area())
                return 0;
            else return 1;
        }
    }
    #region Figures
    /// <summary>
    /// Класс Прямоугольник
    /// </summary>
    class Rectangle : Figure, IPrint
    {
        protected double Width { get; set; }

        protected double Length { get; set; }

        public Rectangle(double width, double length)
        {
            this.FigureType = "Rectangle";
            this.Width = width;
            this.Length = length;
        }

        public override double Area()
        {
            return Math.Round((this.Width * this.Length), 2);
        }

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

        public Square(double length)
            : base(length, length)
        {
            this.FigureType = "Square";
            this.Length = length;
        }

        public override double Area()
        {
            return Math.Round((this.Length * this.Length), 2);
        }
    }
    /// <summary>
    /// Класс Круг
    /// </summary>
    class Cirle : Figure, IPrint
    {

        private double Radius { get; set; }

        public Cirle(double radius)
        {
            this.FigureType = "Circle";
            this.Radius = radius;
        }

        public override double Area()
        {
            return Math.Round(Math.PI * this.Radius * this.Radius, 2);
        }

        public void IPrint()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
