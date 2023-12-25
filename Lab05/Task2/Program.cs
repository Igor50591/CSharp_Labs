namespace Task2
{
    public class MyList<T>
    {
        internal T[] _items;
        internal int _size;

        private const int DefaultCapacity = 4;
        private static readonly T[] emptyArray = new T[0];
        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < _size)
                {
                    throw new ArgumentException("Value is too small!");
                }

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, newItems, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = emptyArray;
                    }
                }
            }
        }

        public MyList()
        {
            _items = emptyArray;
        }

        public MyList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("Capacity must be non negative!");

            if (capacity == 0)
                _items = emptyArray;
            else
                _items = new T[capacity];
        }
        public void Add(T item)
        {
            
            T[] array = _items;
            int size = _size;
            if ((uint)size < (uint)array.Length)
            {
                _size = size + 1;
                array[size] = item;
            }
            else
            {
                int newCapacity = _items.Length == 0 ? DefaultCapacity : 2 * _items.Length;
                if ((uint)newCapacity > Array.MaxLength) newCapacity = Array.MaxLength;
                if (newCapacity < _size+1) newCapacity = _size + 1;
                Capacity = newCapacity;
                _size = size + 1;
                _items[size] = item;
            }
        }
        public int Count => _size;
        public T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_size)
                {
                    throw new ArgumentOutOfRangeException("Index must be less!");
                }
                return _items[index];
            }

            set
            {
                if ((uint)index >= (uint)_size)
                {
                    throw new ArgumentOutOfRangeException("Index must be less!");
                }
                _items[index] = value;
                }
        }
    }



    public class Program
    {
        public static void Main()
        {
            MyList<int> list = new MyList<int>();
            for (int i = 0; i < 6; ++i)
            {
                list.Add(i);
                Console.Write($"{list[i]} \t");
            }
            Console.WriteLine();
            Console.WriteLine($"First element of list: {list[0]}");
            Console.WriteLine($"Count: {list.Count}");
            Console.WriteLine($"Capacity: {list.Capacity}");
        }
    }
}
