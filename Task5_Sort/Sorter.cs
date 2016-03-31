using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Sort
{
    public class Sorter
    {
        public static void Sort<T>(T[] array, Comparison<T> comparison)
        {
            if (array == null)
                throw new ArgumentNullException("");
            if (comparison == null)
                if (array[0] is IComparable<T>)
                {
                    comparison = (x, y) => (x as IComparable<T>).CompareTo(y);
                }
                else
                    throw new InvalidOperationException("");

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparison(array[j], array[i]) < 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        public static void Sort<T>(T[] array, IComparer<T> comparer)
        {
            Sort(array, comparer.Compare);
        }

        private static void Swap<T>(ref T obj1, ref T obj2)
        {
            T temp = obj2;
            obj2 = obj1;
            obj1 = temp;
        }
    }
}
