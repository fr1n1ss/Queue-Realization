namespace QueueRealization
{
    public class MyQueue<T>
    {
        #region Fields
        private T[] _items;
        private int _head;
        private int _tail;
        private int _capacity = 4;
        #endregion
        #region Properties
        public int Count { get; private set; }
        #endregion
        #region Constructors
        public MyQueue()
        {
            _items = new T[_capacity];
            _head = 0;
            _tail = 0;
            Count = 0;
        }
        public MyQueue(int yourCapacity)
        {
            _capacity = yourCapacity;
            _items = new T[_capacity];
            _head = 0;
            _tail = 0;
            Count = 0;
        }
        #endregion
        #region Public Methods
        public void Enqueue(T item)
        {
            if(_items.Length == Count)
            {
                Resize();
            }

            if(_tail >= _items.Length)
            {
                if (_head > 0) _tail = 0;
                else Resize();
            }

            _items[_tail] = item;

            _tail++;

            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new ArgumentException("Queue is empty!");

            if (_head >= _items.Length)
            {
                _head = 0;
            }

            T returnItem = _items[_head];

            _items[_head] = default;

            _head++;

            Count--;

            return returnItem;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new ArgumentException("Queue is empty!");

            return _items[_head];
        }

        public bool Contains(T item)
        {
            if (Count == 0)
                throw new ArgumentException("Queue is empty!");

            if (item == null)
            {
                for (int i = 0; i < _items.Length; i++)
                {
                    int index = _head + i;
                    if (index >= _items.Length)
                    {
                        index -= _items.Length;
                    }

                    if (_items[index] == null)
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < _items.Length; i++)
                {
                    int index = _head + i;
                    if (index >= _items.Length)
                    {
                        index -= _items.Length; 
                    }

                    if (item.Equals(_items[index]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion
        #region Private Methods
        private void Resize()
        {
            T[] items = new T[_items.Length * 2]; 

            if(_head < _tail)
            {
                Array.Copy(_items, _head, items, 0, _items.Length);
            }

            else
            {
                Array.Copy(_items, _head, items, 0, _items.Length - _head);
                Array.Copy(_items, 0, items, _items.Length - _head, _tail);
            }

             _items = items;
            _head = 0;
            _tail = Count;
        }
        #endregion
    }
}
