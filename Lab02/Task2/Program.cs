namespace Task2
{
    public class program
    {
        public class Vehicle
        {
            double x, y, speed, price;
            int mfgY;
            public Vehicle(double x, double y, int mfgY, double price, double speed)
            {
                this.x = x;
                this.y = y;
                this.mfgY = mfgY;
                this.price = price;
                this.speed = speed;
            }
            public virtual void Print()
            {
                Console.WriteLine($"Координаты: X={x}, Y={y}");
                Console.WriteLine($"Цена: {price}");
                Console.WriteLine($"Скорость: {speed}");
                Console.WriteLine($"Год выпуска: {mfgY}");
            }
        }
        public class Plane : Vehicle
        {
            double height;
            int countOfPassengers;

            public Plane(double x, double y, int mfgY, double price, double speed, int countOfPassengers, double height) : base(x, y, mfgY, price, speed)
            {
                this.height = height;
                this.countOfPassengers = countOfPassengers;
            }
            public override void Print()
            {
                Console.WriteLine("Plane:");
                base.Print();
                Console.WriteLine($"Высота: {height}");
                Console.WriteLine($"Кол-во пассажиров: {countOfPassengers}");
            }
        }
        public class Ship : Vehicle
        {
            int countOfPassengers;
            string homePort;
            public Ship(double x, double y, int mfgY, double price, double speed, int countOfPassengers, string homePort) : base(x, y, mfgY, price, speed)
            {
                this.homePort = homePort;
                this.countOfPassengers = countOfPassengers;
            }
            public override void Print()
            {
                Console.WriteLine("Ship:");
                base.Print();
                Console.WriteLine($"Кол-во пассажиров: {countOfPassengers}");
                Console.WriteLine($"Порт приписки: {homePort}");
            }
        }
        public class Car: Vehicle
        {
            public Car(double x, double y, int mfgY, double price, double speed) : base(x, y, mfgY, price, speed)
            {
            }
            public override void Print()
            {
                Console.WriteLine("Car:");
                base.Print();
            }
        }

        public static void Main()
        {
            Plane plane = new(10, 10, 2008, 78300000, 477.816, 189, 3505.2);
            plane.Print();
            Ship ship = new(16, 117, 2004, 300000, 56, 2695, "Southampton, UK");
            ship.Print();
            Car car = new(56, 30, 2013, 15000, 93);
            car.Print();

        }
    }
}
