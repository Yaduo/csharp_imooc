using System;

namespace HelloWord
{
    public class DiscountCalculator<T> where T : Product
    {

    }

    // where T : IComparable
    // where T : Product
    // where T : struct
    // where T : new()
    public class Utility<T> where T : IComparable, new()
    {
        public int FindMax(int a, int b)
        {
            return a > b ? a : b;
        }

        public T FindMax(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public void DoSomething()
        {
            var obj = new T();
        }
    }
}

