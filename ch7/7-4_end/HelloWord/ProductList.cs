using System;

namespace HelloWord
{
    public class ProductList
    {
        public void Add(Product order)
        {
            throw new NotImplementedException();
        }

        public Product this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class ObjectList
    {
        public void Add(object o)
        {
            throw new NotImplementedException();
        }

        public object this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class GenericList<T>
    {
        public void Add(T o)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class Dictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public TValue get(TKey key)
        {
            throw new NotImplementedException(); 
        }
    }
}
