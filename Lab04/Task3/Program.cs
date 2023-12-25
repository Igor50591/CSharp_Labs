using System;

namespace Task3
{
    public class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }

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
    public class CarComparer : IComparer<Car>
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
    public class CarCatalog
    {
        public Car[] arr;
        public byte mode = 0;
        public CarCatalog(Car[] arr) => this.arr = arr;
        public int Length => arr.Length;
        public IEnumerator<Car> GetEnumerator()
        {
            switch(mode) {
                case 0:
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        yield return arr[i];
                    }
                    break;
                case 1:
                    for (int i = (arr.Length-1); i > -1; --i)
                    {
                        yield return arr[i];
                    }
                    break;
            }
        }

       // public IEnumerator<Car> GetEnumerator(int param, byte mode)
        public IEnumerable<Car> GetPersonnel(int param, byte mode)
        {
            switch (mode)
            {
                case 0:
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        if (arr[i].ProductionYear == param)
                        yield return arr[i];
                    }
                    break;
                case 1:
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        if ((arr[i].MaxSpeed == param))
                        yield return arr[i];
                    }
                    break;
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
            CarCatalog catalog = new(arr);
            catalog.mode = 0;
            Console.WriteLine("Прямой обход:");
            foreach (Car car in catalog)
            {
                car.Print();
            }
            Console.WriteLine("Обратрный проход:");
            catalog.mode = 1;
            foreach (Car car in catalog)
            {
                car.Print();
            }
            Console.WriteLine("Проход с фильтром по году(2013):");
            foreach (Car car in catalog.GetPersonnel(2013, 0))
            {
                car.Print();
            }
            Console.WriteLine("Проход с фильтром по скорости(190):");
            foreach (Car car in catalog.GetPersonnel(190,1))
            {
                car.Print();
            }


        }
    }
}