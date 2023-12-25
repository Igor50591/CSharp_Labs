using System;

namespace Task2
{
    public class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; } 
        public int MaxSpeed { get; set;}

        public Car(string name, int productionYear, int maxSpeed)
        {
            Name = name;
            ProductionYear = productionYear;
            MaxSpeed = maxSpeed;
        }
        public void Print()
        {
            Console.WriteLine($"{Name}, Max speed: {MaxSpeed}, Production year: {ProductionYear}");
        }
    }
    public class CarComparer: IComparer<Car>
    {
        public byte mode;
        public int Compare(Car? c1, Car? c2)
        {
            if (c1 is null || c2 is null)
                throw new ArgumentException("Некорректное значение параметра");

            switch (mode)
            {
                case 0:
                    return c1.Name.CompareTo(c2.Name);
                case 1:
                    return c1.ProductionYear.CompareTo(c2.ProductionYear);
                case 2:
                    return c1.MaxSpeed.CompareTo(c2.MaxSpeed);
                default:
                    return 0;
            }
        }
    }
    public class Program
    {
        public static void Main()
        {
            Car[] arr =
            {
                new Car("Citroen C4", 2013, 186),
                new Car("Honda CR-V", 2011, 190),
                new Car("Toyota Camry", 2008, 185),
                new Car("Subary Outback", 2008, 195)
            };
            Console.WriteLine("Исходный массив:");
            foreach (Car c in arr)
                c.Print();
            CarComparer CarComp = new CarComparer();
            CarComp.mode = 0; // По названию
            Array.Sort(arr, CarComp);
            Console.WriteLine("Сортировка по названию:");
            foreach (Car c in arr)
                c.Print();
            CarComp.mode = 1; // По году
            Array.Sort(arr, CarComp);
            Console.WriteLine("Сортировка по году:");
            foreach (Car c in arr)
                c.Print();
            CarComp.mode = 2; // По скорости
            Array.Sort(arr, CarComp);
            Console.WriteLine("Сортировка по максимальной скорости:");
            foreach (Car c in arr)
                c.Print();
        }
    }
}
