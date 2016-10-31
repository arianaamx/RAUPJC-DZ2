using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IGenericList<X> : IEnumerable<X>
    {
        void Add(X item);        
        bool Remove(X index);
        bool RemoveAt(int index);
        X GetElement(int index);
        int IndexOf(X item);        
        int Count { get; }
        void Clear();
        bool Contains(X item);
    }

    public class GenericList<X> : IGenericList<X> where X : IComparable<X>
    {
        private X[] _internalStorage;
        private int _size;
        private int _lastElementIndex;

        public GenericList()
        {
            _internalStorage = new X[4];
            _size = 4;
            _lastElementIndex = -1;
        }

        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];
            _size = initialSize;
            _lastElementIndex = -1;
        }

        public void Add(X item)
        {
            if (_lastElementIndex + 1 >= _size)
            {
                X[] tmp = new X[_size *= 2];
                int index = 0;
                foreach (X value in _internalStorage)
                {
                    tmp[index++] = value;
                }
                _internalStorage = tmp;
            }
            _internalStorage[++_lastElementIndex] = item;
        }

        public bool Remove(X item)
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > _lastElementIndex)
            {
                return false;
            }
            while (index < _lastElementIndex)
            {
                _internalStorage[index] = _internalStorage[index + 1];
                index++;
            }
            _lastElementIndex--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index >= 0 && index <= _size)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        
        public int IndexOf(X item)
        {
            int index = 0;
            foreach (X value in _internalStorage)
            {
                if (item.CompareTo(value) == 0)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public int Count
        {
            get
            {
                return _lastElementIndex + 1;
            }
        }

        public void Clear()
        {
            _internalStorage = null;
            _lastElementIndex = -1;
        }

        public bool Contains(X item)
        {
            if (IndexOf(item) > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class GenericListEnumerator<X> : IEnumerator<X> where X : IComparable<X>
    {
        private GenericList<X> _collection = new GenericList<X>();
        private int index;
        private X _current;

        public GenericListEnumerator()
        {

        }

        public GenericListEnumerator(GenericList<X> collection)
        {
            _collection = collection;
            index = -1;
            _current = default(X);
        }
        
        public X Current
        {
            get
            {
                return _current;
            }
        }
        
        object IEnumerator.Current
        {
            get
            {
                return _current;
            }
        }

        public void Dispose()
        {
            _collection = null;
            _current = default(X);
            index = -1;
        }

        public bool MoveNext()
        {
            if (++index >= _collection.Count)
            {
                return false;
            }
            else
            {
                _current = _collection.GetElement(index);
            }
            return true;
        }

        public void Reset()
        {
            _current = default(X);
            index = -1;
        }
    }
}