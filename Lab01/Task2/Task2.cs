using System;

namespace Task2RectangleNS
{
    public class Rectangle
    {
        private double side1;
        private double side2;

        public Rectangle(double sideA, double sideB)
        {
            if (sideA >= 0 && sideB >= 0)
            {
                this.side1 = sideA;
                this.side2 = sideB;
            }
            else
            {
                throw new ArgumentException();
            }

        }
        private double CalculateArea()
        {
            return this.side1 * this.side2;
        }
        private double CalculatePerimeter()
        {
            return 2 * (this.side1 + this.side2);
        }
        public double Perimeter
        {
            get
            {
                return this.CalculatePerimeter();
            }
        }
        public double Area
        {
            get
            {
                return this.CalculateArea();
            }
        }
        public static void Main()
        {
            Rectangle rectangle = new(10.1, 15.5);
            Console.WriteLine("Perimeter : {0:00.00}", rectangle.Perimeter);
            Console.WriteLine("Area : {0:00.00}", rectangle.Area);
        }
    }
}
