namespace Task1
{
    public class MyMatrix
    {
        public  readonly int m;// строки
        public readonly int n; // столбцы
        public double[,] matrix;
        public MyMatrix(int _m, int _n, int minvalue, int maxvalue)
        {
            Random rnd = new();
            m = _m;
            n = _n;
            matrix = new double[n, m];
            for(int i = 0; i < n; ++i)
            {
                for(int j = 0; j < m; ++j)
                {
                    matrix[i,j] = rnd.Next(minvalue, maxvalue);
                }
            }
        }
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {   
            if( a.m == b.m && a.n ==b.n) {
                MyMatrix res = new(a.n, a.m, 0, 0);
                for (int i = 0; i < a.n; ++i)
                {
                    for (int j = 0; j < a.m; ++j)
                    {
                        res.matrix[i, j] = a.matrix[i, j]+ b.matrix[i,j];
                    }
                }
                return res;
            } else
            {
                throw new ArgumentException("Размерности матриц должны совпадать!");
            }
        }

        public static MyMatrix operator -(MyMatrix a, MyMatrix b)
        {
            if (a.m == b.m && a.n == b.n)
            {
                MyMatrix res = new(a.n, a.m, 0, 0);
                for (int i = 0; i < a.n; ++i)
                {
                    for (int j = 0; j < a.m; ++j)
                    {
                        res.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                    }
                }
                return res;
            }
            else
            {
                throw new ArgumentException("Размерности матриц должны совпадать!");
            }
        }
        public static MyMatrix operator *(MyMatrix a, double k)
        {
            MyMatrix res = new(a.n, a.m, 0, 0);
            for (int i = 0; i < a.n; ++i)
            {
                for (int j = 0; j < a.m; ++j)
                {
                    res.matrix[i, j] = k * a.matrix[i, j];
                }
            }
            return res;
        }
        public static MyMatrix operator *(double k, MyMatrix a) => a * k;
        public static MyMatrix operator /(MyMatrix a, double k)
        {
            MyMatrix res = new(a.n, a.m, 0, 0);
            for (int i = 0; i < a.n; ++i)
            {
                for (int j = 0; j < a.m; ++j)
                {
                    res.matrix[i, j] = a.matrix[i, j]/k;
                }
            }
            return res;
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.n == b.m)
            {
                MyMatrix res = new(a.m, b.n, 0, 0);
                for(int i = 0; i < a.m; ++i)
                {
                    for(int j=0; j < b.n; ++j)
                    {
                        double temp = 0;
                        for(int k=0; k<a.m; ++k)
                        {
                            temp += a.matrix[i, k] * b.matrix[k, j];
                        }
                        res.matrix[i, j] = temp;
                    }
                }
                return res;
            }
            else
            {
                throw new ArgumentException("Количество строк первой матрицы должно совпадать с количеством столбцов у второй!");
            }
        }
        public double this[int index1, int index2]
        {
            get
            {
                return matrix[index1, index2];
            }
            set
            {
                matrix[index1, index2] = value;
            }
        }
        public void Print()
        {
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
    public class Program
    {
        public static void Main()
        {
            int minval;
            int maxval;
            Console.Write("Введите минимально возможное значение в матрице>> ");
            minval = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите максимально возможное значение в матрице>> ");
            maxval = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите разменрность матрицы: m=");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("n=");
            int n = Convert.ToInt32(Console.ReadLine()); ;
            MyMatrix matrix1 = new(m, n, minval, maxval);
            Console.WriteLine("Matrix1:");
            matrix1.Print();
            MyMatrix matrix2 = new(m, n, minval, maxval);
            Console.WriteLine("Matrix2:");
            matrix2.Print();
            MyMatrix matrix3  = matrix1 * matrix2;
            Console.WriteLine("Matrix3:");
            matrix3.Print();
            MyMatrix matrix4 = matrix1 + matrix3;
            Console.WriteLine("Matrix4:");
            matrix4.Print();
            MyMatrix matrix5 = matrix1 - matrix2;
            Console.WriteLine("Matrix5:");
            matrix5.Print();
            MyMatrix matrix6 = matrix1 * 2;
            Console.WriteLine("Matrix6:");
            matrix6.Print();
            MyMatrix matrix7 = matrix1 /2;
            Console.WriteLine("Matrix7:");
            matrix7.Print();
            Console.WriteLine($"Matrix1 el1: {matrix1[0,0]}");

        }
    }
}
