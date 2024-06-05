using System;
using System.Collections;
using System.Collections.Generic;

namespace L1Task1
{
    /*
    Задание 2
    Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и
    количество дней в соответствующем месяце. Реализуйте возможность выбора месяцев, как по
    порядковому номеру, так и количеству дней в месяце, при этом результатом может быть не
    только один месяц.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    internal class MyList<T> : IEnumerable<T>
    {

        private T[] _elements;
        
        private int _pointer;

        public int Count => _elements.Length;
        
        
        
        public MyList()
        {
            _elements = new T[] { };
            _pointer = 0;
        }

        public T this[int idx]
        {
            get
            {
                if (idx > _pointer) throw new ArgumentException();
                return _elements[idx];
            }
            set
            {
                if (idx > _pointer) throw new ArgumentException();
                
                _elements[idx] = value;
                
                if (idx == _pointer) _pointer++;
                
                if (_pointer == Count)
                {
                    _elements = IncreaseCapacity(_elements, Count * 2);
                }
            }
        }

        private T[] IncreaseCapacity(T[] current, int newSize)
        {
            T[] newElements = new T[newSize];

            for (int i = 0; i < current.Length; i++)
            {
                newElements[i] = current[i];
            }

            return newElements;
        }


        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    
    internal class MyListEnumerator<T> : IEnumerator<T>
    {

        private MyList<T> _list;

        public MyListEnumerator(MyList<T> list)
        {
            this._list = list;
        }

        object IEnumerator.Current => Current;

        public T Current { get; }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }
        
        public void Reset()
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}