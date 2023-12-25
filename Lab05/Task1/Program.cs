namespace Task1
{
    public class MyMatrix
    {
        public int m;// строки
        public int n; // столбцы
        public double[,] matrix;
        public MyMatrix(int _m, int _n, int minvalue, int maxvalue)
        {
            Random rnd = new();
            m = _m;
            n = _n;
            matrix = new double[n, m];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    matrix[i, j] = rnd.Next(minvalue, maxvalue);
                }

            }
        }
        public void Fill()
        {
            Random rnd = new();
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    matrix[i, j] = rnd.Next();
                }
            }
        }
        public void ChangeSize(int _m, int _n)
        {
            if (_m < 0 || _n < 0) return;
            if (_m >= m && _n >= n)
            {
                if (_m > m || _n > n)
                {
                    double[,] matrixold = new double[n, m];
                    for (int i = 0; i < n; ++i)
                    {
                        for (int j = 0; j < m; ++j)
                        {
                            matrixold[i, j] = matrix[i, j];
                        }
                    }
                    matrix = new double[_n, _m];
                    int mold = m;
                    int nold = n;
                    m = _m;
                    n = _n;
                    this.Fill();
                    for (int i = 0; i < nold; ++i)
                    {
                        for (int j = 0; j < mold; ++j)
                        {
                            matrix[i, j] = matrixold[i, j];
                        }
                    }
                }
                else return;
            }
            else
            {
                double[,] matrixold = new double[n, m];
                matrix = new double[_n, _m];
                n = _n;
                m = _m;
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j)
                    {
                        matrix[i, j] = matrixold[i, j];
                    }
                }
            }
        }
        public void Show()
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
        public void ShowPartialy(int x1, int y1, int x2, int y2)
        {
            if (x1 < 0 || y1 < 0 || x2 < 0 || y2 < 0) return;
            int x = Math.Max(x1, x2);
            int y = Math.Max(y1, y2);
            int mx = Math.Min(x1, x2);
            int my = Math.Min(y1, y2);
            if (x <= this.m && y <= this.n && mx <= this.m && my <= this.n)
            {
                for (int i = mx; i <= x; ++i)
                {
                    for (int j = my; j <= y; ++j)
                    {
                        Console.Write($"{matrix[i, j]}\t");
                    }
                    Console.WriteLine();
                }
            }
            else return;


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
            matrix1.Show();
            Console.WriteLine("Matrix1 partial(2*2):");
            matrix1.ShowPartialy(0, 0, 1, 1);
            Console.WriteLine("Matrix1 changesize to 5*5:");
            matrix1.ChangeSize(5, 5);
            matrix1.Show();
            Console.WriteLine($"matrix1 m=1, n=1:{matrix1[0, 0]}");
            matrix1[0, 0] = 9999;
            Console.WriteLine($"matrix1 m=1, n=1 value set to 9999:");
            matrix1.Show();
        }
    }
}
